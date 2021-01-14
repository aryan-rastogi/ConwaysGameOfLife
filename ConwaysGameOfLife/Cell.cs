using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Namespace: ConwaysGameOfLife
ClassName: Cell
Description: This class outlines the cells that make up the grid. Each cell has a status(dead or alive, represented by 0 or 1 
             respectively)as well as variables for its place within the grid and the statuses of its neighbours. In addition to setters 
             and getters, there are a variety of other methods. These are used to check the status of the cell's neighbours, determine 
             whether the cell will be dead or alive in the next generation, and then put the new status of the cell into the grid.
Name: Aryan Rastogi
Date: April 9th 2020
Notes:
*/

namespace ConwaysGameOfLife
{
    class Cell
    {
        //Initializing variables 
        private int status; // can be one or zero
        // Indicate position of individual cell within the grid
        private int rowLocation;
        private int columnLocation;
        //This array holds the statuses of the cell's immediate neighbours 
        public int[] neighboursStatus = new int[8];


        /* 
        This overloaded initializer is used to create the cells within the grid. It takes in 3 integer inputs. The first is set to the 
        cell's current status, while the second and third become the row and column locations respectively. The method also fills in the
        neighbourstatus array with (dead) placeholders for before it is filled.
        */
        public Cell(int status, int i, int j)
        {
            SetStatus(status);
            SetRowLocation(i);
            SetColumnLocation(j);
            for (int x = 0; x < 8; x++)
            {
                this.neighboursStatus[x] = 0;
            }
        }

        // A setter method for a cell's status
        public void SetStatus(int status)
        {
            this.status = status;
        }

        // A getter method for a cell's status
        public int GetStatus()
        {
            return this.status;
        }

        // A setter method for a cell's row location
        public void SetRowLocation(int row)
        {
            this.rowLocation = row;
        }

        // A getter method for a cell's row location
        public int GetRowLocation()
        {
            return this.rowLocation;
        }

        // A setter method for a cell's column location
        public void SetColumnLocation(int column)
        {
            this.columnLocation = column;
        }

        // A getter method for a cell's column location
        public int GetColumnLocation()
        {
            return this.columnLocation;
        }

        /*
        This method is used to check the status of a cell's neighbours, find the value for that cell in the next generation, and then 
        place that value into the same cell in the placeholder array (transfer array). It requires two cell array inputs. The first is 
        the mainarray, which it uses to determine the neighbours and new status for that cell. It also takes in the transfer array, 
        which is whereit stores the new status.
        Last Modified: April 8th 2019
        */
        public void CheckNeighbours(Cell[,] main, Cell[,] transfer)
        {
            // These lines use the GetNeighbourStatus function to check the cell's neighbour in each direction, which are indicated by the
            // two numbers they take. They also take in the main array in order to check the neighbouring cell in the current generation.

            this.neighboursStatus[0] = GetNeighbourStatus(-1, -1, main);
            this.neighboursStatus[1] = GetNeighbourStatus(-1, 0, main);
            this.neighboursStatus[2] = GetNeighbourStatus(-1, 1, main);
            this.neighboursStatus[3] = GetNeighbourStatus(0, -1, main);
            this.neighboursStatus[4] = GetNeighbourStatus(0, 1, main);
            this.neighboursStatus[5] = GetNeighbourStatus(1, -1, main);
            this.neighboursStatus[6] = GetNeighbourStatus(1, 0, main);
            this.neighboursStatus[7] = GetNeighbourStatus(1, 1, main);

            // This variable holds the number of alive (status = 1) neighbours the cell has
            int aliveNeighbours = 0;

            // This for loops goes through the neighboursStatus array. Each time an indice has a value of 1, it adds to the aliveNeighbours
            // variable.
            for (int i = 0; i < neighboursStatus.Length; i++)
            {
                if (neighboursStatus[i] == 1)
                {
                    aliveNeighbours += 1;
                }
            }

            // This line determines the new status of the cell using the LiveOrDie function and then puts it into cell in the transfer array
            // with the same row and column location (making it the "same" cell). 
            transfer[this.GetRowLocation(), this.GetColumnLocation()].SetStatus(this.LiveOrDie(aliveNeighbours));

        }

        /*
        This method is used to determine the status of a cell's neighbour. It takes in three inputs. The first and second (x and y)
        indicate which neighbour is being checked, by adding(subtracting if negative) that value to the cell's row and column locations.
        It also takes in a cell array which it uses to check the neighbour's status. It then returns an integer holding the neighbour's
        status.
        Last Modified: April 8th 2019
        */
        public int GetNeighbourStatus(int x, int y, Cell[,] cellArray)
        {
            // Creating a variable to hold what the new status will be
            int status = 0;

            /* 
            This try-catch is necessary in order to prevent the method from checking a value that doesn't exist in the array, which would
            return an error. If the error is reached, the try-catch prevents it from stopping the program by just bypassing that direction.
            It doesn't print an error message because that isn't something that should be printed to the console. Directions in which an 
            error would occur return zero (a dead status) which wouldn't effect the count of living neighbours.
            */
            try
            {
                status = cellArray[this.GetRowLocation() + x, this.GetColumnLocation() + y].GetStatus();
            }
            catch { };
            return status;
        }

        /*
        This method checks a cell against the rules of Conway's Game of Life. It takes in one integer input for the number of living 
        neighbours the cell has. It then uses this as well as the cell's current status to determine the new status of the cell in the 
        next generation. It ends by returning the new status.
        Last Modified: April 8th 2019
        */
        public int LiveOrDie(int aliveNeighbours)
        {
            // Creating a  variable to hold the new status
            int newStatus = 0;

            // If the cell is living and has two or three neighbours, it remains alive.
            if (this.GetStatus() == 1 && (aliveNeighbours == 2 || aliveNeighbours == 3))
            {
                newStatus = 1;
            }

            // If the cell is dead and has three neighbours, it comes alive.
            if (this.GetStatus() == 0 && aliveNeighbours == 3)
            {
                newStatus = 1;
            }

            return newStatus;
        }
    }
}
