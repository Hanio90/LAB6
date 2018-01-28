using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB6
{
    class Program
    {
        static void Main(string[] args) 
        {
            //Declaration
            bool confirm = true; 
            var regEx = new Regex("^[A-Za-z,!'?]"); 
            string response;

            Console.WriteLine("Hello! WELCOME TO THE PIG LATIN TRANSLATER! ");
            Console.WriteLine("============================================\n");
            
            while (confirm)
            {
                Console.WriteLine("Enter a sentence to convert to PigLatin:");
                string userInput = Console.ReadLine();

                //checking to see if the input matches the regex
                if (regEx.IsMatch(userInput))
                {
                    string pigLatin = ToPigLatin(userInput);

                    Console.WriteLine(pigLatin);

                    Console.WriteLine("Would you like to translate another sentence? Y/N"); // promting the user if they wuld like to translate again
                     response = Console.ReadLine();

                }
                // validating if it is an accepted string to translate
                else
                {
                    Console.WriteLine("Your sentence cannot contains numbers or special character. Would you like to translate another sentence? Y/N");
                     response = Console.ReadLine();
                }
                
                var list = new List<string>() { "yes", "no", "y", "n" };
                bool isValid = true;
               
                //validation 
                if (!list.Contains(response.ToLower()))
                    isValid = false;

                if (response.ToLower() == "no" || response.ToLower() == "n")
                    confirm = false;
                    
                // validating that the user is entering a valid response
                while (!isValid)
                {
                    Console.WriteLine("please enter a valid response");
                    string answer = Console.ReadLine();

                    if (answer.ToLower() == "n" || answer.ToLower() == "no")
                    {
                        isValid = true;
                        confirm = false;
                    }
                    else if (answer.ToLower() == "y")
                    {
                        isValid = true;
                        confirm = true;
                    }
                    
                }

            }
        }
        public static string ToPigLatin(string userInput) // Method to call
        {
            string vowels = "AEIOUaeio";
            // creating an instance of object (String) called new words
            List<string> newWords = new List<string>();
            //For each word in the user input execute this code 
            foreach (string word in userInput.Split(' ')) // This statment is spliiting each word in the string and making each word an object.
            {
                //what the substring is doing is taking the first object and extracting the first letter which is in index zero and is stopping at index one
                string firstLetter = word.Substring(0, 1);
                // this substring is taking the rest of the object which starts at index one 
                // Then it takes the orignal length of the word and decrements by 1 index 
                // so im taking the rest of the word and storing it in the value in a varible( Restofword)
                string restOfWord = word.Substring(1, word.Length - 1);
                // checking if the first word contains a vowel

                bool currentLetter = vowels.Contains(firstLetter);

                //if the first letter is a vowel it will add way to the end of the word
                if (currentLetter)
                {
                    newWords.Add(word + "way");
                }
                //If the word doesnt start with a vowel, this code will put the first letter at the end of the rest of the word and then add ay
                else
                {
                    newWords.Add(restOfWord + firstLetter + "ay");
                    
                }
            }
            // this is returning the objects that were created by the ' ' as a new string.
            return string.Join(" ", newWords);
        }
    }
}
