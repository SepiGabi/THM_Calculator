namespace ThmCalculator
{
    using System;
    using TridentGoalSeek;

    class Program
    {
        //780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780, 780

        static void Main(string[] args)
        {
            CalculationData userinput = new UserInputReader().ReadUserInput();
            if (userinput == null)
            {
                Console.WriteLine("Nem megfelelő beviteli adatok!");
                Console.ReadKey();
                return;
            }
            GoalSeek goalSeeker = new GoalSeek(userinput.ThmCalculation);
            GoalSeekResult seekResult = goalSeeker.SeekResult(userinput.IssueValue);

            Console.WriteLine();
            Console.WriteLine("----------------");
            if (seekResult.InputVariable.HasValue)
            {
                Console.Write("A számított THM: ");
                Console.WriteLine(Math.Round(seekResult.InputVariable.Value, 10).ToString("P8"));
            }
            else
            {
                Console.WriteLine("Nem sikerült kiszámolni!");
            }
            Console.ReadKey();
        }
    }
}
