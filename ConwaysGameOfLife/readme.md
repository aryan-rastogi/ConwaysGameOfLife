Conway's Game of Life
This program is a simulation of cells (bacteria) within a grid using the rules presented by Conway's Game of Life.
To use this program, you must: 
	- enter an integer greater than 0 for how many rows are in the grid
	- enter an integer greater than 0 for how many columns are in the grid
	- enter an integer greater than 0 for how many generations you want the program to display
The program will then display that number of generations for you to observe

A living cell is denoted by a 1, while a dead cell is denoted by a 0
Conway's Game of Life follows the following rules:
1. A live cell with less than 2 neighbors will die  
2. A live cell 2 or 3 neighbors stays alive 
3. A live cell with less than neighbors will die 
4. An empty cell with EXACTLY 3 neighbors will come to life

For example: observe the following grid
1 1 1 0              1 0 1 0  
1 1 0 0    would     0 0 1 0
1 0 0 0    become    1 1 0 0
0 0 0 1              0 0 0 0 

The bottom-right cell died because it was alive and had no alive neighbours
The leftmost cell in the second row died since it was alive and had more than 3 living neighbours
The second cell in the third row came to live since it was dead and had three neighbours
The third cell in the top row stayed alive since it was alive and had two neighbours
The third cell in the third row stayed dead since it was dead and didn't have three neighbours

This program contains a program.cs and two clases(grid and cell) that allow it to function
The grid class is used to create grids, which consist of two arrays of cells - main and transfer arrays
The cell class is used to create the cells that make up the arrays
After the user inputs the dimensions for the grid, a grid is created. It then randomly fills the cells in the  two arrays with values of 1 or 0, alive or dead
The initial generation is then displayed
The user then inputs how many generations they would like the program to display
For each generation, the program:
	- clears the console
	- determines the number of alive neighbours each cell has by examining the statuses of the neighbours that surround the cell
	- uses this along with the cell's status to determine the status the cell will have in the next generation
	- puts the new value into the transfer array for that cell's position
	- after determining the new status of each cell in the array, puts each value from the transfer array into the same position in the main array
	- displays the new generation
Once the program has run for the specified number of generations, it wishes the user farewell and then closes

This program does not contain many limitations -  all user inputs are made so that users can not input invalid phrases
There is one exception - very large numbers: if the grid contains extremely large dimensions, the rows will spill off the screen into the next line, damaging the way the grid looks
All other possible exceptions are handled using exception handling