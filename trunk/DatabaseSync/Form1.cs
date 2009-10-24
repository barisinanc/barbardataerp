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
using System.Threading;


namespace DatabaseSync
{
    
    public partial class Form1 : Form
    {
        SqlConnection serverSqlConn = new SqlConnection(@"Data Source=192.168.2.3;Initial Catalog=sync;User Id=sa;Password=kay123");
        SqlConnection clientSqlConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sync;Integrated Security=True");
        SqlConnection clientSqlConn2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sync2;Integrated Security=True");
            
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void Sync()
        {
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
            SyncOperationStatistics syncStats;

            syncOrchestrator.RemoteProvider = new SqlSyncProvider("Urun", serverSqlConn, null, "dbo");
            syncOrchestrator.LocalProvider = new SqlSyncProvider("Urun", clientSqlConn, null, "dbo");
            syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
            syncStats = syncOrchestrator.Synchronize();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            Thread syncIslemi = new Thread(Sync);
            syncIslemi.Start();
        }

        private void syncInitialize()
        {
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("Urun");

            DbSyncTableDescription productDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable("Urun", serverSqlConn);

            scopeDesc.Tables.Add(productDescription);
            SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning(scopeDesc);
            serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);
            serverConfig.ObjectSchema = "dbo";

            serverConfig.Apply(serverSqlConn);
            //File.WriteAllText("SampleConfigScript.txt", serverConfig.Script("sync"));

            SqlSyncScopeProvisioning clientConfig = new SqlSyncScopeProvisioning(scopeDesc);
            clientConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);

            clientConfig.ObjectSchema = "dbo";
            clientConfig.Apply(clientSqlConn);

            if (!clientConfig.ScopeExists("Urun", clientSqlConn2))
            {
                clientConfig.Apply(clientSqlConn2);
            }
        }

        private void buttonInitialize_Click(object sender, EventArgs e)
        {

        }
    }
}
