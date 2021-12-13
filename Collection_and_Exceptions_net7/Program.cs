using System;
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
    }
}
