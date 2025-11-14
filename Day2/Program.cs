using System.Runtime.InteropServices;

public class Program()
{
    #region Part One

    /*[X1, Y1] + [X2, Y2] = [X1 + X2, Y1 + Y2]
     *
     *[X1,Y1] * [X2,Y2] = [X1 * X2 - Y1 * Y2, X1 * Y2 + Y1 * X2]
     *
     *[X1,Y1] / [X2,Y2] = [X1 / X2, Y1 / Y2]
     */

    static int[] StartingPoint = [35300, -64910];

    static int[] R = [0, 0];

    static int[,] PointToCheck = new int[10201, 2];

    static int validCounts = 0;

    static int gridSize = 101;

    /*
     * Multiply the result by itself.
     * Divide the result by [10,10].
     * Add A to the result.
     */

    #endregion

    static void Main(string[] args)
    {
        int[] LastPoint = AddComplex(StartingPoint, [1000, 1000]);
        Console.WriteLine(LastPoint[0] + " " + LastPoint[1]);

        int yRange = StartingPoint[1] - LastPoint[1];
        int yToNextPoint = yRange / (gridSize - 1);

        int[] yPositions = new int[101];

        for (int i = 0; i < 101; i++)
        {
            yPositions[i] = StartingPoint[1] - yToNextPoint * i;
        }

        int xRange = LastPoint[0] - StartingPoint[0];
        int xToNextPoint = xRange / (gridSize - 1);

        int[] xPositions = new int[101];

        for (int i = 0; i < 101; i++)
        {
            xPositions[i] = StartingPoint[0] + xToNextPoint * i;
        }

        for (int i = 0; i < gridSize; i++)
        {
            PointToCheck[i, 0] = xPositions[i];
            PointToCheck[i, 1] = yPositions[i];
        }

        for (int i = 0; i < PointToCheck.GetLength(0); i ++)
        {
            for (int j = 0; j < PointToCheck.GetLength(1); j++)
            {
                // I need pen and paper
                //PointToCheck[i,j] = [xPositions[i], yPositions[j]];
            }
        }    

        foreach (int i in PointToCheck)
        {
            Console.WriteLine($"{i}");
        }


        //for (int i = 100; i > 0; i--)
        //{
        //    R = MultiplyComplex(R, R);
        //    //Console.WriteLine($"Multiply the result by itself: [{R[0]},{R[1]}]");
        //
        //    R = DivideComplex(R, [100000, 100000]);
        //    //Console.WriteLine($"Divide the result: [{R[0]},{R[1]}]");
        //
        //    R = AddComplex(R, PointToCheck);
        //    //Console.WriteLine($"Add A to the result: [{R[0]},{R[1]}]");
        //
        //    if (!(R[0] > 1000000 || R[0] < -1000000 || R[1] > 1000000 || R[1] < -1000000))
        //    {
        //        validCounts++;
        //    }
        //}

        //Console.WriteLine($"Final answer: [{R[0]},{R[1]}]");
        Console.WriteLine($"And number of valid spots: {validCounts}");
    }

    private static int[] AddComplex(int[] x, int[] y)
    {
        // [X1, Y1] + [X2, Y2] = [X1 + X2, Y1 + Y2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];

        return [x1 + y1, x2 + y2];
    }

    private static int[] MultiplyComplex(int[] x, int[] y)
    {
        // [X1,Y1] * [X2,Y2] = [X1 * X2 - Y1 * Y2, X1 * Y2 + Y1 * X2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];

        return [ x1 * y1 - x2 * y2, x1 * y2 + x2 * y1 ];
    }

    private static int[] DivideComplex(int[] x, int[] y)
    {
        // [X1,Y1] / [X2,Y2] = [X1 / X2, Y1 / Y2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];
        int[] returnValue = [0, 0];

        return [ x1 / y1, x2 / y2 ];
    }
}