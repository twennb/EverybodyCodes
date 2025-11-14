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

    static int[] A = [25,9];

    static int[] R = [0, 0];

    /*
     * Multiply the result by itself.
     * Divide the result by [10,10].
     * Add A to the result.
     */

    #endregion

    static void Main(string[] args)
    {
        int[] ans = [0,0];

        for (int i = 3; i > 0; i--)
        {
            MultiplyComplex(R, R);
            Console.WriteLine($"Multiply the result by itself: [{R[0]},{R[1]}]");

            DivideComplex(R, [10, 10]);
            Console.WriteLine($"Divide the result by [10,10]: [{R[0]},{R[1]}]");

            AddComplex(R, A);
            Console.WriteLine($"Add A to the result: [{R[0]},{R[1]}]");
        }

        Console.WriteLine($"Final answer: [{R[0]},{R[1]}]");
    }

    private static void AddComplex(int[] x, int[] y)
    {
        // [X1, Y1] + [X2, Y2] = [X1 + X2, Y1 + Y2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];

        R = [x1 + y1, x2 + y2];
    }

    private static void MultiplyComplex(int[] x, int[] y)
    {
        // [X1,Y1] * [X2,Y2] = [X1 * X2 - Y1 * Y2, X1 * Y2 + Y1 * X2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];

        R = [ x1 * y1 - x2 * y2, x1 * y2 + x2 * y1 ];
    }

    private static void DivideComplex(int[] x, int[] y)
    {
        // [X1,Y1] / [X2,Y2] = [X1 / X2, Y1 / Y2]
        int x1 = x[0], x2 = x[1];
        int y1 = y[0], y2 = y[1];
        int[] returnValue = [0, 0];

        R = [ x1 / y1, x2 / y2 ];
    }
}