using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
Namespace: ConwaysGameOfLife
ClassName: Test
Description: The test class tests various methods and classes by running them with good and bad data
Name: Aryan Rastogi
Date: April 9th 2020
Notes:
*/

namespace ConwaysGameOfLife
{
    class Test
    {
        public Test()
        {
            this.TestGrid();
            this.TestCell();

        }

        public void TestGrid()
        {   // bad data test - should return an error
            try
            {
                Grid grid = new Grid(-2, -2);
                grid.DisplayGrid();
                grid.NextGeneration();
                Console.WriteLine();
                grid.DisplayGrid();
                Console.WriteLine("Test Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // good data test - should work completely fine
            try
            {
                Grid grid = new Grid(10, 10);
                grid.DisplayGrid();
                grid.NextGeneration();
                Console.WriteLine();
                grid.DisplayGrid();
                Console.WriteLine("Test Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

            // big data test - should return a grid without proper rows and columns, essentially a sea of numbers
            try
            {
                Grid grid = new Grid(200, 200);
                grid.DisplayGrid();
                grid.NextGeneration();
                Console.WriteLine();
                grid.DisplayGrid();
                Console.WriteLine("Test Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void TestCell()
        {

            Cell[,] main = new Cell[5, 5];
            Cell[,] transfer = new Cell[5, 5];

            try
            {
                //bad data test - should return error  
                main[2, 2].CheckNeighbours(main, transfer);
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine(main[2, 2].neighboursStatus[i]);
                }
                Console.WriteLine();
                Console.WriteLine(transfer[2, 2].GetStatus());
                Console.WriteLine("Test Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        main[i, j] = new Cell(1, i, j);
                        transfer[i, j] = new Cell(1, i, j);
                    }
                }

                // checking whether CheckNeighbours works
                main[2, 2].CheckNeighbours(main, transfer);
                for (int i = 0; i < 8; i++)
                {
                    //Should be (1,1,1,1,1,1,1,1) - checking if correct neighbour status is printed
                    Console.WriteLine(main[2, 2].neighboursStatus[i]);

                }
                Console.WriteLine();
                //Should be 0 - checking whether the cell's status changes
                Console.WriteLine(transfer[2, 2].GetStatus());
                Console.WriteLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try { 
            //Testing LiveOrDie using different conditions
                Cell alive = new Cell(1, 3, 3);
                Cell dead = new Cell(0, 3, 3);
                Console.WriteLine(alive.LiveOrDie(1));
                Console.WriteLine(alive.LiveOrDie(2));
                Console.WriteLine(alive.LiveOrDie(3));
                Console.WriteLine(alive.LiveOrDie(4));
                Console.WriteLine(dead.LiveOrDie(1));
                Console.WriteLine(dead.LiveOrDie(3));
                Console.WriteLine(dead.LiveOrDie(4));
                // Should print (0,1,1,0,0,1,0)

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //Testing LiveOrDie using bad data - will return incorrect values
                Cell alive = new Cell(3, 3, 3);
                Cell dead = new Cell(3, 3, 3);
                Console.WriteLine(alive.LiveOrDie(1));
                Console.WriteLine(alive.LiveOrDie(2));
                Console.WriteLine(alive.LiveOrDie(3));
                Console.WriteLine(alive.LiveOrDie(4));
                Console.WriteLine(dead.LiveOrDie(1));
                Console.WriteLine(dead.LiveOrDie(3));
                Console.WriteLine(dead.LiveOrDie(4));
                // Should print (0,0,0,0,0,0,0)

                // Bad Data - will return 0 if negative number of neighbours
                Console.WriteLine(alive.LiveOrDie(-5));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
