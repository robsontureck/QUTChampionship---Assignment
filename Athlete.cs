using System;
using static System.Console;

namespace QUTChampionship
{
    class Athlete
    {
        //Fields
        private char code;
        private string description;
        public static char[] codes = { 'T', 'B', 'S', 'R', 'G'};
        public static string[] categories = { "Tennis", "Badminton", "Swimming", "Running", "Gymnastics"}; 
        private char invalid = 'I';

        //Auto-implemented property
        public string name { get; set; }

        //Properties

        public char Code
        {
            get { return code; }
            set
            {
                int pos = -1;
                for (int c = 0; c < codes.Length; ++c)
                {
                    if (value == codes[c])  // checks if code is valid
                    {
                        code = value;
                        pos = c;
                        AssignDescription();
                    }
                }
                if (pos < 0)
                {
                    code = invalid;
                    AssignInvalidDescription();
                }
                
            }
        }

        public string Description
        {
            get { return description; }
        }

        public void AssignDescription()  // If code is valid assign a description from description array
        {
            for(int i =0; i<categories.Length; ++i)
            {
                if(code == codes[i])
                {
                    description = categories[i];
                }
            }
        }

        public void AssignInvalidDescription()
        {
            description = "Invalid entry";
        }

        //Methods

        public static void DisplayCategories()
        {
            WriteLine("\n-----------------------");
            WriteLine(" Valid Event Categories");
            WriteLine("-----------------------");
            WriteLine("Event Category | Code");
            WriteLine("-----------------------");
            for (int i = 0; i< codes.Length; ++i)
            {   
                WriteLine("{0,-10}     | {1,2}", categories[i], codes[i]);
                WriteLine("-----------------------");
            }
        }
  
    }
}
