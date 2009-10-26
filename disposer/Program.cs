using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace disposer
{
    public class Remover : IDisposable
    {
        List<string> liste = new List<string>();

        private bool disposed = false;

        public Remover()
        {
           
            for (int i = 0; i < 10000000; i++)
            {
                liste.Add("sdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfg");
            }
            Console.WriteLine("remover Oluştu!"+ GC.GetTotalMemory(true).ToString());
            Console.ReadLine();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Remover kaldırıldı!" + GC.GetTotalMemory(true).ToString());
            Console.ReadLine();
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    liste = null;
                }
                disposed = true;

            }
        }

        ~Remover()
        {
            Console.WriteLine("ohoooo gitti bile");
            Dispose(false);
        }

    }

    class ikimcil:Remover
    {
        List<string> liste = new List<string>();
        public ikimcil()
        {
            for (int i = 0; i < 10000000; i++)
            {
                liste.Add("sdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfgsdfsdfgsfdgdsfgdfg");
            }
            Console.WriteLine("ikinci Oluştu!" + GC.GetTotalMemory(true).ToString());
            Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Başladı!" + GC.GetTotalMemory(true).ToString());
            Console.ReadLine();
            ikimcil sil = new ikimcil();
            sil.Dispose();
            Console.WriteLine("Bitti!" + GC.GetTotalMemory(true).ToString());
            Console.ReadLine();
        }
    }
}
