using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace QUTChampionship
{
    class QutChampionshipApp
    {
        static void Main()
        {
            DisplayStudentNumber();
            // a.
            NumberOfParticipants(out int participants);
            
            // b/
            DisplayRevenue(participants); 
           
            //Create instances
            Athlete[] athletes = new Athlete[participants];  // Create array of athletes

            // c.
            for(int i = 0; i<athletes.Length; ++i)
            {
                athletes[i] = new Athlete();
                athletes[i].name = AskForAthleteName(i);
                athletes[i].Code = AskForAthleteCode(i);
            }
            
            //Calling methods
            // d.
            DisplayAllAthletes(athletes);  // Display information of all participants

            // e.
            DisplayAthletesinCategory(athletes); // Display participants in category entered by user

        }

        //Methods

        static void DisplayStudentNumber()
        {
            WriteLine("Program create by N11416289\n");
        }

        static void NumberOfParticipants(out int participants)  // Ask user for number of participants
        {
            Write("Please enter the number of participants in this year's championship: ");
            while (!(int.TryParse(ReadLine(), out participants)) || participants < 0 || participants > 30)  //Ask user for number of athletes and only accepts valid numbers
            {
                Write("Please enter a valid number between 0 and 30: ");
            }

        }
        static void DisplayRevenue(int participants)  // Calculate and display revenue
        {
            const int cost = 20;
            WriteLine("\n------------------------------------------------------------------");
            WriteLine("The championship have {0} participants and the revenue is {1}", participants, (participants * cost).ToString("C"));
            WriteLine("------------------------------------------------------------------");
        }

        static string AskForAthleteName(int i)  // Prompt user for athlete name
        {
            Write("\nPlease enter athlete {0} name: ", i+1);
            string name = ReadLine();
            return name;
        }

        static char AskForAthleteCode(int i)  // Prompt user for athlete code and display valid codes 
        {
            char code;
            Athlete.DisplayCategories();
            Write("\nPlease enter athlete's {0} code: ", i+1);
            while (!(char.TryParse(ReadLine(), out code)))
            {
                Write("\nPlease enter a valid code for athlete {0}: ", i+1);
            }
            return code;

        }

        static void DisplayAllAthletes(Athlete[] athletes)  // Display all participants information
        {
            WriteLine("\n--------------------------------");
            WriteLine("     All Participants");
            WriteLine("--------------------------------");
            WriteLine("{0,-10} | {1,-5} | {2,5}", "Name", "Code", "Description");
            for (int i = 0; i < athletes.Length; ++i)
            {
                WriteLine("--------------------------------");
                WriteLine("{0,-10} |  {1,-5}|  {2,5} ", athletes[i].name, athletes[i].Code, athletes[i].Description);
            }
        }

        static void DisplayAthletesinCategory(Athlete[] athletes)  // Display participants in category entered by user
        {
            char STOP = '!';
            int pos = -1;
            char pCode;
            Athlete.DisplayCategories(); // Display valid categories and events 
            Write("Please enter an event code or '!' to exit: "); 
            while (!(char.TryParse(ReadLine(), out pCode)))
            {
                WriteLine("\nInvalid code, please try again!");
                Write("\nPlease enter an event code or '!' to exit: ");
            }
            while (pCode != STOP)
            {
                for(int c = 0; c < Athlete.codes.Length; ++c)
                {
                    if(pCode == Athlete.codes[c])
                    {
                        pos = c;
                    }
                }
                if(pos>=0)
                {
                    WriteLine("\n--------------------------------");
                    WriteLine("    Athletes in {0} category", Athlete.categories[pos]);
                    WriteLine("--------------------------------");
                    WriteLine("{0,-10} | {1,-5} | {2,5}", "Name", "Code", "Description");
                    for (int i = 0; i < athletes.Length; ++i)
                        if(athletes[i].Code == pCode)
                        {
                       
                            WriteLine("--------------------------------");
                            WriteLine("{0,-10} |  {1,-5}|  {2,5} ", athletes[i].name, athletes[i].Code, athletes[i].Description);
                        }
                }
                else if(pos<0)
                {
                    WriteLine("\nInvalid code, please try again!");
                }
                pos = -1;
                Write("\nPlease enter an event code or '!' to exit: ");
                while (!(char.TryParse(ReadLine(), out pCode)))
                {
                    WriteLine("\nInvalid code, please try again!");
                    Write("\nPlease enter an event code or '!' to exit: ");
                }

            }
            

        }


    }
}
