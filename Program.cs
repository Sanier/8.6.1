using System;
using System.IO;

namespace _8._6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пропишите путь до файла как в примере: C:/Users/user/Desktop/example.bin");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                    var lastMod = File.GetLastWriteTime(filePath);
                    if (lastMod <= DateTime.Now - TimeSpan.FromMinutes(30))
                    {
                        dirInfo.Delete(true);
                        Console.WriteLine("Delete");
                    }
                    else
                    {
                        Console.WriteLine("Время последнего использования файлов не превысило 30 минут. \nВремя последнего использования файла: {0}", lastMod);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка {0}", ex.Message);
                }
            }
        }
    }
}
