using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Data.SqlClient;
using System.IO;
using System.Collections.ObjectModel;


namespace DatabaseSync
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection serverConn = new SqlConnection(@"Data Source=192.168.2.3;Initial Catalog=sync;User Id=sa;Password=kay123");
            SqlConnection clientSqlConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sync;Integrated Security=True");
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("Urun");

            DbSyncTableDescription productDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable("Urun", serverConn);

            Collection<string> columnsToInclude = new Collection<string>();
            columnsToInclude.Add("Ad");
            columnsToInclude.Add("Adet");
            columnsToInclude.Add("BarkodNo");

            scopeDesc.Tables.Add(productDescription);
            SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning(scopeDesc);
            serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);
            serverConfig.ObjectSchema = "dbo";

            //serverConfig.Apply(serverConn);
            File.WriteAllText("SampleConfigScript.txt", serverConfig.Script("sync"));

            SqlSyncScopeProvisioning clientConfig = new SqlSyncScopeProvisioning(scopeDesc);
            clientConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);
            
            clientConfig.ObjectSchema = "dbo";
            //clientConfig.Apply(clientSqlConn);

            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
            SyncOperationStatistics syncStats;

            syncOrchestrator.RemoteProvider = new SqlSyncProvider("Urun", serverConn, null, "dbo");
            syncOrchestrator.LocalProvider = new SqlSyncProvider("Urun", clientSqlConn, null, "dbo");
            syncOrchestrator.Direction = SyncDirectionOrder.DownloadAndUpload;
            syncStats = syncOrchestrator.Synchronize();

        }
    }
}
