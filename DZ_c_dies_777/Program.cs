using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using static DZ_c_dies_777.Program;

namespace DZ_c_dies_777
{
    internal class Program
    {
        public class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }

        }
        public class Product
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }
        public class DataStorage<T>
        {
            public List<T> LLList = new List<T>();
            public void AddData(T data)
            {
                LLList.Add(data);
            }
            public void RemoveData(T data)
            {
                LLList.Remove(data);
            }
            public bool ContainsData(T data)
            {
                return LLList.Contains(data);
            }
            public void PrintData()
            {
                string json = JsonConvert.SerializeObject(LLList, Formatting.Indented);
                Console.WriteLine(json);

            }


        }
        public class Student
        {
            public string ?Name { get; set; }
            public int Age { get; set; }
            public string ?Gender { get; set; }
            public string ?Major { get; set; }
            public List<string> ?Subjects { get; set; }

            public void Mostrare()
            {
                Console.WriteLine(" Имя " + Name + "\n Возраст " + Age + "\n Пол " + Gender + "\n Специальность " + Major + "\n Предметы : ");
                foreach(var i in Subjects)
                {
                    Console.Write(i+"  ");
                   
                }
                Console.WriteLine("\n");
            }
        }
        static void Main(string[] args)
        {
            // Задача 1
            Person ppp1 = new Person { Name = "AAA", Age = 54 };
            Person ppp2 = new Person { Name = "BBB", Age = 34 };
            Person ppp3 = new Person { Name = "CCC", Age = 22 };
            Product rrr1 = new Product { Name = "fff", Price = 4000 };
            Product rrr2 = new Product { Name = "ddd", Price = 5600 };
            Product rrr3 = new Product { Name = "nnn", Price = 3333 };
            DataStorage<Person> DS1 = new DataStorage<Person>();
            DS1.AddData(ppp1);
            DS1.AddData(ppp2);
            DS1.AddData(ppp3);
            DS1.RemoveData(ppp2);
            Console.WriteLine(DS1.ContainsData(ppp2));
            DS1.PrintData();
            DataStorage<Product> DS2 = new DataStorage<Product>();
            DS2.AddData(rrr1);
            DS2.AddData(rrr2);
            DS2.AddData(rrr3);
            DS2.PrintData();


            // Задача 2
            List<Student> LISTA = new List<Student> {

                 new Student{ Name="Андрей",Age=17,Gender="Male",Major="proger",Subjects=new List<string>{ "biolog","info","mat"} } ,
                 new Student{ Name="Катя",Age=18,Gender="Female",Major="math",Subjects=new List<string>{ "biolog"} } ,
                 new Student{ Name="Ибрагим",Age=22,Gender="Male",Major="proger",Subjects=new List<string>{ "biolog","info","mat","phisic"} } ,
                 new Student{ Name="Мурат",Age=23,Gender="Male",Major="math",Subjects=new List<string>{ "biolog","info"} } ,
                 new Student{ Name="Афанасий",Age=19,Gender="Male",Major="phisic",Subjects=new List<string>{ "info","mat"} } ,
                 new Student{ Name="Мирослава",Age=26,Gender="Female",Major="phisic",Subjects=new List<string>{ "biolog","info","mat"} } ,
                 new Student{ Name="Анна",Age=16,Gender="Female",Major="economist",Subjects=new List<string>{ "info","mat"} } ,
                 new Student{ Name="Ариель",Age=21,Gender="Female",Major="proger",Subjects=new List<string>{"info","mat","algorithm","data base"} } ,
                 new Student{ Name="Стефания",Age=27,Gender="Female",Major="proger",Subjects=new List<string>{ "info","mat"} } ,
                 new Student{ Name="Валерий",Age=18,Gender="Male",Major="proger",Subjects=new List<string>{ "info","mat"} }
          }
                ;
            foreach(var DDD in LISTA)
            {
                DDD.Mostrare();
            }
            Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][][][]\n");
            var LISTATA = LISTA.Where(s => s.Gender=="Male").Select(s => s);
            foreach (var DDDAD in LISTATA)
            {
                DDDAD.Mostrare();
            }
            Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][][][]\n");
            var LISTATARATA = LISTA.Where(s => s.Age >= 20 && s.Age <= 25).Select(s => s);
            foreach (var DDRA in LISTATARATA)
            {
                DDRA.Mostrare();
            }
            Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][][][]\n");
            SortedSet<string> MAJOR = new SortedSet<string>();
            foreach (var MA in LISTA)
            {
                MAJOR.Add(MA.Major);
            }
            foreach (var MAJ in MAJOR)
            {
                Console.WriteLine("Специальность " + MAJ + " кол-во студентов : " +
                    (from i in LISTA where i.Major == MAJ select i).Count());
            }
            Console.WriteLine("\n[][][][][][][][][][][][][][][][][][][][][][][][][]\n");
            SortedSet<string> SUB = new SortedSet<string>();
            foreach (var S in LISTA)
            {
                foreach(var SU in S.Subjects)
                {
                    SUB.Add(SU);
                }
            }
            foreach(var SSS in SUB)
            {
                Console.Write(SSS + "   ");
            }
            Console.WriteLine("\n\n[][][][][][][][][][][][][][][][][][][][][][][][][]\n");
            var LISTOPA = LISTA.Max(s => s.Subjects.Count());
            var LISTOPAD = LISTA.Where(s => s.Subjects.Count()==LISTOPA).Select(s => s);

            foreach(var LL in LISTOPAD)
            {
                LL.Mostrare();
            }
        }
    }
}