using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Collection_and_Exceptions_net7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                WriteLine("What do you want to do?" +
                    "\n0:Exit"+
                    "\n1:PlayWithArray"+
                    "\n2:PlayWithDictionary" +
                    "\n3:PlayWithStringList" +
                    "\n4:PlayWithStringBuilder" +
                    "\n5:RandomExamples" +
                    "\n6:AppendToNameStr" +
                    "\n7:TestString" +
                    "\n8:ArrayList" +
                    "\n9:List Capacity/Count" +

                    ""
                    );
                int action = GetIntFromUser();
                switch (action)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        PlayWithArray();
                        break;

                    case 2:
                        PlayWithDictionary();
                        break;

                    case 3:
                        PlayWithStringList();
                        break;

                    case 4:
                        PlayWithStringBuilder();
                        break;
                    
                    case 5:
                        RandomExamples();
                        break;
                    
                    case 6:
                        string myName = "Simon";
                        WriteLine(myName);
                        WriteLine(AppendToNameStr(myName));
                        break;
                    
                    case 7:
                        // StringBuilder is mutable, and can be changed by method.
                        StringBuilder strB = new StringBuilder("TestString");
                        AppendNameToStrBImmutable(strB);
                        WriteLine(strB);
                        break;
                    
                    case 8:
                        PlayWithArrayList();
                        break;
                         
                    case 9:
                        List<string> nameList = new List<string>();
                        WriteLine("Count:"+nameList.Count);
                        WriteLine("Capacity:" + nameList.Capacity);
                        for(int i = 0; i < 999999; i++)
                        {
                            nameList.Add("Tomas");

                        }
              
                        WriteLine("Count:" + nameList.Count);
                        WriteLine("Capacity:" + nameList.Capacity);
                        WriteLine("\n");

                        break;


                    default:
                        WriteLine("Default case, something went wrong");
                        break;
                }
            }
        }


        public class MyException : Exception {
            public string errorMessage;

            public MyException(string message)
            {
                this.errorMessage = message;
            }
        }

        static int GetIntFromUser()
        {
            int number = 0;
            bool success = false;
            do
            {
                try
                {
                    number = int.Parse(ReadLine());
                    if (number == 100)
                        throw new MyException("Wrong");
                    success = true;
                }
                catch(OverflowException)
                {
                    WriteLine("Your value is too big");
                }
                catch (ArgumentNullException)
                {
                    WriteLine("Could not parse, value was null");
                }
                catch (FormatException error)
                {
                    WriteLine(error.Message);

                    WriteLine("Wrong format");
                }
                catch(MyException error)
                {
                    WriteLine(error.errorMessage);
                    WriteLine("MyException");
                }

            } while (!success);

            return number;

        }
        
        public static void PlayWithArray()
        {
            WriteLine("Create an array. Add values to all the slots.");
            int[,] twoDimensionalArray = new int[10, 10];

            for(int x = 0; x < twoDimensionalArray.GetLength(0); x++)
            {
                for (int y = 0; y < twoDimensionalArray.GetLength(1); y++)
                {
                    twoDimensionalArray[x, y] = (x + 1) * (y +1);
                }
            }

            for (int x = 0; x < twoDimensionalArray.GetLength(0); x++)
            {
                for (int y = 0; y < twoDimensionalArray.GetLength(1); y++)
                {
                    WriteLine(twoDimensionalArray[x, y]);
                }
                WriteLine();
            }

            ReadKey();
        }

        public static void PlayWithDictionary()
        {
            WriteLine("Playing with dictionary - populationSweden");

            //Dictionary<string, int> populationSweden = new Dictionary<string, int>();
            //populationSweden.Add("Skövde", 45000);
            //populationSweden.Add("Göteborg", 10);
            //populationSweden.Add("Stockholm", 1337);
            //populationSweden.Add("Växjö", 654321);
            //populationSweden.Add("Örebro", 123456);


            //foreach (KeyValuePair<string, int> city in populationSweden)
            //{
            //    WriteLine(city.Key + " City has:" + city.Value + " population");
            //}


            Dictionary<string, string[]> books = new Dictionary<string, string[]>();
            string[] pages = new string[300];
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i] = "Hello, this is how you write a programming book. Page:" + i.ToString();
            }

            books.Add("C# PROGRAMMING", pages);

            foreach (KeyValuePair<string, string[]> book in books)
            {
                WriteLine(book.Key + " is the name of book. it has pages:");
                for (int j = 0; j < books[book.Key].Length; j++)
                {
                    WriteLine(books[book.Key][j]);
                }
            }
            ReadKey();
        }

        public static void PlayWithStringList()
        {
            WriteLine("Play With string List.");
            List<string> petNames = new List<string>();
            petNames.Add("Pez");
            petNames.Add("Moffe");
            petNames.Add(ReadLine());

            foreach(string pet in petNames)
            {
                WriteLine(pet);
            }

            string petname = petNames.Find(pet => pet.Equals("pez", StringComparison.OrdinalIgnoreCase));

            WriteLine("First instance of 'pez':"+petname);
        }

        public static void PlayWithStringBuilder()
        {
            WriteLine("Compareison between string and StringBuilder");
            string testSubjectString = "Lexicon";
            DateTime startString = DateTime.Now;
            WriteLine("Start String:" + startString);
            for(int i = 0; i < 200000; i++)
            {
                testSubjectString += "!";
            }
            DateTime endString = DateTime.Now;
            WriteLine("End string:"+(endString - startString));
            ReadKey();

            StringBuilder testSubjectSB = new StringBuilder("Lexicon");
            DateTime startSB = DateTime.Now;
            WriteLine("Start Stringbuilder:" + startSB);
            for (int i = 0; i < 200000; i++)
            {
                testSubjectSB.Append("!");
            }
            DateTime endSB = DateTime.Now;
            WriteLine("End StringBuilder:"+(endSB - startSB));
            ReadKey();

        }

        public static void RandomExamples()
        {
            Random rnd = new Random();
            string[] malePetNames =
            {"Rufus", "Bear", "Dakota", "Fido",
                          "Vanya", "Samuel", "Koani", "Volodya",
                          "Prince", "Yiska"};

            string[] femalePetNames =
            {"Maggie", "Penny", "Saya", "Princess",
                            "Abby", "Laila", "Sadie", "Olivia",
                            "Starlight", "Talla" };

            int nameIndex = rnd.Next(malePetNames.Length);
            WriteLine(malePetNames[nameIndex]);

            nameIndex = rnd.Next(femalePetNames.Length);
            WriteLine(femalePetNames[nameIndex]);

            //nameIndex = rnd.Next(-10, 2);
            //WriteLine(nameIndex);

        }

        public static string AppendToNameStr(string myname)
        {
            string myNameAppend = "Mitt namn:";
            myNameAppend += myname;
            return myNameAppend;
        }

        static void AppendNameToStrBImmutable(StringBuilder str)
        {
            string str1 = "Simon";
            str.Append(str1);
        }

        private static void PlayWithArrayList()
        {
            // Do not use ArrayList. Use List<>/Array[] instead
            ArrayList al = new ArrayList();
            al.Add(10);
            al.Add(10);
            al.Add(10);
            al.Add(10);
            //al.Add("10"); //Is ok.
            // al.Add(true); Is ok.
            foreach (int item in al)
            {
                WriteLine(item);
            }

        }
    }
}
