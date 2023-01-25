﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Timers;
using System.Threading;


namespace TransactionApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Выберите и введите одну из команд:add, get, exit");
                string Comand = Console.ReadLine();
                switch (Comand)
                {
                    case "add":
                        {
                            Transaction transaction = new Transaction();
                            Console.WriteLine("Введите ID:");
                            transaction.Id = int.Parse(Console.ReadLine());
                            try
                            {
                                Console.WriteLine("Введите дату(День.месяц.Год):");
                                transaction.TransactionDate = DateTime.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Некореткно введена дата");
                                break;
                            }

                            try
                            {
                                Console.WriteLine("Введите cумму:");
                                transaction.Amount = decimal.Parse(Console.ReadLine());

                            }
                            catch
                            {
                                Console.WriteLine("Некореткно введена сумма");
                            }

                            using (FileStream fs = new FileStream("transaction.json", FileMode.OpenOrCreate))
                                fs.Close();
                            string path = Directory.GetCurrentDirectory();
                            string subputh = @"\transaction.json";
                            var filename = string.Concat(path,subputh);
                            var jsondata = System.IO.File.ReadAllText(filename);
                            List<Transaction> existData = JsonConvert.DeserializeObject<List<Transaction>>(jsondata) ?? new List<Transaction>();
                            existData.Add(transaction);
                            jsondata = JsonConvert.SerializeObject(existData);
                            File.WriteAllText(filename, jsondata);
                            Console.WriteLine("Данные сохранены!");
                            break;
                        }
                    case "get":
                        {
                            Console.WriteLine("Введите ID");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            using (FileStream fs = new FileStream("transaction.json", FileMode.OpenOrCreate))
                                fs.Close();
                            string path = Directory.GetCurrentDirectory();
                            string subputh = @"\transaction.json";
                            var filename = string.Concat(path, subputh);
                            var jsondata = System.IO.File.ReadAllText(filename);
                            
                            List<Transaction> existData = JsonConvert.DeserializeObject<List<Transaction>>(jsondata);
                            foreach ( Transaction transaction in existData ) 
                            {
                                if (ID == transaction.Id)
                                {
                                    var Jsondata = JsonConvert.SerializeObject(transaction);
                                    Console.WriteLine(Jsondata);
                                }
                            }
                            break;
                           
                        }
                    case "exit":
                        {
                            Console.WriteLine("Программа закрывается!");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неизвестная команда");
                            break;
                        }
                }

                Console.ReadLine();
            }
        
        }
    }
}
