namespace Labyrinth
{
  using System;
  class Lab
  {
    private static char[,] lab =
     {
      {' ',' ',' ','*',' ',' ',' ' },
      {'*','*',' ','*',' ','*',' ' },
      {' ',' ',' ',' ',' ',' ',' ' },
      {' ','*','*','*','*','*',' ' },
      {' ',' ',' ',' ',' ',' ','e' },
    };

    private static int numRows = lab.GetLength(0);
    private static int numCols = lab.GetLength(1);

    static void Main(string[] args)
    {
      FindExit(0, 0);
      Print(lab);
    }

    static void FindExit(int row, int col)
    {
      if (row < 0 || col < 0 || row >= numRows || col >= numCols)
      {
        // Out of labyrinth
        return;
      }

      if (lab[row, col] == 'e')
      {
        // exit found
        Console.WriteLine("Exit found!");
        Printf();
        return;
      }

      if (lab[row, col] != ' ')
      {
        // Cell already visited or is a wall
        return;
      }

      // mark visited , mark with x
      lab[row, col] = 'x';

      // try to this direction, try to find exit
      FindExit(row, col + 1); // right
      FindExit(row, col - 1); // left
      FindExit(row + 1, col); // down
      FindExit(row - 1, col); // top 

      lab[row, col] = ' ';
    }

    private static void Printf()
    {
      for (int row = 0; row < numRows; row++)
      {
        for (int col = 0; col < numCols; col++)
        {
          Console.Write(lab[row,col]);
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    static void Print(char[,] lab)
    {
      var rows = lab.GetLength(0);
      var cols = lab.GetLength(1);

      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          Console.Write(lab[i, j]);
        }
        Console.WriteLine();
      }
    }

  }
}
