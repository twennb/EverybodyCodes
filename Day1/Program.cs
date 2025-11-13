public class Program()
{
    #region Part 1
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

    #region Part 2
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

    #region Part 3
    private static string _dayThreeInputNames = "Wyrcyth,Mortor,Ildzyth,Aznarel,Xyrtor,Narsar," +
        "Shaemfelix,Ozanzeth,Tarldax,Dorvor,Kharnyn,Silzryn,Nyaris,Axalindor,Maralsyx,Eltmyr," +
        "Rynmirath,Gorathulth,Jardin,Jorathonar,Malath,Tyroryn,Tyrvoran,Zraallar,Selthar,Igngarath," +
        "Mariral,Aelitheldrith,Thyrosvoran,Thymther";
    private static string _dayThreeInputDirections = "L8,R34,L37,R37,L25,R20,L47,R10,L22,R6,L35," +
        "R45,L20,R26,L36,R32,L14,R25,L24,R45,L5,R24,L5,R36,L5,R28,L5,R19,L5,R46,L5,R16,L5,R33,L5," +
        "R25,L5,R6,L5,R38,L21,R43,L9,R10,L27,R22,L6,R27,L13,R12,L24,R44,L5,R38,L5,R44,L30,R48,L28";

    //private static string _dayThreeInputNames = "Vyrdax,Drakzyph,Fyrryn,Elarzris";
    //private static string _dayThreeInputDirections = "R3,L2,R3,L3";

    private static string[] _dayThreeNames = _dayThreeInputNames.Split(',');
    private static string[] _dayThreeDirections = _dayThreeInputDirections.Split(',');

    #endregion
    
    static void Main(string[] args)
    {
        DayOnePartOne();
        DayOnePartTwo();
        DayOnePartThree();

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
            $"and correct answer is {_dayTwoNames[Math.Abs(_dayTwoSteps) % _dayTwoNames.Length]}");
    }

    private static void DayOnePartThree()
    {
        int indexToSwap;
        string previousZero;
        string newZero;

        foreach (string direction in _dayThreeDirections)
        {
            if (direction.Contains('L'))
            {
                string newString = direction.Replace("L", "");
                int stepsBack = int.Parse(newString);

                // this time we don't count all steps for a final move
                // we have to swap the elements in the target index with
                // whatever is in [0] every individual direction.
                // calculate which index is getting swapped

                //Console.WriteLine((20 - 30) % 20);

                // I'm less sure about % for subtraction but lets just try
                // lets try something else..
                if (stepsBack > _dayThreeNames.Length)
                {
                    indexToSwap = (stepsBack - _dayThreeNames.Length);

                    while(indexToSwap > _dayThreeNames.Length)
                    {
                        indexToSwap -= _dayThreeNames.Length;
                    }

                    indexToSwap = _dayThreeNames.Length - indexToSwap;
                }
                else
                {
                    indexToSwap = _dayThreeNames.Length - stepsBack;
                }

                // save the two indicies 
                previousZero = _dayThreeNames[0];
                // same issue here now, out of range.
                newZero = _dayThreeNames[indexToSwap];

                // reassign the relevant spaces with the swapped elements
                Console.WriteLine($"Swapping {previousZero} with {newZero}");
                _dayThreeNames[0] = newZero;
                _dayThreeNames[indexToSwap] = previousZero;

            }
            if (direction.Contains('R')) // same as above but counting forwards
            {
                string newString = direction.Replace("R", "");
                int stepsForward = int.Parse(newString);
                // lets try % to loop it within the array range
                indexToSwap = stepsForward % _dayThreeNames.Length;

                previousZero = _dayThreeNames[0];
                // okay this overflows
                newZero = _dayThreeNames[indexToSwap];

                Console.WriteLine($"Swapping {previousZero} with {newZero}");
                _dayThreeNames[0] = newZero;
                _dayThreeNames[indexToSwap] = previousZero;
            }
        }

        Console.WriteLine($"The correct name is {_dayThreeNames[0]}");
    }
}