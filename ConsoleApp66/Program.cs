using ConsoleApp66.Data.Dal;
using ConsoleApp66.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp66
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            string input;
            Console.WriteLine("1.stadion elave et ");
            Console.WriteLine("2.Stadionlari goster");
            Console.WriteLine("3.istifadeci elave et");
            Console.WriteLine("4.istifadecileri goster");
            Console.WriteLine("5.reservasyalari goster");
            Console.WriteLine("6.reservasyalari yarat");
            Console.WriteLine("7.Verilmis Id li stadionlarin reservasyalarini goster");
            Console.WriteLine("8.Verilmis Id li  Userin reservasyaalrini goster");
            Console.WriteLine(" 9.Verilmis Id li  reservasyani sil");

            do
            {
                Console.WriteLine("1.stadion elave et ");
                Console.WriteLine("2.Stadionlari goster");
                Console.WriteLine("3.istifadeci elave et");
                Console.WriteLine("4.istifadecileri goster");
                Console.WriteLine("5.reservasyalari goster");
                Console.WriteLine("6.reservasyalari yarat");
                Console.WriteLine("7.Verilmis Id li stadionlarin reservasyalarini goster");
                Console.WriteLine("8.Verilmis Id li  Userin reservasyaalrini goster");
                Console.WriteLine(" 9.Verilmis Id li  reservasyani sil");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Stadion stadion = new Stadion();
                        Console.WriteLine("Name daxil edin");
                        stadion.Name = Console.ReadLine();
                        Console.WriteLine("Capacity daxil edin");
                        stadion.Capacity = int.Parse( Console.ReadLine());
                        Console.WriteLine("HourPrice daxil edin");
                        stadion.HourPrice = decimal.Parse( Console.ReadLine());
                        if (string.IsNullOrEmpty(stadion.Name))
                        {
                            throw new Exception("bos  daxil edibsen");


                        }
                        if (stadion.Capacity==null)
                        {
                            throw new Exception("xetaaa");


                        }
                        if (stadion.HourPrice==null)
                        {
                            throw new Exception("xetaaa");


                        }
                        AddStadion(stadion);
                        break;
                        case "2":
                        foreach (var item in ShowStadion())
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.Name);

                            Console.WriteLine(item.HourPrice);
                            Console.WriteLine(item.Capacity);
                           
                            

                        }
                       
                        break;
                    case "3":
                        User user = new User();
                        Console.WriteLine("Fullname daxil edin");
                        user.FullName = Console.ReadLine();
                        Console.WriteLine("Email daxil edin");
                        user.Email = Console.ReadLine();

                        AddUser(user);

                        break;
                    case "4":
                        foreach (var item in ShowUser())
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.FullName);
                            Console.WriteLine(item.Email);

                        }
                        break;
                    case "5":
                        foreach (var item in ShowReservation())
                        {
                            Console.WriteLine(item.StartDate);
                            Console.WriteLine(item.UserId);
                            Console.WriteLine(item.StadionId);
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.EndDate);

                        }
                        
             
                        break;
                    case "6":
                        Reservation reservation = new Reservation();
                        Console.WriteLine("Baslanqic tarixi elave edin");
                        string start = Console.ReadLine();
                        Console.WriteLine("Son tarixi elave edin");
                        string end= Console.ReadLine();
                        Console.WriteLine("StadionId daxil edin");
                        reservation.StadionId = int.Parse( Console.ReadLine());
                        Console.WriteLine("UserId daxil edin");
                        reservation.UserId= int.Parse( Console.ReadLine());

                        reservation.StartDate = Convert.ToDateTime(start);
                        reservation.EndDate = Convert.ToDateTime(end);
                        AddReservation(reservation);



                        break;
                    case "7":
                        Console.WriteLine("Id daxil edin");
                        int input2 = int.Parse(Console.ReadLine());
                        if (input2!=null)
                        {
                            Console.WriteLine("Rezerv Id"+SelectReservationStadions(input2).Id);

                            Console.WriteLine("StadionId"+SelectReservationStadions(input2).StadionId);
                            Console.WriteLine("UserID"+SelectReservationStadions(input2).UserId);
                            Console.WriteLine("Baslanqic tarix"+SelectReservationStadions(input2).StartDate);
                            Console.WriteLine("Son tarix"+SelectReservationStadions(input2).EndDate);


                        }







                        break;
                    case "8":
                        Console.WriteLine("Id daxil edin");
                        int input3 = int.Parse( Console.ReadLine());
                        if (input3!=null)
                        {
                            Console.WriteLine("Rezerv Id"+SelectReservationUser(input3).Id);
                            Console.WriteLine("Istifadeci Id"+SelectReservationUser(input3).UserId);
                            Console.WriteLine("stadion Id"+SelectReservationUser(input3).StadionId);
                            Console.WriteLine("Baslanqic tarix" + SelectReservationStadions(input2).StartDate);
                            Console.WriteLine("Son tarix" + SelectReservationStadions(input2).EndDate);

                        }
                        else
                        {
                            throw new Exception("xetaaaa");
                        }




                        break;
                    case "9":
                        Console.WriteLine("Id daxil edin");
                        int input4 = int.Parse(Console.ReadLine());
                        if (input4!=null)
                        {
                            DeletReservation(input4);
                        }
                        else
                        {
                            throw new Exception("xetaaa");
                        }
                        


                        break;

                }

            } while (true);
           
        }
        public  static void AddStadion(Stadion stadion)
        {
            using(FootballDbContext footballDbContext = new FootballDbContext())
            {
                footballDbContext.Add(stadion);
                footballDbContext.SaveChanges();

            }

        }
        public static List<Stadion> Musi()
        {
            using(FootballDbContext footballDbContext=new FootballDbContext())
            {
                return footballDbContext.Stadions.ToList();
               

            }
        }
        public static void ShowStadion(Stadion stadion)
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                footballDbContext.Add(stadion);
                footballDbContext.SaveChanges();

            }

        }
        public static List<Stadion> ShowStadion()
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                return footballDbContext.Stadions.ToList();


            }
        }
        public static void AddUser(User user)
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                footballDbContext.Add(user);
                footballDbContext.SaveChanges();

            }

        }
        public static List<User> ShowUser()
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                return footballDbContext.Users.ToList();


            }
        }
        public static List<Reservation> ShowReservation()
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                return footballDbContext.Reservations.ToList();


            }
        }
        public static void AddReservation(Reservation reservation)
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {
                footballDbContext.Add(reservation);
                footballDbContext.SaveChanges();

            }

        }
        public  static Reservation SelectReservationStadions(int id)
        {
            using(FootballDbContext footballDbContext= new FootballDbContext())
            {
                return footballDbContext.Reservations.FirstOrDefault(a=>a.StadionId==id);
                



            }



        }
        public  static Reservation SelectReservationUser(int id)
        {
            using (FootballDbContext footballDbContext = new FootballDbContext())
            {


             return footballDbContext.Reservations.FirstOrDefault(x=>x.UserId==id);

            }



        }
        public  static void DeletReservation(int id)
        {
            using(FootballDbContext footballDbContext = new FootballDbContext())
            {
                var a=footballDbContext.Reservations.FirstOrDefault(x=> x.Id==id);
                if (a!=null)
                {
                    footballDbContext.Reservations.Remove(a);
                    footballDbContext.SaveChanges();

                }



            }



        }


    }
}
