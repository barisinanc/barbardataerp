using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nftplib;

namespace BarisGorselDLL
{
    public class Ftp
    {
        nftplib.FtpClient ftp;

        //FtpConnection ftp = new FtpConnection(BarisGorselDLL.Properties.Settings.Default.ftpServer, BarisGorselDLL.Properties.Settings.Default.ftpUserName, BarisGorselDLL.Properties.Settings.Default.ftpPassword);
        public Ftp()
        {
            ftp = new FtpClient("ftp://"+BarisGorselDLL.Properties.Settings.Default.ftpServer, BarisGorselDLL.Properties.Settings.Default.ftpUserName, BarisGorselDLL.Properties.Settings.Default.ftpPassword);
        }

        public bool Save(string localFilePath,string remoteFilePath)
        {//TODO müşteri ismi (*, gibi) olamaz

           /*string[] remotePath=remoteFilePath.Replace(@"\",@"/").Trim().Split('/');
            for (int i = 0; i < (remotePath.Length - 2); i++)
            {
                if (!ftp.IsDirectoryExists(remotePath[i]))
                { ftp.CreateFolder(remotePath[i]);  }
                ftp.SetCurrentDirectory(remotePath[i]);
            }*/
            ftp.UploadFile(localFilePath, remoteFilePath);
            return true;
        }
    }
}
