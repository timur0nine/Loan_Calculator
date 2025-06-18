using LoanLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoanTests
   
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void ConstructorValidParametersShouldInitializeProperties()
        {
            var type = true;
            decimal amount = 1000000m;
            int term = 240;
            double rate = 8.5;

            Loan loan = new Loan(type, amount, term, rate);

            Assert.AreEqual(type, loan.ScheduleType == RepaymentScheduleType.Annuity);
            Assert.AreEqual(amount, loan.Amount);
            Assert.AreEqual(term, loan.TermMonths);
            Assert.AreEqual(rate, loan.InterestRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorInvalidAmountShouldThrow()
        {
            var loan = new Loan(true, 0m, 240, 5.0);
        }

        [TestMethod]
        public void CalculateAnnuityShouldFillPayouts()
        {
            var loan = new Loan(true, 120000m, 12, 12.0);

            loan.Calculate();
            var payouts = loan.Payouts;

            Assert.AreEqual(12, payouts.GetLength(0));
            Assert.AreEqual(5, payouts.GetLength(1));
            Assert.IsTrue(payouts[0, 1] > 0); // первый платёж
            Assert.IsTrue(payouts[0, 4] > 0); // остаток после первого месяца
        }

        [TestMethod]
        public void CalculateDifferentiatedShouldFillPayouts()
        {
            var loan = new Loan(false, 120000m, 12, 12.0);

            loan.Calculate();
            var payouts = loan.Payouts;

            LoanExcelExporter.Export(loan, "D:\\a.xlsx");

            Assert.AreEqual(12, payouts.GetLength(0));
            Assert.AreEqual(5, payouts.GetLength(1));
            Assert.IsTrue(payouts[0, 1] > payouts[11, 1]); // платёж уменьшается
        }
        [TestMethod]
        public void EarlyRepayment_ShouldReduceDebtFaster_Annuity()
        {
            var loan = new Loan(true, amount: 120000m, termMonths: 12, interestRate: 12.0);
            loan.AddEarlyRepayment(2, 20000m); // Досрочное погашение во 2-й месяц

            loan.Calculate();

            decimal remainingAfter12 = loan.Payouts[11, 4];
            Assert.AreEqual(0m, remainingAfter12, "Долг должен быть полностью погашен до окончания срока из-за досрочного платежа.");

            // Дополнительно: можно проверить, что после досрочного платежа выплаты прекратились
            for (int i = 0; i < 12; i++)
            {
                decimal monthNumber = loan.Payouts[i, 0];
                if (loan.Payouts[i, 4] == 0)
                {
                    for (int j = i + 1; j < 12; j++)
                    {
                        Assert.AreEqual(0m, loan.Payouts[j, 1], $"Платеж в месяце {j + 1} должен быть равен 0 после досрочного погашения.");
                    }
                    break;
                }
            }
        }
    }
}