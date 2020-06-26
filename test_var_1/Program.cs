using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Threading;

namespace test_var_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Впишите папку для сортировки");
            string adress = "";
            adress = Console.ReadLine();
            string[] fileEntries = Directory.GetFiles(adress);
            foreach (string fileName in fileEntries)
            {
                string[] ras;
                string[] name;
                try
                {
                    name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    ras = name[name.Length - 1].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        if (ras[ras.Length-1] == "zip" || ras[ras.Length - 1] == "rar")
                        {
                            File.Move(fileName, adress + "/zip/" + name[name.Length - 1]);
                        }
                        else if (ras[ras.Length - 1] == "doc" || ras[ras.Length - 1] == "docx"|| ras[ras.Length - 1] == "pdf")
                        {
                            File.Move(fileName, adress + "/docx/" + name[name.Length - 1]);
                        }
                        else if (ras[ras.Length - 1] == "mp3")
                        {
                            File.Move(fileName, adress + "/music/" + name[name.Length - 1]);
                        }
                        else if (ras[ras.Length - 1] == "jpg" || ras[ras.Length - 1] == "jpeg")
                        {
                            File.Move(fileName, adress + "/img/" + name[name.Length - 1]);
                        }
                        else
                        {
                            File.Move(fileName, adress + "/others/" + name[name.Length - 1]);
                        }
                    }
                   catch(Exception e)
                    {
                        Console.WriteLine(e);
                        Thread.Sleep(1000);
                    }
                }
               catch(Exception e)
                {
                    Console.WriteLine(e);

                    Thread.Sleep(100);
                }
            }

            Thread.Sleep(100);
        }
    }
}
