using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using BusinessLogicLayer;
using Newtonsoft.Json;

namespace Test
{
    public class Program
    {
        //Input file location
        private const string InputFilePath = @"C:\Users\sairam\Documents\Test.txt";
        //"TestFiles/Input1.txt";

        /// <summary>
        /// some times data is not copied to output file then please use the commented link.
        /// Please create a document and give outputfile path in the below syntax.
        /// </summary>
        //output file location
        private const string OutputFilePath = @"C:\Users\sairam\Documents\Output.txt";
            //Environment.CurrentDirectory + "\\Output.txt"; 
            //"TestFiles/Output.txt";




        //Main Method
        public static void Main(string[] args)

        {

            Console.WriteLine("---Fligh summary---");
            Console.WriteLine("Please enter input file path(press enter to take default path);");
            var userInput = Console.ReadLine();
            var inputFilePath = string.IsNullOrEmpty(userInput) ? InputFilePath : userInput;

            Console.WriteLine("Please enter output file path(press enter to take default path);");

            userInput = Console.ReadLine();

            var outputFilePath = string.IsNullOrEmpty(userInput) ? OutputFilePath : userInput;


            using (var processor = new Processor())
            {
                //input data to object
                processor.FeedData(inputFilePath);
                //process output report
                processor.GenerateReport(outputFilePath);
            }
            
          
            Console.WriteLine("---Fligh summary is computed! Please check your file.---");
            Console.ReadLine();
        }

       
    }
}
