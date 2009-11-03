using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace binaryreader
{
    public struct DatRecord
    {
        public int Id;
        public string SiraNo;
        public string ArsivNo;
        public string Name ;
        public string Date;
        public string Time;
        public int Unk;
        public string Description;
        public string Phone;
        public string Email;
        public string Birthday;
        public string Marriage;
    }

    public struct listDataStruct
    {
        public string List;
        public int Type;
        public bool Selected;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            if (Properties.Settings.Default.ConnectionString != null)
            {
                connectionString = Properties.Settings.Default.ConnectionString;
                try
                {
                    textBoxDataSource.Text = connectionString.Split(';')[0].Split('=')[1];
                    textBoxDataCatalog.Text = connectionString.Split(';')[1].Split('=')[1];
                    if (connectionString.Contains("Integrated Security=True"))
                    {
                        checkBoxDataIntegratedSecurity.Checked = true;
                    }
                    else
                    {
                        checkBoxDataIntegratedSecurity.Checked = false;
                        textBoxDataUser.Text = connectionString.Split(';')[2].Split('=')[1];
                        textBoxDataPassword.Text = connectionString.Split(';')[3].Split('=')[1];
                    }
                }
                catch
                { }
            }
        }

        
         public static List<DatRecord> Read(string filepath)
        {
            List<DatRecord> list = new List<DatRecord>();
            BinaryReader br = new BinaryReader(File.OpenRead(filepath));
            br.ReadBytes(0x390);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                DatRecord record = new DatRecord();
                
                try
                {
                    record.Id = br.ReadInt32();
                    br.ReadByte();
                    record.SiraNo = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(10));
                    br.ReadBytes(4);
                    record.ArsivNo = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(10));
                    br.ReadBytes(4);
                    record.Name = System.Text.UTF8Encoding.Default.GetString(br.ReadBytes(30));
                    br.ReadBytes(41);
                    record.Date = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(10));
                    br.ReadByte();
                    record.Time = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(5));
                    record.Unk = br.ReadInt32();
                    br.ReadBytes(59);
                    record.Description = System.Text.UTF8Encoding.Default.GetString(br.ReadBytes(49));
                    br.ReadBytes(26);
                    record.Phone = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(25));
                    br.ReadBytes(15);
                    record.Email = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(30));
                    br.ReadBytes(7);
                    record.Birthday = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(10));
                    br.ReadByte();
                    record.Marriage = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(10));
                    br.ReadBytes(102);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Exception reading data: " + ex.Message);
                    break;
                }
                if (IsInteger(record.ArsivNo.Replace("\0", "").Replace(" ", "").Trim()) && IsInteger(record.SiraNo.Replace("\0", "").Replace(" ", "").Trim()) && record.ArsivNo.Replace("\0", "").Replace(" ", "").Trim() != "" && record.SiraNo.Replace("\0", "").Replace(" ", "").Trim() != "")
                {
                    list.Add(record);
                }
            }
            br.Close();
            return list;
        }
         int sube;
         SqlConnection conn;
         private void insertRecord(DatRecord data, int typeList)
         {
             SqlCommand command = new SqlCommand("InsertLodos", conn);
             command.CommandType = System.Data.CommandType.StoredProcedure;
             command.Parameters.Add("@SiraNo", SqlDbType.NVarChar);
             command.Parameters["@SiraNo"].Value = data.SiraNo.Trim();
             command.Parameters.Add("@ArsivNo", SqlDbType.NVarChar);
             command.Parameters["@ArsivNo"].Value = data.ArsivNo.Trim();
             command.Parameters.Add("@Name", SqlDbType.NVarChar);
             command.Parameters["@Name"].Value = data.Name.Trim();
             
             TimeSpan sonucZaman;
             if (TimeSpan.TryParse(data.Time, out sonucZaman))
             { data.Time = sonucZaman.ToString(); }
             else
             { data.Time = sonucZaman.ToString(); }
             
             DateTime sonucTarih;
             DateTime.TryParse(data.Date + " " + data.Time, out sonucTarih);
             command.Parameters.Add("@Date", SqlDbType.DateTime);
             command.Parameters["@Date"].Value = sonucTarih;
             command.Parameters.Add("@Description", SqlDbType.NVarChar);
             command.Parameters["@Description"].Value = data.Description.Trim();
             command.Parameters.Add("@Phone", SqlDbType.NVarChar);
             command.Parameters["@Phone"].Value = data.Phone.Trim();
             command.Parameters.Add("@Email", SqlDbType.NVarChar);
             command.Parameters["@Email"].Value = data.Email.Trim();
             command.Parameters.Add("@Birthday", SqlDbType.NVarChar);
             command.Parameters["@Birthday"].Value = data.Birthday.Trim();
             command.Parameters.Add("@Marriage", SqlDbType.NVarChar);
             command.Parameters["@Marriage"].Value = data.Marriage.Trim();
             command.Parameters.Add("@SubeId", SqlDbType.Int);
             command.Parameters["@SubeId"].Value = sube;
             command.Parameters.Add("@ListeId", SqlDbType.Int);
             command.Parameters["@ListeId"].Value = typeList;
             try
             {
                 command.ExecuteNonQuery();
             }
             catch //(Exception ex)
             {
                 //MessageBox.Show(ex.Message);
             }
         }

         Thread sendDataThread;
         private void buttonStart_Click(object sender, EventArgs e)
         {
             if (comboBoxSube.SelectedIndex > -1)
             {
                 sendDataThread = new Thread(sendData);
                 buttonStart.Enabled = false;
                 buttonStop.Enabled = true;
                 sendDataThread.Start();
                 progressBarStatus.Minimum = 0;
             }
             else
             {
                 MessageBox.Show("Şube Seçilmeli!");
             }
         }

         string path;

         private void sendData()
         {
             conn = new SqlConnection(connectionString);
             bool baglanti = false;
             try
             {
                 conn.Open();
                 baglanti = true;
             }
             catch { DegistirStatusMethod("Sunucuya bağlanılamadı!"); }
             if (baglanti)
             {
                 DegistirStatusMethod("Aktarım işlemi başlatıldı.");
                 foreach (string selected in checkedListBoxListe.CheckedItems)
                 {
                     if (File.Exists(path + "\\" + selected))
                     {
                         if (selectedType(selected) > -1)
                         {
                             List<DatRecord> dataList = Read(path + "\\" + selected);
                             DegistirStatusMethod(selected + " " + dataList.Count + " adet veri aktarılıyor!");
                             DegistirProgressMaxMethod(dataList.Count);
                             int i = 0;
                             foreach (DatRecord x in dataList)
                             {
                                 i++;
                                 DegistirLabelMethod(i.ToString() + "\\" + dataList.Count.ToString() + "   %" + ((int)((100 * i)/dataList.Count)).ToString());
                                 DegistirProgressValueMethod(i);
                                 insertRecord(x, selectedType(selected));
                             }
                             DegistirStatusMethod(selected + " verileri aktarıldı.");
                         }
                         else
                         {
                             DegistirStatusMethod(selected + " için arşiv tipini seçiniz!");
                         }
                     }
                     else
                     {
                         DegistirStatusMethod(selected + " için geçersiz yol!");
                     }
                 }
                 conn.Close();
             }
             DegistirStatusMethod("Tüm işlemler bitti.");
             DegistirButtonMethod(buttonStart, true);
             DegistirButtonMethod(buttonStop, false);
         }

         private int selectedType(string value)
         {
             foreach (listDataStruct y in listData)
             {
                 if (y.List == value)
                 {
                     if (y.Type > -1)
                     {
                         return y.Type;
                     }
                     else
                     {
                         return -1;
                     }
                 }
             }
             return -1;
         }

         public delegate void DegistirButton(Button buton, bool durum);

         public void DegistirButtonMethod(Button buton, bool durum)
         {
             if (buton.InvokeRequired)
             {
                 DegistirButton theDelegate = new DegistirButton(DegistirButtonMethod);
                 this.Invoke(theDelegate, new object[] { buton, durum });
             }
             else
             {
                 buton.Enabled = durum;
             }
         }

         public delegate void DegistirProgressMax(int max);

         public void DegistirProgressMaxMethod(int max)
         {
             if (progressBarStatus.InvokeRequired)
             {
                 DegistirProgressMax theDelegate = new DegistirProgressMax(DegistirProgressMaxMethod);
                 this.Invoke(theDelegate, new object[] { max });
             }
             else
             {
                 progressBarStatus.Maximum = max;
             }
         }

         public delegate void DegistirProgressValue(int value);

         public void DegistirProgressValueMethod(int value)
         {
             if (progressBarStatus.InvokeRequired)
             {
                 DegistirProgressValue theDelegate = new DegistirProgressValue(DegistirProgressValueMethod);
                 this.Invoke(theDelegate, new object[] { value });
             }
             else
             {
                 progressBarStatus.Value = value;
             }
         }

         public delegate void DegistirStatus(string theText);

         public void DegistirStatusMethod(string theText)
         {
             if (this.listBoxStatus.InvokeRequired)
             {
                 DegistirStatus theDelegate = new DegistirStatus(DegistirStatusMethod);
                 this.Invoke(theDelegate, new object[] { theText });
             }
             else
             {
                 this.listBoxStatus.Items.Add(theText);
             }
         }

         public delegate void DegistirLabel(string theText);

         public void DegistirLabelMethod(string theText)
         {
             if (this.labelStatus.InvokeRequired)
             {
                 DegistirLabel theDelegate = new DegistirLabel(DegistirLabelMethod);
                 this.Invoke(theDelegate, new object[] { theText });
             }
             else
             {
                 this.labelStatus.Text = theText;
             }
         }

         private void listDoldur()
         {
             listData.Clear();
             string[] yol = Directory.GetFiles(path , "lst*.dat");
             foreach (string str in yol)
             {
                 string file = str.Split(Convert.ToChar(@"\"))[(str.Split(Convert.ToChar(@"\")).Length - 1)].ToLower();
                 if (IsInteger(file.Replace("lst", "").Replace(".dat", "")))
                 {
                     checkedListBoxListe.Items.Add(file);
                     listDataStruct newData = new listDataStruct();
                     newData.List = file;
                     newData.Type = -1;
                     newData.Selected = false;
                     listData.Add(newData);
                 }
             }

             foreach (string str in Properties.Settings.Default.SelectedLists.Split(';'))
             {
                 if (checkedListBoxListe.Items.Contains(str))
                 {
                     checkedListBoxListe.SetItemChecked(checkedListBoxListe.Items.IndexOf(str), true);
                 }
             }

             foreach (string str in Properties.Settings.Default.ListTypes.Split(Convert.ToChar(";")))
             {
                 int i = 0;
                 for (i = 0; i < listData.Count;i++)
                 {
                     if (listData[i].List == str.Split(':')[0])
                     {
                         listDataStruct newData = new listDataStruct();
                         newData = listData[i];
                         newData.Type = Convert.ToInt32(str.Split(':')[1]);
                         listData[i] = newData;
                         break;
                     }
                 }
             }
         }

         void Form1_FormClosed(object sender, FormClosedEventArgs e)
         {
             string selectedList="";
             int i = 0;
             int total = checkedListBoxListe.CheckedItems.Count;
             foreach (string selected in checkedListBoxListe.CheckedItems)
             {
                 if (i==total-1)
                 {
                     selectedList += selected;
                 }
                 else
                 {
                     selectedList += selected+";";
                 }
                 i++;
             }
             Properties.Settings.Default.SelectedLists = selectedList;
             if (Directory.Exists(path) && path != null)
             {
                 Properties.Settings.Default.Path = path;
             }

             string listType = "";
             i = 0;
             foreach (listDataStruct x in listData)
             {
                 if (i == listData.Count-1)
                 { listType += x.List + ":" + x.Type; }
                 else
                 { listType += x.List + ":" + x.Type + ";"; }
             }
             Properties.Settings.Default.ListTypes = listType;
             Properties.Settings.Default.Save();
         }

         public static bool IsInteger(string theValue)
         {
             Regex isNumber = new Regex(@"^\d+$");
             Match m = isNumber.Match(theValue);
             return m.Success;
         }

         private void buttonPath_Click(object sender, EventArgs e)
         {
             if (folderBrowserDialogPath.ShowDialog() == DialogResult.OK)
             {
                 if (Directory.Exists(folderBrowserDialogPath.SelectedPath))
                 {
                     labelPath.Text = folderBrowserDialogPath.SelectedPath;
                     path = folderBrowserDialogPath.SelectedPath;
                     listDoldur();
                 }
             }
         }

         private void buttonStop_Click(object sender, EventArgs e)
         {
             sendDataThread.Abort();
             buttonStart.Enabled = true;
             buttonStop.Enabled = false;
         }

         private DataTable DataRead(string procedureName)
         {
             conn = new SqlConnection(connectionString);
             conn.Open();
             SqlCommand cmd = new SqlCommand(procedureName, conn);
             cmd.CommandType = CommandType.StoredProcedure;
             DataTable dataTable = new DataTable();
             cmd.ExecuteNonQuery();             
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             adapter.Fill(dataTable);
             conn.Close();
             conn.Dispose();
             cmd.Dispose();
             adapter.Dispose();
             return dataTable;
         }

        

        List<listDataStruct> listData = new List<listDataStruct>();

        private void checkedListBoxListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (listDataStruct x in listData)
            {
                if (x.List == checkedListBoxListe.SelectedItem.ToString())
                {
                    comboBoxListe.SelectedIndex = x.Type;
                    break;
                }
            }
        }

        private void checkedListBoxListe_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = 0;
            foreach (listDataStruct x in listData)
            {
                if (x.List == checkedListBoxListe.Items[e.Index].ToString())
                {
                    listDataStruct newData = new listDataStruct();
                    newData = listData[i];
                    if (e.NewValue == CheckState.Checked)
                    {
                        newData.Selected = true;
                    }
                    else
                    {
                        newData.Selected = false;
                    }
                    listData[i] = newData;
                    break;
                }
                i++;
            }
        }

        private void comboBoxListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index=-1;
            if (checkedListBoxListe.SelectedIndex > -1)
            {
                int i=0;
                foreach (listDataStruct x in listData)
                {
                    
                    if (x.List == checkedListBoxListe.SelectedItem.ToString())
                    {
                        index=i;
                        break;
                    }
                    i++;
                }
                if (index>-1)
                {
                    listDataStruct newData = new listDataStruct();
                    newData = listData[index];
                    newData.Type = comboBoxListe.SelectedIndex + 1;
                    listData[index] = newData;
                }
            }
        }
        string connectionString;
        private void buttonConnect_Click(object sender, EventArgs e)
        {

            if (checkBoxDataIntegratedSecurity.Checked)
            {
                connectionString = "Data Source=" + textBoxDataSource.Text.Trim() + ";Initial Catalog=" + textBoxDataCatalog.Text.Trim() + ";Integrated Security=True";
            }
            else
            {
                connectionString = "Data Source=" + textBoxDataSource.Text.Trim() + ";Initial Catalog=" + textBoxDataCatalog.Text.Trim() + ";User Id=" + textBoxDataUser.Text.Trim() + ";Password=" + textBoxDataPassword.Text.Trim();
            }
            bool connected = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                connected = true;
            }
            catch
            {
                MessageBox.Show("Bağlantı sağlanamadı!");
            }
            if (connected)
            {
                Properties.Settings.Default.ConnectionString = connectionString;
                Properties.Settings.Default.Save();
                conn.Close();
                buttonConnect.Enabled = false;
                initialize();
            }
            conn.Dispose();
        }

        private void initialize()
        {
            try
            {
                foreach (DataRow satir in DataRead("Listeler").Rows)
                { comboBoxListe.Items.Add(satir[1]); }
            }
            catch
            {
                listBoxStatus.Items.Add("Liste tablosu eksik!");
            }
            try
            {
                foreach (DataRow satir in DataRead("Subeler").Rows)
                { comboBoxSube.Items.Add(satir[1]); }
            }
            catch
            {
                listBoxStatus.Items.Add("Sube tablosu eksik!");
            }
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            if (Properties.Settings.Default.Path != null)
            {
                if (Directory.Exists(Properties.Settings.Default.Path))
                {
                    path = Properties.Settings.Default.Path;
                    labelPath.Text = Properties.Settings.Default.Path;
                    listDoldur();
                }
                else
                { Properties.Settings.Default.Path = null; Properties.Settings.Default.Save(); }
            }
        }

        private void comboBoxSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            sube = comboBoxSube.SelectedIndex + 1;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutBox1();
            aboutForm.Show();
        }
        
    }
}
