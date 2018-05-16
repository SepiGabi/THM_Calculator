namespace ThmCalculator
{
    using System;
    using TridentGoalSeek;

    internal class ThmCalculation : IGoalSeekAlgorithm
    {
        private double instalment;
        private double[] instalments;
        private PaymentFrequency paymentFrequency;

        /// <summary>
        /// Azonos nagyságú törlesztőrészletek esetére
        /// </summary>
        /// <param name="instalmentsCount">A törlesztések száma</param>
        /// <param name="instalment">Egy törlesztő részlet mértéke</param>
        /// <param name="paymentFrequency">Törlesztés gyakorisága. Pl.: heti,havi</param>
        public ThmCalculation(int instalmentsCount, double instalment, PaymentFrequency paymentFrequency)
        {
            this.instalment = instalment;
            this.paymentFrequency = paymentFrequency;
            this.instalments = new double[instalmentsCount];
            for (int i = 0; i < this.instalments.Length; i++)
            {
                this.instalments[i] = instalment;
            }
        }

        /// <summary>
        /// Különböző nagyságú törlesztőrészletek esetére
        /// </summary>
        /// <param name="instalments">Törlesztő részletek időben rendezett tömbje. A tömb első eleme az első törlesztő részlet, az utolsó eleme az utoljára fizetendő részlet.</param>
        /// <param name="paymentFrequency">Törlesztés gyakorisága. Pl.: heti,havi</param>
        public ThmCalculation(double[] instalments, PaymentFrequency paymentFrequency)
        {
            this.instalments = instalments;
            this.paymentFrequency = paymentFrequency;
        }

        public decimal Calculate(decimal inputVariable)
        {
            decimal total = 0;
            if (inputVariable > 0)
            {
                double baseNumber = double.Parse(inputVariable.ToString()) + 1;
                for (int i = 1; i <= instalments.Length; i++)
                {
                    double exponent = double.Parse(i.ToString()) / (int)this.paymentFrequency;
                    double subTotal = instalments[i-1] / Math.Pow(baseNumber, exponent);
                    total += decimal.TryParse(subTotal.ToString(), out decimal subTotalDecimal) ? subTotalDecimal : 0;
                }
            }
            return total;
        }
    }
}
