using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BarisGorselDLL
{
    public class ImagePack
    {
        private string _Path;
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                IsThumbCreated();
                _ThumbPath = BarisGorselDLL.Photo.ThumbPathCreator(value);
            }
        }

        private void IsThumbCreated()
        {
            if (!File.Exists(BarisGorselDLL.Photo.ThumbPathCreator(_Path)))
            {
                BarisGorselDLL.Photo.ThumbCreate(_Path);
            }
        }
        public string Name { get; set; }
        private string _ThumbPath;
        public string ThumbPath
        {
            get
            {
                return _ThumbPath;
            }
            set
            {
                _ThumbPath = value;
            }
        }
        public bool IsSelected;
        private bool _IsClicked;
        public bool IsClicked
        {
            get
            {
                return _IsClicked;
            }
            set
            {
                _IsClicked = value;
            }
        }
        public int Id;
        public void Rotate(BarisGorselDLL.Photo.RotateTypes rotateType)
        {
            Photo foto = new Photo();
            foto.Path = Path;
            foto.Rotate(rotateType);
            foto.JpegSave(foto.Path, 96);
            foto.Path = ThumbPath;
            foto.Rotate(rotateType);
            foto.JpegSave(foto.Path, 96);
            foto = null;
        }

        
    }
}
