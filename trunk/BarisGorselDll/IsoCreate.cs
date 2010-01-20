using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscUtils.Iso9660;

namespace BarisGorselDLL
{
    public class IsoCreate
    {
        private CDBuilder builder = new CDBuilder();
            
        public IsoCreate()
        {
            builder.UseJoliet = true;
            builder.AddFile("baran.jpg", "D:\\kimlik.jpg");
            builder.Build("c:\\deneme.iso");
        }
    }
}
