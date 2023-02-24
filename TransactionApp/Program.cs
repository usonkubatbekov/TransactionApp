using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionApp.Service;

namespace TransactionApp
{

    public class Program
    {
 
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IOperationService, OperationService>();
                })
                .Build();

            IOperationService svc = ActivatorUtilities.CreateInstance<OperationService>(host.Services);

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
                            svc.AddTransaction();
                            break;
                        }
                    case "get":
                        {
                            svc.GetTransaction();
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
