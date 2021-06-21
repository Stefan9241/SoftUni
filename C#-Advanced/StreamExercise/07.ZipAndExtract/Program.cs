using System;
using System.IO.Compression;

namespace _07.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\Програми\Visual\C#-Advanced\StreamExercise\forZipAndExtract",
                @"D:\Програми\Visual\C#-Advanced\StreamExercise\07.ZipAndExtract\output");

            ZipFile.ExtractToDirectory(@"D:\Програми\Visual\C#-Advanced\StreamExercise\07.ZipAndExtract\output",
                @"D:\Програми\Visual\C#-Advanced\StreamExercise\07.ZipAndExtract\forZipAndExtract\test");
        }
    }
}
