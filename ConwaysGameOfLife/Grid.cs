using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Namespace: ConwaysGameOfLife
ClassName: Test
Description: The grid class consists of the grid that the Game of Life is played within. It contains two cell arrays and two integers. 
             The two integers represent the number of rows and columns in the grid. The two cell arrays hold the cells: the first 
             contains the current generation of the cells and their statuses, while the second holds onto the next generation before 
             they are updated. The class contains setters and getters for each of the integer variables, along with methods to randomly 
             populate the array, display the values in the grid, and to change the grid to the next generation.
Name: Aryan Rastogi
Date: April 9th 2020
Notes:
*/

namespace ConwaysGameOfLife
{
    class Grid
    {
        // Creating two cell arrays. The first holds the current values each cell in the grid, while the second acts as a placeholder
        // for the cells' statuses before the grid switches to the next generation
        private Cell[,] mainArray;
        private Cell[,] transferArray;

        // These two integers hold the number of rows and columns the grid has
        private int rows;
        private int columns;

        // This random is used to generate random values for the status of each cell in the grid
        Random r = new Random();

        /*
        This overloaded initializer for a grid is used to create the grid used in the game of life. It takes in two values, which 
        correspond with the dimensions of the grid. It uses these values to run the SetDimensions function for the grid. It also 
        randomly populates the grid using the PopulateRandom function.
        */
        public Grid(int dimensionX, int dimensionY)
        {
            this.SetDimensions(dimensionX, dimensionY);
            this.PopulateRandom();
        }

        /*
        This method sets the dimensions(rows and columns) of the grids, which are reflected in the two cell arrays. It also defines
        the number of the rows and columns in the two arrays. 
        Last Modified: April 8th 2019
        */
        public void SetDimensions(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.mainArray = new Cell[rows, columns];
            this.transferArray = new Cell[rows, columns];
        }

        // A getter method for the number of rows in the grid
        public int GetRows()
        {
            return this.rows;
        }

        // A getter method for the number of columns in the grid
        public int GetColumns()
        {
            return this.columns;
        }

        /*
        This method randomly populates the two arrays. It uses the two for loops to navigate through the rows and columns of the grid.
        It then generates a random value of 0 or 1 in order to initalize that cell.
        Last Modified: April 8th 2019
        */
        public void PopulateRandom()
        {
            try
            {
                for (int i = 0; i < this.GetRows(); i++)
                {
                    for (int j = 0; j < this.GetColumns(); j++)
                    {
                        // Generating random number of either 0 or 1
                        int val = r.Next(0, 2);

                        // Initializing the cells in both arrays.
                        this.mainArray[i, j] = new Cell(val, i, j);
                        this.transferArray[i, j] = new Cell(val, i, j);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // This method prints out the values of each cell in the grid
        // Last Modified: April 8th 2019
        public void DisplayGrid()
        {
            {
                for (int i = 0; i < this.GetRows(); i++)
                {
                    for (int j = 0; j < this.GetColumns(); j++)
                    {
                        Console.Write(this.mainArray[i, j].GetStatus() + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        /*
        This method is used to move into the next generation of the grid. It takes no inputs and does not return any values. It just
        changes the arrays. First it determines the new status of each cell and puts it into the corresponding value in the transfer 
        array using CheckNeighbours(). It then sets that status as the status of the cell in the main array.
        Last Modified: April 8th 2019
        */
        public void NextGeneration()
        {
            // This foreach loop runs the CheckNeighbours function for each cell in the main array. This means that it will determine
            // the cell's new status and put it in the transfer array.
            foreach (Cell bacteria in this.mainArray)
            {
                this.mainArray[bacteria.GetRowLocation(), bacteria.GetColumnLocation()].CheckNeighbours
                    (this.mainArray, this.transferArray);
            }

            // This double for loop puts all the values from the transfer array and puts them into the main array, effectively creating 
            // the new generation.
            for (int i = 0; i < this.GetRows(); i++)
            {
                for (int j = 0; j < this.GetColumns(); j++)
                {
                    this.mainArray[i, j].SetStatus(this.transferArray[i, j].GetStatus());
                }
            }
        }
    }
}
