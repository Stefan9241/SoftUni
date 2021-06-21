using System;
using System.IO;

namespace _04.CopyBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BYTE_BUFFER = 4096;
            using (FileStream reade = new FileStream("copyMe.png", FileMode.Open))
            using (FileStream writer = new FileStream("copied.png", FileMode.Create))
            

            while (reade.CanRead)
            {
                    byte[] buffer = new byte[BYTE_BUFFER];
                    int readBytes = reade.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    writer.Write(buffer, 0, readBytes);
                       
            }

        }
    }
}
