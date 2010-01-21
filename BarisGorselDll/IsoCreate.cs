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
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                builder.VolumeIdentifier = _Title;
            }
        }

        public IsoCreate()
        {
            builder.UseJoliet = true;
        }

        public void AddFile(string path, string isoPath)
        {
            FileInfo file = new FileInfo(path);
            builder.AddFile(isoPath, file.FullName);

        }

        public void AddFolder(string isoPath)
        {
            DirectoryInfo directory = new DirectoryInfo(isoPath);
            builder.AddDirectory(isoPath);
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
