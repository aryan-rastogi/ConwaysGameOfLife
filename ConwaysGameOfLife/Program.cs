using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
Namespace: ConwaysGameOfLife
ClassName: Program
Description: Program creates a grid using user inputs. From there it populates the grid with cells that are either dead or alive.
             From there it plays Conway's Game Of Life simulation using the created grid for a specified number of generations, 
             displaying the new grid each generation.
Name: Aryan Rastogi
Date: April 9th 2020
Notes:
*/

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test test = new Test();

            // Creating variables to hold the dimensions of the grid
            int numRows = 0, numColumns = 0;

            //Creating a boolean to help work through exception handling by checking if the input is valid
            Boolean checker = false;

            //Asking how many rows the user wants. 
            //If the input is invalid then the catch returns a message telling the user to try again
            Console.WriteLine("How many rows do you want? Your input must be greater than 0.");
            while (checker == false)
            {
                try
                {
                    numRows = Convert.ToInt32(Console.ReadLine());
                    if (numRows > 0)
                    {
                        checker = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Input an integer greater than 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Please try again: ");
                }
            }

            //Making the checker false so that it can be used for the columns
            checker = false;

            //Asking how many columns the user wants. 
            //If the input is invalid then the catch returns a message telling the user to try again
            Console.WriteLine("How many columns do you want? Your input must be greater than 0");
            while (checker == false)
            {
                try
                {
                    numColumns = Convert.ToInt32(Console.ReadLine());
                    if (numColumns > 0)
                    {
                        checker = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Input an integer greater than 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Please try again: ");
                }
            }

            //Initializing a new grid. This will be used to run the game of life
            Grid primaryArray = new Grid(numRows, numColumns);

            //Printing the initial grid.
            Console.WriteLine("Here is your intial grid! Generation 0:");
            primaryArray.DisplayGrid();

            //Making the checker variable false so that it can be used again
            checker = false;

            //Creating a variable to determine how many times the game will be played. 
            //If the user inputs something invalid, the console will return a message and then make them try again
            int repeatNumber = 0;
            while (checker == false)
            {
                try
                {
                    Console.WriteLine("How many times do you want the program to run? You must input a number greater than zero.");
                    repeatNumber = Convert.ToInt32(Console.ReadLine());
                    if (repeatNumber > 0)
                    {
                        checker = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Input an integer greater than 0");
                    }
                }
                catch
                {
                    Console.Write("Input is invaid. Please enter an integer: ");
                }
            }

            //This loop runs as many times as the user wanted the program to run
            for (int i = 0; i < repeatNumber; i++)
            {
                // This chunk of code checks, evaluates, and switches the grid to its next generation using methods, then prints it
                //Console.Clear();
                primaryArray.NextGeneration();
                Console.WriteLine("Here is generation number: " + (i + 1));
                primaryArray.DisplayGrid();
                Console.ReadLine();
                Thread.Sleep(300);
            }

            //Wishing the user farewell.
            Console.WriteLine("Thank you for using the program!");
            Console.ReadLine();
        }
    }
}
