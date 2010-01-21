using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscUtils.Iso9660;
using System.IO;

namespace BarisGorselDLL
{
    public class IsoCreate:IDisposable
    {
        //http://www.codeproject.com/KB/aspnet/ServeCustomizedISOs.aspx
        //http://discutils.codeplex.com/
        private CDBuilder builder = new CDBuilder();
        public string Title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
                builder.VolumeIdentifier = value;
            }
        }

        public IsoCreate()
        {
            builder.UseJoliet = true;
        }

        public void AddFile(string path)
        {
            FileInfo file = new FileInfo(path);
            builder.AddFile(file.FullName, file.FullName);
        }

        public void AddFolder(string path)
        {
            //DirectoryInfo directory = new DirectoryInfo(path);
            //builder.AddDirectory(
        }

        public void Build(string path)
        {
            builder.Build(path);
        }

         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //Console.WriteLine("Remover kaldırıldı!" + GC.GetTotalMemory(true).ToString());
            //Console.ReadLine();
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    builder = null;
                }
                disposed = true;

            }
        }

    }
}
