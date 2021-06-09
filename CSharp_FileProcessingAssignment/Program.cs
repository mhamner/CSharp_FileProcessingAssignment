using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp_FileProcessingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user for their name
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();

            List<string> funFacts = new List<string>();

            //Ask for 5 fun facts
            for(int i = 0; i < 5; i++)
            {
                //I'm listing (i+1) on the screen because it would be weird to ask the user for "Fun Fact # 0" :)
                Console.WriteLine($"What is Fun Fact # {(i+1).ToString()}?");
                funFacts.Add(Console.ReadLine());
            }

            //Get the path to the Desktop folder using GetFolderPath
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Use StreamWriter to write the Fun Facts to the output file
            using (StreamWriter sw = new StreamWriter(Path.Combine(filePath, $"Fun Facts About {userName}.txt")))
            {
                foreach (string fact in funFacts)
                {
                    sw.WriteLine(fact);
                }
            }
           
            string lineFromFile;

            try
            {
                //Let's read from the file we just created
                using (StreamReader sr = new StreamReader(Path.Combine(filePath, $"Fun Facts About {userName}.txt")))
                {
                    Console.WriteLine("Your fun facts are:");
                    //Loop through the file and read line by line, and write that line to the Console
                    while ((lineFromFile = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(lineFromFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured during reading the file.  The error was: {ex.Message}.");
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
