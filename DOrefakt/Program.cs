using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Sockets;

namespace prog
{

    public interface I
    {
        public void Print();

    }
    public abstract class TC : I
    {
        public string Title { get; set; }
        public ulong Price { get; set; }

        public void Print()
        {
            Console.WriteLine("Класс:" + Title);
            Console.WriteLine("Стоимость:" + Price.ToString() + "Р");
        }
    }
    public class EC : TC
    {
        public EC()
        {
            Title = "Эконом";
            Price = 2000;
        }
    }
    public class CC : TC
    {
        public CC()
        {
            Title = "Комфорт";
            Price = 4000;
        }
    }
    public class BC : TC
    {
        public BC()
        {
            Title = "Бизнес";
            Price = 6000;
        }
    }

    /// <summary>
    /// Обьект билета
    /// </summary>

    public class CrewMember : I
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CrewMemberType { get; set; }
        public void Print()
        {

            Console.WriteLine(Name);
            Console.WriteLine("Возраст:" + Age.ToString());
            Console.WriteLine("Должность:" + CrewMemberType);
        }
    }
    public class Ticket : I
    {
        public CrewMember[] CrewMembers { get; set; }
        public string Title { get; set; }
        public string RaceNumber { get; set; }
        public TC TC { get; set; }
        public string AirBusType { get; set; }
        public DateTime DepartureDate { get; set; }
        public void Print()
        {
            Console.WriteLine("\n");
            Console.WriteLine("БИЛЕТ");

            Console.WriteLine("Рейс:" + Title);
            Console.WriteLine("Номер:" + RaceNumber);
            Console.WriteLine("Тип самолёта:" + AirBusType);
            Console.WriteLine("Дата и время вылета:" + DepartureDate.ToString());

            TC?.Print();

            Console.WriteLine("ЭКИПАЖ");
            for (int i = 0; i < CrewMembers?.Length; i++)
            {
                Console.WriteLine("\n");
                CrewMembers[i].Print();

            }

        }

    }
    public class Program
    {
        static Ticket[] _Tickets = new Ticket[]
        {
            new Ticket
            {
                AirBusType = "СУ-34",
                DepartureDate = DateTime.Parse("24.10.2022 15:48:00"),
                RaceNumber = "A-64",
                Title = "Москва - Тюмень",
                TC = new CC(),
                CrewMembers= new CrewMember[]
                {
                    new CrewMember
                    {
                        Age=25,
                        CrewMemberType="Пилот",
                        Name="Баранов Виктор Алексеевич"
                    },
                    new CrewMember
                    {
                        Age=30,
                        CrewMemberType="Стюардесса",
                        Name="Мишина Анна Андреевна"
                    }
                }
            },
            new Ticket
            {
                AirBusType = "СУ-21",
                DepartureDate = DateTime.Parse("23.11.2022 15:00:00"),
                RaceNumber = "B-852",
                Title = "Калуга - Москва",
                TC = new EC(),
            }
        };
        public static void Main()
        {
            bool isRun = true;
            while (isRun)
            {

                Console.WriteLine("Меню");
                Console.WriteLine("1 - Посмотреть список доступных билетов");
                Console.WriteLine("2 - Посмотреть информацию о билете");
                Console.WriteLine("3 - Поиск билета");

                Console.WriteLine("-1 - Выйти из программы");
                try
                {
                    int selectMenu = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    switch (selectMenu)
                    {
                        case 1:
                            {
                                PT();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("выберите билет  из списка:");
                                PT();
                                int ticketNumber = int.Parse(Console.ReadLine());
                                _Tickets[ticketNumber].Print();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Введите фразу для поиска билетов");
                                Console.WriteLine("Пример: Москва");

                                string searchText = Console.ReadLine()?.ToLower();
                                Console.WriteLine("Найденные билеты:");

                                for (int i = 0; i < _Tickets.Length; i++)
                                {
                                    if (_Tickets[i].Title.ToLower().Contains(searchText))
                                    {
                                        _Tickets[i].Print();
                                    }
                                }
                                break;
                            }
                        case -1:
                            {
                                isRun = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Такого пункта не существует");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не верный ввод");
                }
                Console.WriteLine("\n");
            }
        }
        private static void PT()
        {

            for (int i = 0; i < _Tickets.Length; i++)
            {
                Console.WriteLine(i + " " + _Tickets[i].Title);
                Console.WriteLine("---------------------------");
            }
        }

    }
}