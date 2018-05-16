namespace ThmCalculator
{
    using System;

    internal class UserInputReader
    {
        internal CalculationData ReadUserInput()
        {
            bool goodAnswer = false;
            CalculationData calculationData = null;
            while (!goodAnswer)
            {
                Console.Write("Egyenlő törlesztő részletekkel akar számolni? (I/N)");
                ConsoleKeyInfo answerKey = Console.ReadKey(true);
                if (answerKey.KeyChar.ToString().ToUpper() == "I")
                {
                    Console.WriteLine();
                    calculationData = ReadStaticInstalmentsData();
                    goodAnswer = true;
                }
                else if (answerKey.KeyChar.ToString().ToUpper() == "N")
                {
                    Console.WriteLine();
                    calculationData = ReadDynamicInstalmentsData();
                    goodAnswer = true;
                }
                Console.WriteLine();
            }
            return calculationData;
        }

        private CalculationData ReadStaticInstalmentsData()
        {
            ThmCalculation thmCalculation = null;
            Console.Write("Adja meg a hitel nagyságát: ");
            string answer = Console.ReadLine();
            if(!int.TryParse(answer, out int issueValue))
            {
                return null;
            }

            Console.Write("Adja meg a törlesztő részlet nagyságát: ");
            answer = Console.ReadLine();
            if(!double.TryParse(answer, out double instalment))
            {
                return null;
            }

            Console.Write("Adja meg a törlesztések számát: ");
            answer = Console.ReadLine();
            if(!int.TryParse(answer, out int instalmentCount))
            {
                return null;
            }

            bool goodAnswer = false;
            while (!goodAnswer)
            {
                Console.Write("Adja meg a törlesztési periódust: W/M (W-heti/ M:Havi)");
                ConsoleKeyInfo answerKey = Console.ReadKey(true);
                if (answerKey.KeyChar.ToString().ToUpper() == "W")
                {
                    thmCalculation = new ThmCalculation(instalmentCount, instalment, PaymentFrequency.Weekly);
                    goodAnswer = true;
                }
                else if (answerKey.KeyChar.ToString().ToUpper() == "M")
                {
                    thmCalculation = new ThmCalculation(instalmentCount, instalment, PaymentFrequency.Monthly);
                    goodAnswer = true;
                }
                Console.WriteLine();
            }
            return new CalculationData() { ThmCalculation = thmCalculation, IssueValue = issueValue };
        }

        private CalculationData ReadDynamicInstalmentsData()
        {
            ThmCalculation thmCalculation = null;
            Console.Write("Adja meg a hitel nagyságát: ");
            string answer = Console.ReadLine();
            if(!int.TryParse(answer, out int issueValue))
            {
                return null;
            }

            Console.Write("Adja meg a törlesztő részleteket időrendi sorrendben, vesszővel ellátva: ");
            answer = Console.ReadLine();
            var instalmentsRow = answer.Split(',');
            double[] instalments = new double[instalmentsRow.Length];
            for (int i = 0; i < instalmentsRow.Length; i++)
            {
                if (!double.TryParse(instalmentsRow[i], out instalments[i]))
                {
                    Console.WriteLine($"A következő elem nem megfelelő: {instalmentsRow[i]}");
                    return null;
                }
            }

            bool goodAnswer = false;
            while (!goodAnswer)
            {
                Console.Write("Adja meg a törlesztési periódust: W/M (W-heti/ M:Havi)");
                ConsoleKeyInfo answerKey = Console.ReadKey(true);
                if (answerKey.KeyChar.ToString().ToUpper() == "W")
                {
                    thmCalculation = new ThmCalculation(instalments, PaymentFrequency.Weekly);
                    goodAnswer = true;
                }
                else if (answerKey.KeyChar.ToString().ToUpper() == "M")
                {
                    thmCalculation = new ThmCalculation(instalments, PaymentFrequency.Monthly);
                    goodAnswer = true;
                }

                Console.WriteLine();
            }
            return new CalculationData() { ThmCalculation = thmCalculation, IssueValue = issueValue };
        }
    }
}
