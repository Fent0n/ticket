using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Sockets;

namespace prog
{

    public interface PrintInfo
    {
        public void Print();

    }
    /// <summary>
    /// Класс полёта
    /// </summary>
    public abstract class TicketClass : PrintInfo
    {
        //Имя класса
        public string Title { get; set; }
        //Стоимость
        public ulong Price { get; set; }

        public void Print()
        {
            Console.WriteLine("Класс:" + Title);
            Console.WriteLine("Стоимость:" + Price.ToString() + "Р");
        }
    }

    /// <summary>
    /// Эконом класс полёта
    /// </summary>
    public class EconomyClass : TicketClass
    {
        public EconomyClass()
        {
            Title = "Эконом";
            Price = 2000;
        }
    }

    /// <summary>
    /// Комфортный класс билет на самолет
    /// </summary>
    public class ComfortClass : TicketClass
    {
        public ComfortClass()
        {
            Title = "Комфорт";
            Price = 4000;
        }
    }


    /// <summary>
    /// Бизнесс класс билет на самолет 
    /// </summary>
    public class BiznessClass : TicketClass
    {
        public BiznessClass()
        {
            Title = "Бизнес";
            Price = 6000;
        }
    }

    /// <summary>
    /// Обьект билета
    /// </summary>

    public class CrewMember : PrintInfo
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
    public class Ticket : PrintInfo
    {
        public CrewMember[] CrewMembers { get; set; }
        //Название рейса
        public string Title { get; set; }

        //Номер рейса
        public string RaceNumber { get; set; }

        //Класс билета
        public TicketClass TicketClass { get; set; }
        //Тип сомалёта
        public string AirBusType { get; set; }
        //дата и время вылета
        public DateTime DepartureDate { get; set; }
        //Вывод информации
        public void Print()
        {
            Console.WriteLine("\n");
            Console.WriteLine("БИЛЕТ");

            Console.WriteLine("Рейс:" + Title);
            Console.WriteLine("Номер:" + RaceNumber);
            Console.WriteLine("Тип самолёта:" + AirBusType);
            Console.WriteLine("Дата и время вылета:" + DepartureDate.ToString());

            //Вывод информации о классе билета
            TicketClass?.Print();

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
        //Список билетов
        static Ticket[] _Tickets = new Ticket[]
        {
            new Ticket
            {
                //Самолёт
                AirBusType = "СУ-34",
                //Дата вылета
                DepartureDate = DateTime.Parse("24.10.2022 15:48:00"),
                //Номер рейса
                RaceNumber = "A-64",
                //Название рейса
                Title = "Москва - Тюмень",
                //Класс билета
                TicketClass = new ComfortClass(),
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
                //Самолёт №
                AirBusType = "СУ-21",
                //Дата вылета
                DepartureDate = DateTime.Parse("23.11.2022 15:00:00"),
                //Номер рейса
                RaceNumber = "B-852",
                //Название рейса
                Title = "Калуга - Москва",
                //Класс билета
                TicketClass = new EconomyClass(),
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
                                PrintTickets();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("выберите билет  из списка:");
                                PrintTickets();
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
        private static void PrintTickets()
        {

            for (int i = 0; i < _Tickets.Length; i++)
            {
                Console.WriteLine(i + " " + _Tickets[i].Title);
                Console.WriteLine("---------------------------");
            }
        }

    }
}