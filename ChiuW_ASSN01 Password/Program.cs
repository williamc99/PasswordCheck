
/************************************************************
    PROGRAMME	:	ASSN01 Password Checking

    OUTLINE		:	This programme will ask the user to input a password. 
    The programme will then check if the password is at least 8 chracters and 
    includes at least 1 number, uppercase letter, and special character.  It also makes
    sure there are no spaces. If the password is successful, it will be written to a textfile.

    PROGRAMMER	:	William Chiu

    DATE		:	March 4, 2020
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ChiuW_ASSN01_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string input;
            bool lengthCheck = true, numCheck = true, upperCheck = true, specialCheck = true, spaceCheck = true;
            string[] inputArray = new string[1];

            Console.Title = "ASSN01 Password Checking";
            Console.ForegroundColor = ConsoleColor.Yellow;
            StreamWriter fil = new StreamWriter("passwords.txt");

            while (true)
            {
                Console.Write("\n\tEnter Password: ");
                input = Console.ReadLine();

                if (Regex.Match(input, "^(?=.{8})").Success)
                    lengthCheck = false;
                else              
                    Console.Write("\n\tInvalid password length: Minimum 8 characters!");

                if (!Regex.Match(input, "[/ /]+").Success)
                    spaceCheck = false;
                else
                    Console.Write("\n\tCannot have white space as a character!");
                              
                if (Regex.Match(input, "[A-Z]+").Success)
                    upperCheck = false;
                else
                    Console.Write("\n\tPassword needs at least 1 uppercase letter!");                 

                if (Regex.Match(input, "[0-9]+").Success)
                    numCheck = false;
                else
                    Console.Write("\n\tPassword needs at least 1 number!");

                if (Regex.Match(input, "[/!@#$%^&*/]+").Success)
                    specialCheck = false;
                else
                    Console.Write("\n\tPassword needs at least 1 special character!");

                Console.WriteLine(" ");
                Array.Resize<string>(ref inputArray, (count + 1));
                inputArray[count] = input;               
                count++;

                if (lengthCheck == false && upperCheck == false && numCheck == false && specialCheck == false && spaceCheck == false)
                {
                    Console.WriteLine("\n\tPassword input succesful!");
                    break;
                }
                else
                {
                    spaceCheck = true;
                    lengthCheck = true;
                    upperCheck = true;
                    numCheck = true;
                    specialCheck = true;
                    continue;
                }
            }

            Console.WriteLine("\n\tPASSWORDS ENTERED:");
            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.Write("\n\t" + inputArray[i]);
                fil.Write("\n\t" + inputArray[i]);
            }

            fil.Close();
            Console.ReadKey();           
        }
    }
}