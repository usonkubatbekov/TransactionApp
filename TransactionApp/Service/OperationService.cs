using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TransactionApp.Service
{
    public class OperationService : IOperationService
    {

         public void AddTransaction()
        {
            Transaction transaction = new Transaction();
            try
            {
                Console.WriteLine("Введите ID:");
                transaction.Id = int.Parse(Console.ReadLine());
                NumberFormatInfo number = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ".",
                };
                Console.WriteLine("Введите дату(День.месяц.Год):");
                transaction.TransactionDate = DateTime.Parse(Console.ReadLine(), number);
                Console.WriteLine("Введите cумму:");
                transaction.Amount = decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Некореткно введены данные");
            }

            WorkWithJsonFile(true,0,transaction);
        }

        public void GetTransaction()
        {
            Console.WriteLine("Введите ID");
            int ID = Convert.ToInt32(Console.ReadLine());
            var transaction = new Transaction();
            WorkWithJsonFile(false,ID,transaction);

        }

        private void WorkWithJsonFile(bool AddOrGet, int ID, Transaction transaction)
        {
            using (FileStream fs = new FileStream("transaction.json", FileMode.OpenOrCreate))
                fs.Close();
            string path = Directory.GetCurrentDirectory() + @"\transaction.json";
            var jsondata = System.IO.File.ReadAllText(path);
            List<Transaction> existData = JsonConvert.DeserializeObject<List<Transaction>>(jsondata);

            if (AddOrGet == true)
            {
                existData.Add(transaction);
                jsondata = JsonConvert.SerializeObject(existData);
                File.WriteAllText(path, jsondata);
                Console.WriteLine("Данные сохранены");
            }
            else
            {
                foreach (Transaction transaction1 in existData)
                {
                    if (ID == transaction1.Id)
                    {
                        var Jsondata = JsonConvert.SerializeObject(transaction1);
                        Console.WriteLine(Jsondata);
                    }
                }

            }
        }

    }
}
