public class Program()
{
    #region Day One
    // get my names and directions strings from the challenge
    private static string _inputNames = "Drethadir,Sarnketh,Torwyris,Qyraidris,Maralzorin," +
        "Shaemjorath,Xyrorath,Zorxelor,Thalxelor,Cynderirin";
    private static string _inputDirections = "L9,R3,L5,R5,L1,R9,L2,R1,L1,R2,L5";

    // split the names and directions into individual items in arrays
    private static string[] _nameList = _inputNames.Split(',');
    private static string[] _directionList = _inputDirections.Split(',');

    // a counter for how many steps we take from the first array item to hit our target
    //  after taking all directions into account
    private static int _endSteps = 0;
    #endregion

    #region Day Two
    private static string _dayTwoInputNames = "Fyndmir,Ascalphor,Aeorris,Anorkris,Urithmyr," +
        "Ilmarhynd,Zynkyris,Braeacris,Havjorath,Marroth,Aureketh,Urithdaros,Urithmirath," +
        "Xandravor,Aeorpyr,Dorimar,Cynderural,Vornfeth,Nysssyron,Brylquin";
    private static string _dayTwoInputDirections = "L12,R5,L14,R12,L9,R17,L17,R17,L5,R17,L5,R15," +
        "L5,R17,L5,R14,L5,R16,L5,R8,L12,R9,L13,R15,L16,R15,L19,R19,L5";

    //private static string _dayTwoInputNames = "Vyrdax,Drakzyph,Fyrryn,Elarzris";
    //private static string _dayTwoInputDirections = "R3,L2,R3,L1";

    private static string[] _dayTwoNames = _dayTwoInputNames.Split(',');
    private static string[] _dayTwoDirections = _dayTwoInputDirections.Split(',');

    private static int _dayTwoSteps = 0;
    #endregion
    static void Main(string[] args)
    {
        DayOnePartOne();
        DayOnePartTwo();

        //Console.WriteLine(plus(0, 20, 0, _dayTwoNames.Length - 1));
    }

    private static void DayOnePartOne()
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
                if (_endSteps >= stepsBack)
                {
                    _endSteps -= stepsBack;
                }
                else // otherwise we only subtract enough to hit 0
                {
                    while (_endSteps > 0)
                    {
                        _endSteps--;
                    }
                }
            }
            else if (direction.Contains('R'))
            {
                string newString = direction.Replace("R", "");
                int stepsForward = int.Parse(newString);
                // here we have to check that we don't go out of the last array item, so only
                //  move the full steps if we have enough space to do so
                if (_endSteps <= _nameList.Length - stepsForward)
                {
                    _endSteps += stepsForward;
                }
                else // if we are too close to the end we just go forward until we hit the end
                {
                    while (_endSteps < _nameList.Length)
                    {
                        _endSteps++;
                    }
                }
            }
        }
        // print out the name at the final position, we need to do -1 because the
        //  array index will be one behind the actual count.
        Console.WriteLine(_nameList[_endSteps - 1]);
    }

    private static void DayOnePartTwo()
    {
        // similar start to Part One
        foreach (string direction in _dayTwoDirections)
        {
            // directions start with L or R, L = subtract, R = add
            if (direction.Contains('L'))
            {
                // remove the L by replacing with empty string
                string newString = direction.Replace("L", "");
                // parse the remaining string numeral to an int
                int stepsBack = int.Parse(newString);
                // this time we don't have to move with restrictions so we can just
                //  add up the numbers to get a final position relative to the starting point
                // L numbers will be subtracted and R numbers added
                _dayTwoSteps -= stepsBack;
            }
            if (direction.Contains('R'))
            {
                string newString = direction.Replace("R", "");
                int stepsForward = int.Parse(newString);

                _dayTwoSteps += stepsForward;
            }
        }
        // running the program and displaying the value of _dayTwoSteps
        // after the foreach loop shows us that we need to go -3 steps from the start
        // meaning we have to loop back around.
        // first step = go to last item
        // second step = second to last item
        // third step = third to last item
        // index = (index + rangeLength - decrementAmount) % rangeLength
        Console.WriteLine($"Correct steps to take are: {_dayTwoSteps}," +
            $"and correct answer is {_dayTwoNames[Math.Abs(_dayTwoSteps) % 20]}");
    } 
}