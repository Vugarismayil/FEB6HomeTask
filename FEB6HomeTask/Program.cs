using System;

namespace FEB6HomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];


            string opt;
            do
            {
                Console.WriteLine("--------- Group Statistics ---------");
                Console.WriteLine($"Secim edin:");
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Qruplara bax");
                Console.WriteLine("3. Type deyerine gore qruplara bax");
                Console.WriteLine("4. Bu gune qeder baslamis qruplara bax");
                Console.WriteLine("5. Son 2 ayda baslamis qruplara bax");
                Console.WriteLine("6. Bu ayin sonunadek yeni baslayacaq qruplara bax");
                Console.WriteLine("7. 2 tarix araliginda baslamis qruplara bax");

                Console.WriteLine("0. Cixis");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");


                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);

                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;


                        Console.WriteLine("StartDate:");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":
                        foreach (var gr in groups)
                        {
                            Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;

                        foreach (var gr in groups)
                        {
                            if (gr.Type == type)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }

                        break;
                    case "4":
                        DateTime dateTime = new DateTime();
                        dateTime = DateTime.Now;
                        int count = 0;
                        foreach (var item in groups)
                        {
                            if (item.StartDate < dateTime)
                            {
                                count++;
                                Console.WriteLine($"{item.Type}-{item.No}-{item.StartDate}");
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Qrup movcud deyil!");
                        }
                        break;
                    case "5":
                        int countt = 0;
                        foreach (var item in groups)
                        {
                            if (item.StartDate > DateTime.Now.AddMonths(-2) && item.StartDate<DateTime.Now)
                            {
                                {
                                    Console.WriteLine($"Type:{item.Type}-No{item.No}-Start Date {item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                    countt++;
                                }
                            }
                        }
                        break;
                        case"6":
                        int county = 0;
                        foreach (var item in groups)
                        {
                            if (item.StartDate.Year >= DateTime.Now.Year && item.StartDate.Month >= DateTime.Now.Month && item.StartDate.Day > DateTime.Now.Day)
                            {
                                Console.WriteLine($"Type:{item.Type}-No{item.No}-Start Date {item.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                county++;
                            }
                        }
                        if (county == 0 )
                        {
                            Console.WriteLine("bele bir qrup yoxdur");
                        }
                        break;
                    case "7":
                        Console.WriteLine("1ci ayi daxil edin:");
                        string firstDatestr = Console.ReadLine();
                        DateTime firstDate = Convert.ToDateTime(firstDatestr);

                        Console.WriteLine("2ci ayi daxil edin:");
                        string secondDatestr = Console.ReadLine();
                        DateTime secondDate = Convert.ToDateTime(secondDatestr);

                        foreach (var item2 in groups)
                        {
                            if (item2.StartDate >= firstDate && item2.StartDate <= secondDate)
                            {
                                Console.WriteLine($"No: {item2.No} - Type: {item2.Type} - StartDate: {item2.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;
                    case "0":
                        Console.WriteLine("Proqram bitdi");
                        break;

                    default:
                        Console.WriteLine("Yanlis Secim");
                        break;
                }

            } while (opt != "0");
        }
    }
}
