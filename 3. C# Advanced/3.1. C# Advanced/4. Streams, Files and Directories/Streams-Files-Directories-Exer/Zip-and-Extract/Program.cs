using System;
using System.IO.Compression;

namespace Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../FirstDirectory", "../../../SecondDirectory/copyMe.zip");
            ZipFile.ExtractToDirectory("../../../SecondDirectory/copyMe.zip", "../../../ThirdDirectory");
        }
    }
}
