//                                Used for HardwareID Ban bypassing
//  This changes("Spoofs") your Universally Unique Identifier(GUID) so AntiCheats dont recognize you.     (commonly used for that)
//                           Or you can ofc use it for whatever you want :D


//                                       github.com/owersite


using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace hwid_spoof_test
{
    class Program
    {



        public static void SpoofGUID()
        {

            string guid = Guid.NewGuid().ToString();

            RegistryKey OurKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            OurKey = OurKey.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", true);
            OurKey.SetValue("MachineGuid", guid);


        }






        public static void SpoofHwProfileGUID()
        {
            string hwguid = "{" + Guid.NewGuid().ToString() + "}";

            RegistryKey OurKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            OurKey = OurKey.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", true);
            OurKey.SetValue("HwProfileGUID", hwguid);
            OurKey.Close();


        }




        static void Main(string[] args)
        {
            if (IsAdministrator())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Do you want to spoof your HWID? - Type 'YES' if you want to spoof your GUID");
                string mudjja = Console.ReadLine();
                if (mudjja == "YES")
                {
                    Console.WriteLine("Spoof starts.");
                    Thread.Sleep(500);
                    SpoofHwProfileGUID();
                    SpoofGUID();
                    Console.WriteLine("Done, cya <3");
                    Console.ReadLine();
                }
                else if (mudjja == "yes")
                {
                    Console.WriteLine("Spoof starts.");
                    Thread.Sleep(500);
                    SpoofHwProfileGUID();
                    SpoofGUID();
                    Console.WriteLine("Done, cya <3");
                    Console.ReadLine();

                }


                else
                {
                    Console.WriteLine("Thats a no?");
                    Console.ReadLine();
                    Thread.Sleep(1250);
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Write("Please run the program as administrator.");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }


         bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }




            }

        }
    }
