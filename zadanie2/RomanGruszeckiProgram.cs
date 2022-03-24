using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Data.SqlClient;
//Roman Gruszecki s97623 ćwiczenie2
namespace zadanie2
{


    class Program
    {

        
            private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string radnowb(int a)
        {
            return RandomString(random.Next(1, a));
        }
        //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings

        public static void zapisdopliku(List<BloggingContext> a)
        {

        }

        public class BloggingContext : DbContext
        {
            public DbSet<MEDIA> MEDIA { get; set; }
            public DbSet<TAGI> TAGI { get; set; }

            public DbSet<TWORCA> TWORCA { get; set; }
            public DbSet<UZYTKOWNIK> UZYTKOWNIK { get; set; }
            public DbSet<STATUS> STATUS { get; set; }
            public DbSet<SEZON> SEZON { get; set; }
            public DbSet<ANIEM> ANIEM { get; set; }
            public DbSet<TOM> TOM { get; set; }
            public DbSet<ODCINKI> ODCINKI { get; set; }
            public DbSet<OGLADANE> OGLADANE { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1522)))(CONNECT_DATA=(SID=orcltp)));User ID=s97623;Password=s97623");
            }
        }

        public class MEDIA
        {

            public int MEDIAID { get; set; }

            public string NAZWA { get; set; }
            public string OPIS { get; set; }

            public List<ANIEM> ANIEMs { get; set; }

        }

        public class TAGI
        {
            public int TAGIID { get; set; }

            public string NAZWA { get; set; }
            public string OPIS { get; set; }

            public List<ANIEM> ANIEMs { get; set; }

        }

        public class TWORCA
        {
            public int TWORCAID { get; set; }

            public string IMIENASWISKO { get; set; }
            public string DATAURODZENIA { get; set; }

            public List<ANIEM> ANIEMs { get; set; }

        }

        public class UZYTKOWNIK
        {
            public int UZYTKOWNIKID { get; set; }

            public string NAZWA { get; set; }
            public string EMAIL { get; set; }
            public DateTime DATAURODZENIA { get; set; }

            public List<OGLADANE> OGLADANEs { get; set; }
        }

        public class STATUS
        {
            public int STATUSID { get; set; }

            public string NAZWA { get; set; }

            public List<OGLADANE> OGLADANEs { get; set; }
        }
        public class SEZON
        {
            public int SEZONID { get; set; }

            public string NAZWA { get; set; }

            public List<ANIEM> ANIEMs { get; set; }
        }

        public class ANIEM
        {
            public int ANIEMID { get; set; }

            public string NAZWA { get; set; }
            public int MEDIAID { get; set; }
            public int SEZONID { get; set; }
            public int ILOSCODCINKOW { get; set; }
            public int TWORCAID { get; set; }
            public int TAGIID { get; set; }

            public List<TOM> TOMs { get; set; }
            public List<OGLADANE> OGLADANEs { get; set; }
            public List<ODCINKI> ODCINKIs { get; set; }
        }

        public class TOM
        {
            public int TOMID { get; set; }

            public int NRTOMU { get; set; }
            public int DLUGOSCTOMU { get; set; }
            public int ANIEMID { get; set; }

            public List<OGLADANE> OGLADANEs { get; set; }

        }

        public class ODCINKI
        {
            public int ODCINKIID { get; set; }

            public int NRODCINKA { get; set; }
            public string NAZWAODCINKA { get; set; }
            public int DLUGOSCODC { get; set; }
            public int ANIEMID { get; set; }
            public List<OGLADANE> OGLADANEs { get; set; }

        }

        public class OGLADANE
        {
            public int OGLADANEID { get; set; }
            public int STATUSID { get; set; }
            public int UZYTKOWNIKID { get; set; }
            public int ODCINKIID { get; set; }
            public int TOMID { get; set; }
            public int ANIEMID { get; set; }

        }

        /*
        public int wielkosc(DbSet<DbContext> entities)
        {
            return entities.Count();
        }
        */
        public static void wielkosc(int a, int aa)
        {
            using (var db = new BloggingContext())
            {
                switch (a)
                {
                    case 1:
                        for (int xd = 0; xd < aa; xd++) { dodajdomedia(); }
                        Console.WriteLine("Zakonczylem dodawac media\n");
                        break;
                    case 2:
                        for (int xd = 0; xd < aa; xd++) { dodajdotagi(); }
                        Console.WriteLine("Zakonczylem dodawac tagi\n");
                        break;
                    case 3:
                        for (int xd = 0; xd < aa; xd++) { dodajdotworca(); }
                        Console.WriteLine("Zakonczylem dodawac tworcow\n");
                        break;
                    case 4:
                        for (int xd = 0; xd < aa; xd++) { dodajdouzytkownik(); }
                        Console.WriteLine("Zakonczylem dodawac uzytkownikow\n");
                        break;
                    case 5:
                        for (int xd = 0; xd < aa; xd++) { dodajdostatus(); }
                        Console.WriteLine("Zakonczylem dodawac statusy\n");
                        break;
                    case 6:
                        for (int xd = 0; xd < aa; xd++) { dodajdosezon(); }
                        Console.WriteLine("Zakonczylem dodawac sezony\n");
                        break;
                    case 7:
                        for (int xd = 0; xd < aa; xd++) { dodajdoaniem(); }
                        Console.WriteLine("Zakonczylem dodawac anime\n");
                        break;
                    case 8:
                        for (int xd = 0; xd < aa; xd++) { dodajdotom(); }
                        Console.WriteLine("Zakonczylem dodawac tomy\n");
                        break;
                    case 9:
                        for (int xd = 0; xd < aa; xd++) { dodajdoodcinki(); }
                        Console.WriteLine("Zakonczylem dodawac odcniki\n");
                        break;
                    case 10:
                        for (int xd = 0; xd < aa; xd++) { dodajdoogladane(); }
                        Console.WriteLine("Zakonczylem dodawac ogladane\n");
                        break;
                    case 0:
                        for (int i = 1; i <= 10; i++)
                        {
                            wielkosc(i, aa);
                        }
                        break;
                    default:
                        Console.WriteLine("nie rozpoznano talicy prosze jeszcze raz podać numer tablicy");
                        a = Int16.Parse(Console.ReadLine());
                        wielkosc(a, aa); break;
                }

            }
        }
        public static void dodajdomedia()
        {
            using (var db = new BloggingContext())
            {
                var con = new MEDIA { MEDIAID = db.MEDIA.Count() + 1, NAZWA = radnowb(15), OPIS = radnowb(30) };
                db.MEDIA.Add(con);
                string a = "insert into media(mediaID,nazwa,opis)VALUES('" + con.MEDIAID + "','" + con.NAZWA + "','" + con.OPIS + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdotagi()
        {
            using (var db = new BloggingContext())
            {
                var con = new TAGI { TAGIID = db.TAGI.Count() + 1, NAZWA = radnowb(15), OPIS = radnowb(30) };
                db.Add(con);
                string a = "insert into tagi(tagiID,nazwa,opis)VALUES('" + con.TAGIID + "','" + con.NAZWA + " ','" + con.OPIS + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdotworca()
        {
            using (var db = new BloggingContext())
            {
                var con = new TWORCA { TWORCAID = db.TWORCA.Count() + 1, IMIENASWISKO = RandomString(30) };
                db.Add(con);
                string a = "insert into tworca(tworcaID,imienaswisko,dataurodzenia)VALUES('" + con.TWORCAID + "','" + con.IMIENASWISKO + "','');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdouzytkownik()
        {
            using (var db = new BloggingContext())
            {
                var con = new UZYTKOWNIK { UZYTKOWNIKID = db.UZYTKOWNIK.Count() + 1, NAZWA = radnowb(15), EMAIL = radnowb(10) + "gmail.com" };
                db.Add(con);
                string a = "insert into uzytkownik(uzytkownikID,nazwa,email)VALUES('" + con.UZYTKOWNIKID + "','" + con.NAZWA + "','" + con.EMAIL + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdostatus()
        {
            using (var db = new BloggingContext())
            {
                var con = new STATUS { STATUSID = db.STATUS.Count() + 1, NAZWA = radnowb(10) };
                db.Add(con);
                string a = "insert into status(statusID,nazwa)VALUES('" + con.STATUSID + "','" + con.NAZWA + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdosezon()
        {
            using (var db = new BloggingContext())
            {
                var con = new SEZON { SEZONID = db.SEZON.Count() + 1, NAZWA = radnowb(10) };
                db.Add(con);
                string a = "insert into sezon(sezonID,nazwa)VALUES('" + con.SEZONID + "','" + con.NAZWA + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdoaniem()
        {
            using (var db = new BloggingContext())
            {
                var con = new ANIEM { ANIEMID = db.ANIEM.Count() + 1, NAZWA = radnowb(15), MEDIAID = random.Next(1, db.MEDIA.Count() - 1), SEZONID = random.Next(1, db.SEZON.Count() - 1), ILOSCODCINKOW = random.Next(511), TWORCAID = random.Next(1, db.TWORCA.Count() - 1), TAGIID = random.Next(1, db.TAGI.Count() - 1) };
                db.Add(con);
                string a = "insert into aniem(aniemID,mediaID,sezonID,tagiID,tworcaID,iloscodcinkow,nazwa)VALUES('" + con.ANIEMID + "','" + con.MEDIAID + "','" + con.SEZONID + "','" + con.TAGIID + "','" + con.TWORCAID + "','" + con.ILOSCODCINKOW + "','" + con.NAZWA + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdotom()
        {
            using (var db = new BloggingContext())
            {
                var con = new TOM { TOMID = db.TOM.Count() + 1, NRTOMU = random.Next(511), DLUGOSCTOMU = random.Next(111), ANIEMID = random.Next(1, db.ANIEM.Count() - 1) };
                db.Add(con);
                string a = "insert into tom(tomID,aniemID,nrtomu,dlugosctomu)VALUES('" + con.TOMID + "','" + con.ANIEMID + "','" + con.NRTOMU + "','" + con.DLUGOSCTOMU + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdoodcinki()
        {
            using (var db = new BloggingContext())
            {
                var con = new ODCINKI { ODCINKIID = db.ODCINKI.Count() + 1, NRODCINKA = random.Next(911), DLUGOSCODC = 21, ANIEMID = random.Next(1, db.ANIEM.Count() - 1) };
                db.Add(con);
                string a = "insert into odcinki(odcinkiID,dlugoscodc,ANIEMID,nazwaodcinka,nrodcinka)VALUES('" + con.ODCINKIID + "','" + con.DLUGOSCODC + "','" + con.ANIEMID + "','" + con.NAZWAODCINKA + "','" + con.NRODCINKA + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
        public static void dodajdoogladane()
        {
            using (var db = new BloggingContext())
            {
                var con = new OGLADANE { OGLADANEID = db.OGLADANE.Count() + 1, STATUSID = random.Next(1, db.STATUS.Count() - 1), UZYTKOWNIKID = random.Next(1, db.UZYTKOWNIK.Count() - 1), ODCINKIID = random.Next(1, db.ODCINKI.Count() - 1), ANIEMID = random.Next(1, db.ANIEM.Count() - 1), TOMID = random.Next(1, db.TOM.Count() - 1) };
                db.Add(con);
                string a = "insert into ogladane(ogladaneID,aniemID,odcinkiID,statusID,tomID,uzytkownikID)VALUES('" + con.OGLADANEID + "','" + con.ANIEMID + "','" + con.ODCINKIID + "','" + con.STATUSID + "','" + con.TOMID + "','" + con.UZYTKOWNIKID + "');\n";
                System.IO.File.AppendAllText("E:/baza danych/zadanie2/zadanie2/zadanie2/obj/Debug/inserty.txt", a);
                db.SaveChanges();
            }
        }
       
            static void Main(string[] args)
        {

              
                
                using (var db = new BloggingContext())
                {
                    int a, aa;

                    do
                    {
                        Console.WriteLine("Generacja komend insert do bazy danych\nwybierz tablice i ile insertow mam stworzyc\n1 Media\n2 Tagi\n3 Tworca\n4 Uzytkownik\n5 Status\n6 Sezon\n7 Aniem\n8 Tom\n9 Odcniki\n10 Ogladane\n0 do wszystkich ");
                        a = Int16.Parse(Console.ReadLine());
                        aa = Int16.Parse(Console.ReadLine());
                        wielkosc(a, aa);
                        Console.WriteLine("Zakonczylem dodawac\nczy checesz kontynuowac wcisnij ENTER");
                        if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {
                            break;
                        }
                        Console.Clear();

                    } while (true);
                }


            }
        } } 
    


