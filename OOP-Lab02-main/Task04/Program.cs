using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Task04
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            DrawInterface start = new DrawInterface();
            start.Start();
        }
        class DrawInterface
        {
            public DataClass user;
            public DrawInterface()
            {
                Console.Write("Введіть ваше ім'я: ");
                string name = Console.ReadLine();
                DataClass User = new DataClass(name);
                user = User;
            }
            public void Start()
            {
                ActMenu();
            }
            public void ActCheсkBalance()
            {
                Console.Clear();
                Console.WriteLine($"Ви внесли - {user.balance}");
                Console.ReadKey();
                ActMenu();
            }
            public void ActSubmitCertificate()
            {
                Console.Clear();
                Console.WriteLine($"Ви здали довідку");
                user.certificate = true;
                Console.ReadKey();
                ActMenu();
            }
            public void ActCheckPayValue()
            {
                Console.Clear();
                Console.WriteLine($"Ви повині заплатити - {user.needToPay}");
                user.certificate = true;
                Console.ReadKey();
                ActMenu();
            }
            public void ActPay()
            {
                Console.Clear();
                Console.Write($"Внесіть оплату: ");
                double value =  Convert.ToDouble(Console.ReadLine());
                user.balance += value;
                Console.ReadKey();
                ActMenu();

            }
            public void ActPassport()
            {
                bool Accept = true;
                Console.Clear();
                if (user.balance < user.needToPay)
                {
                    Console.WriteLine($"Ви недостатньо внесли коштів");
                    Accept = false;
                }
                if (!(user.certificate))
                {
                    Console.WriteLine($"Ви не здали довідку");
                    Accept = false;
                }
                if (Accept)
                {
                    Random random = new Random();
                    // Генеруємо випадкове булеве значення
                    bool randomBoolean = random.Next(2) == 0;
                    if (user.technicalPassport)
                    {
                        Console.WriteLine($"Ви вже отримали свій технічний паспорт");
                    }
                    
                    else if (randomBoolean)
                    {
                        Console.WriteLine($"Вітаю, ви отримали ваш технічний паспорт");
                        user.technicalPassport = true;
                    }
                    else
                    {
                        Console.WriteLine($"На жаль, ваш технічний паспорт ще не готовий. Ви отримали виплатити за неустойку");
                    }
                }
                Console.ReadKey();
                ActMenu();
            }
            public string Menu()
            {
                Console.Clear();
                Console.WriteLine("1 - Здати довідку");
                Console.WriteLine("2 - Внести оплату");
                Console.WriteLine("3 - Переглянути баланс");
                Console.WriteLine("4 - Переглянути суму до оплати");
                Console.WriteLine("5 - Отримати технічний паспорт");
                Console.WriteLine("6 - Вийти");
                Console.Write("Вибіріть дію: ");
                string act = Console.ReadLine();
                return act;
            }
            public void ActMenu()
            {
                string act = Menu();
                if (act == "1")
                {
                    ActSubmitCertificate();
                }
                else if (act == "2")
                {
                    ActPay();
                }
                else if (act == "3")
                {
                    ActCheсkBalance();
                }
                else if (act == "4")
                {
                    ActCheckPayValue();
                }
                else if (act == "5")
                {
                    ActPassport();
                }
                else if (act == "6") { }
                else
                {
                    Menu();
                }
            }
        }

        class DataClass
        {
            public string name;
            public bool technicalPassport;
            public bool certificate;
            public double balance;
            public double needToPay;
            public DataClass(string Name)
            {
                name = Name;
                technicalPassport = false;
                certificate = false;
                balance = 0;
                Random random = new Random();
                int randomNumber = random.Next(1000, 5000);
                needToPay = randomNumber;
            }
        }
    }
}