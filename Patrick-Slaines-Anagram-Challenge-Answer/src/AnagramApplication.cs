using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src
{
    public class AnagramApplication : Application
    {
        private FileAccess storageModifier;
        private List<UserInput> cache = new List<UserInput>();
        private ILogger logger;

        public AnagramApplication(FileAccess storageModifier,ILogger log)
        {
            this.storageModifier = storageModifier;
            this.cache =storageModifier.LoadFromFile();
            this.logger = log;
        }

        public override void RunApplication()
        {
            Console.WriteLine("Welcome to the Anagram Checker");
            bool exitApplication = true;
            while (exitApplication)
            {
                Console.WriteLine("Please enter a username");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter the first value");
                string valueOne = Console.ReadLine().ToLower().Trim();
                Console.WriteLine("Please enter the second value");
                string valueTwo = Console.ReadLine().ToLower().Trim();
                logger.Information("Input Received - Username: "+userName+ " - Value One: "+valueOne+" - Value Two: "+ valueTwo);
                if(valueOne.All(Char.IsLetter)==false || valueTwo.All(Char.IsLetter) == false)
                {
                    Console.WriteLine("Error, One or both values contains characters other than letters. \n Please only insert letter characers.");
                    logger.Error("Input Received - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - Error. One or both values contain characters other than letters.");
                }
                else
                {

                        UserInput foundElement = null;
                        foreach(UserInput input in cache){
                            if((input.inputValueOne==valueOne || input.inputValueOne==valueTwo)&& (input.inputValueTwo == valueOne || input.inputValueTwo == valueTwo))
                            {
                                foundElement = input;
                                logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - This input data was processed via Cache Storage");
                                break;

                            }
                        }
                        if (foundElement != null)
                        {
                        
                            if (foundElement.isAnagram == true)
                            {
                                logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - The input data is an Anagram.");
                                Console.WriteLine("The values you entered are Anagrams of each other.");
                            }
                            else
                            {
                                Console.WriteLine("The values you entered are not Anagrams of each other.");
                                logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - The input data is not an Anagram.");
                            }
                        }
                        else
                        {
                            bool isAnagram = checkForAnagram(valueOne, valueTwo);
                            logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - This input data was processed by isAnagram function");
                        if (isAnagram == true)
                            {
                                logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - The input data is an Anagram.");
                                Console.WriteLine("The values you entered are Anagrams of each other.");

                            }
                            else
                            {
                                Console.WriteLine("The values you entered are not Anagrams of each other.");
                                logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - The input data is not an Anagram.");
                            }
                            UserInput newInput = new UserInput(userName, valueOne, valueTwo, isAnagram);
                            cache.Add(newInput);
                        logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - This input data was added to cache storage");
                        storageModifier.WriteToFile(newInput);
                        logger.Information("Input Values - Username: " + userName + " - Value One: " + valueOne + " - Value Two: " + valueTwo + " - This input data was added to file storage");
                    }
                    }

                  
                }
            }

        

        public bool checkForAnagram(string valueOne, string valueTwo)
        {
            /*Method checks if Two Strings are an Anagram of each other
             *  1. Converts both strings to character arrays
             *  2. Sorts both character arrays in ascending order
             *  3. Converts character arrays back to strings
             *  4. Compare the strings to see if they are equal
             *   - If they are equal, the words are an anagram of each other, return true
             *   - Else, return false
             *   
             *   Try/Catch, returns false if a NullReferenceExceptionIsReceived
             */
            try
            {


                char[] charOne = valueOne.ToLower().ToCharArray();
                char[] charTwo = valueTwo.ToLower().ToCharArray();

                Array.Sort(charOne);
                Array.Sort(charTwo);

                string newValueOne = new String(charOne);
                string newValueTwo = new String(charTwo);
                if (newValueOne.Equals(newValueTwo))
                {
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
       
    }
}
