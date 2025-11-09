public class Program()
{
    // get my names and directions strings from the challenge
    private static string _inputNames = "Drethadir,Sarnketh,Torwyris,Qyraidris,Maralzorin,Shaemjorath," +
        "Xyrorath,Zorxelor,Thalxelor,Cynderirin";
    private static string _inputDirections = "L9,R3,L5,R5,L1,R9,L2,R1,L1,R2,L5";

    // split the names and directions into individual items in arrays
    private static string[] _nameList = _inputNames.Split(',');
    private static string[] _directionList = _inputDirections.Split(',');

    // a counter for how many steps we take from the first array item to hit our target
    //  after taking all directions into account
    private static int endSteps = 0;

    static void Main(string[] args)
    {
        // go through all directions in the array
       foreach (string direction in _directionList)
        {
            // directions start with L or R, L = subtract, R = add
            if (direction.Contains('L'))
            {
                // remove the L by replacing with empty string
                string newString = direction.Replace("L", "");
                // parse the remaining string numeral to an int
                int stepsBack = int.Parse(newString);
                // we can't go into negatives so only subtract if we have enough steps to go left
                if (endSteps >= stepsBack)
                {
                    endSteps -= stepsBack;
                }
                else // otherwise we only subtract enough to hit 0
                {
                    while (endSteps > 0)
                    {
                        endSteps--;
                    }
                }
            }
            else if (direction.Contains('R'))
            {
                string newString = direction.Replace("R", "");
                int stepsForward = int.Parse(newString);
                // here we have to check that we don't go out of the last array item, so only
                //  move the full steps if we have enough space to do so
                if (endSteps <= _nameList.Length - stepsForward)
                {
                    endSteps += stepsForward;
                }
                else // if we are too close to the end we just go forward until we hit the end
                {
                    while (endSteps < _nameList.Length)
                    {
                        endSteps++;
                    }
                }
            }
        }
        // print out the name at the final position, we need to do -1 because the
        //  array index will be one behind the actual count.
        Console.WriteLine(_nameList[endSteps - 1]);
    }
}