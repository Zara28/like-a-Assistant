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
            string comm = "";
            while (comm!="end")
            {
                comm = Console.ReadLine();
                if (comm == "help")
                {
                    foreach (string str in Config.command)
                    {
                        Console.WriteLine(str);
                        Thread.Sleep(1000);
                    }

                }
                else if (comm == "Sort")
                {
                    Console.WriteLine("Впишите папку для сортировки");
                    string adress = "";
                    adress = Console.ReadLine();
                    Create_cat(adress);
                    Sort(adress);
                }
                else if (comm == "Show directory")
                {
                    foreach (string str in Config.cat)
                    {
                        Console.WriteLine(str);
                        Thread.Sleep(1000);
                    }
                }
                else if (comm == "Add directory")
                {
                    Console.WriteLine("Example: Name of directory = type of file one, type of file two and etc");
                    string new_dir = Console.ReadLine();
                    string[] l = new_dir.Split(new string[] { " ", "=", ","}, StringSplitOptions.RemoveEmptyEntries);
                    bool have = false;
                    foreach (string c in Config.cat)
                    {
                        foreach (string m in l)
                        {
                            if (c.Contains(m) && m!="")
                            {
                                have = true;
                                Console.WriteLine("It has " + m);
                                break;
                            }
                        }
                    }
                    if (!have)
                    {
                        Config.cat.Add(new_dir);
                    }
                }
                else if (comm == "Change directory")
                {
                    foreach (string str in Config.cat)
                    {
                        Console.WriteLine(str);
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Choose number of comand");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Config.cat[num - 1] = Console.ReadLine();
                }
            }
           
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
