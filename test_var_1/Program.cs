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
            Create_cat(adress);
            Sort(adress);
            Thread.Sleep(100);
        }
        public static void Create_cat(string adr)
        {
            string[] fileEntries = Directory.GetFiles(adr);
            string[] name;
            string[] ras;
            foreach (string fileName in fileEntries)
            {
                name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                ras = name[name.Length - 1].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cat_name in Config.cat)
                {
                    if (cat_name.Contains(ras[ras.Length - 1]))
                    {
                        string[] n = cat_name.Split(new string[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                        Directory.CreateDirectory(adr + "\\" + n[0]);

                    }
                }

            }
           
        }
        public static void Sort(string adr)
        {
            string[] fileEntries = Directory.GetFiles(adr);
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
                        foreach (string cat_name in Config.cat)
                        {
                            if (cat_name.Contains(ras[ras.Length - 1]))
                            {
                                string[] n = cat_name.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                                File.Move(fileName, adr + "\\" + n[0] + "\\" + name[name.Length - 1]);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Thread.Sleep(10000);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    Thread.Sleep(100);
                }
            }
        }
    }
}
