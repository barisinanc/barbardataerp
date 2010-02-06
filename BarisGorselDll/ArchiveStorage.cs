using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BarisGorselDLL
{
    public class ArchiveStorage
    {
        private string server;

        public ArchiveStorage(Cari cari)
        {
            _cari = cari;
            server = BarisGorselDLL.Properties.Settings.Default.fileServerPath;
        }

        public ArchiveStorage()
        {
            server = BarisGorselDLL.Properties.Settings.Default.fileServerPath;
        }

        private Cari _cari;

        public void Save(List<ImagePack> Images)
        {
            string remotePath = server + Images.First().ArsivNo + " " + _cari.Isim+"\\";
            /*string[] rPath = remotePath.Trim().Split('\\');
            string path = server;
            for (int i = 0; i < (rPath.Length - 1); i++)
            {
                path += rPath[i] + "\\";
                if (!Directory.Exists(path))
                { Directory.CreateDirectory(path); }
            }*/
            string thumbPath = Photo.ThumbFolderCreator(remotePath);
            foreach (ImagePack img in Images)
            {
                string tempPath;
                string thumbTempPath;
                if (img.IsRaw)
                {
                    tempPath = remotePath + "Ham\\";
                    thumbTempPath = Photo.ThumbFolderCreator(tempPath);
                }
                else
                {
                    tempPath = remotePath;
                    thumbTempPath = thumbPath;
                }
                File.Copy(img.Path, tempPath + img.Name);
                File.Copy(img.ThumbPath, thumbTempPath + System.IO.Path.GetFileNameWithoutExtension(img.Path) + ".thumb");
                File.Delete(img.Path);
                File.Delete(img.ThumbPath);
            }
        }

        public void Save(ImagePack Image)
        {
            string remotePath = server + Image.ArsivNo + " " + _cari.Isim+"\\";
            /*string[] rPath = remotePath.Trim().Split('\\');
            string path = server;
            for (int i = 0; i < (rPath.Length - 1); i++)
            {
                path += rPath[i] + "\\";
                if (!Directory.Exists(path))
                { Directory.CreateDirectory(path); }
            }*/
            string thumbPath = Photo.ThumbFolderCreator(remotePath);

            if (Image.IsRaw)
            {
                remotePath = remotePath + "Ham";
                thumbPath = Photo.ThumbFolderCreator(remotePath);
            }
            File.Copy(Image.Path, remotePath + Image.Name);
            //File.Copy(Image.ThumbPath, Photo.ThumbPathCreator(thumbPath));
            File.Copy(Image.ThumbPath, thumbPath + System.IO.Path.GetFileNameWithoutExtension(Image.Path) + ".thumb");
            File.Delete(Image.Path);

            File.Delete(Image.ThumbPath);
        }

        public void Delete(ImagePack Image)
        {
            string[] yol=Directory.GetDirectories(server, Image.ArsivNo + "*");
            if (yol.Length > 0)
            {
                File.Delete(yol.First() + Image.Path);
                File.Delete(yol.First() + Image.ThumbPath);
            }
        }

        public string FindPath(ImagePack image)
        {
            string[] yol = Directory.GetDirectories(server, image.ArsivNo + "*");
            if (yol.Length > 0)
            {
                if(image.IsRaw)
                {
                    return yol.First() + "Ham" + image.Name;
               }
                else
                {
                    return yol.First() + image.Name;
                }
            }
            return null;
        }

        public List<ImagePack> getImages(string arsivNo)
        {

            string[] yol = Directory.GetDirectories(server, arsivNo + "*");
            if (yol.Length > 0)
            {
                List<ImagePack> list = new List<ImagePack>();
                IEnumerable<string> fileNames =
                    Directory.GetFiles(yol.First() + "Ham").Where(f => !f.Contains(".thumb")).Where(
                        f => f.EndsWith(".jpg")
                            || f.EndsWith(".JPG")
                            || f.EndsWith(".bmp")
                            || f.EndsWith(".BMP")
                            || f.EndsWith(".png")
                            || f.EndsWith(".PNG")
                            || f.EndsWith(".psd")
                            || f.EndsWith(".PSD")
                    );
                foreach (string file in fileNames)
                {
                    ImagePack img = new ImagePack();
                    img.ArsivNo = arsivNo;
                    FileInfo fileInfo = new FileInfo(file);
                    img.Name = fileInfo.Name;
                    img.Path = file;
                    img.IsRaw = true;
                    list.Add(img);
                }
                fileNames =
                   Directory.GetFiles(yol.First()).Where(f => !f.Contains(".thumb")).Where(
                       f => f.EndsWith(".jpg")
                           || f.EndsWith(".JPG")
                           || f.EndsWith(".bmp")
                           || f.EndsWith(".BMP")
                           || f.EndsWith(".png")
                           || f.EndsWith(".PNG")
                           || f.EndsWith(".psd")
                           || f.EndsWith(".PSD")
                   );
                foreach (string file in fileNames)
                {
                    ImagePack img = new ImagePack();
                    img.ArsivNo = arsivNo;
                    FileInfo fileInfo = new FileInfo(file);
                    img.Name = fileInfo.Name;
                    img.Path = file;
                    img.IsRaw = false;
                    list.Add(img);
                }

                return list;
            }
            return null;
        }
    }
}
