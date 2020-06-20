using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Permissions;

namespace test_var_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> comm = new List<string>();
            RegistryKey key;
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Unistall");
            foreach(String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                comm.Add(subkey.GetValue("DisplayName") as string);
            }
            foreach(string a in comm)
            {
                Console.WriteLine(a);
               
            }
        }
    }
}
