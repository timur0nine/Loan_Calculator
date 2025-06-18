namespace LoanLogic
{
    public enum RepaymentScheduleType
    {
        Annuity,
        Differentiated
    }

    public class Loan
    {
        private RepaymentScheduleType scheduleType;
        private decimal amount;
        private int termMonths;
        private double interestRate;
        private decimal[,] payouts;

        private Dictionary<int, decimal> earlyRepayments = new Dictionary<int, decimal>();

        public RepaymentScheduleType ScheduleType
        {
            get => scheduleType;
            protected set => scheduleType = value;
        }

        public decimal Amount
        {
            get => amount;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Amount), "Сумма кредита должна быть больше нуля.");
                amount = value;
            }
        }

        public int TermMonths
        {
            get => termMonths;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(TermMonths), "Срок кредита должен быть больше нуля.");
                termMonths = value;
            }
        }

        public double InterestRate
        {
            get => interestRate;
            protected set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(InterestRate), "Процентная ставка должна быть в пределах от 0 до 100.");
                interestRate = value;
            }
        }

        public decimal[,] Payouts => payouts;

        public Loan(bool isAnnual, decimal amount, int termMonths, double interestRate)
        {
            ScheduleType = isAnnual == true ? RepaymentScheduleType.Annuity : RepaymentScheduleType.Differentiated;
            Amount = amount;
            TermMonths = termMonths;
            InterestRate = interestRate;

            payouts = new decimal[termMonths, 5];
        }
        public Loan()
        {

        }

        public void AddEarlyRepayment(int month, decimal amount)
        {
            if (month < 1 || month > TermMonths)
                throw new ArgumentOutOfRangeException(nameof(month), "Месяц должен быть в пределах срока кредита.");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма досрочного платежа должна быть больше нуля.");

            if (earlyRepayments.ContainsKey(month))
                earlyRepayments[month] += amount;
            else
                earlyRepayments[month] = amount;
        }

        public void Calculate()
        {
            payouts = new decimal[TermMonths, 5];
            var monthlyRate = (decimal)(InterestRate / 100.0 / 12.0);
            var remainingDebt = Amount;

            switch (ScheduleType)
            {
                case RepaymentScheduleType.Annuity:
                    var annuityCoef = monthlyRate == 0 ? 1 :
                        (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, TermMonths)) /
                        ((decimal)Math.Pow(1 + (double)monthlyRate, TermMonths) - 1);

                    var monthlyPayment = Amount * annuityCoef;

                    for (int month = 0; month < TermMonths; month++)
                    {
                        var interestPart = remainingDebt * monthlyRate;
                        var principalPart = monthlyPayment - interestPart;

                        if (principalPart > remainingDebt) principalPart = remainingDebt;

                        remainingDebt -= principalPart;

                        // Учет досрочного платежа
                        if (earlyRepayments.TryGetValue(month + 1, out decimal earlyPayment))
                        {
                            remainingDebt -= earlyPayment;
                            if (remainingDebt < 0) remainingDebt = 0;
                        }

                        payouts[month, 0] = month + 1;
                        payouts[month, 1] = monthlyPayment+ earlyPayment;
                        payouts[month, 2] = interestPart;
                        payouts[month, 3] = principalPart;
                        payouts[month, 4] = remainingDebt;

                        if (remainingDebt <= 0)
                        {
                            for (int i = month + 1; i < TermMonths; i++)
                                for (int j = 0; j < 5; j++)
                                    payouts[i, j] = 0;
                            break;
                        }
                    }
                    break;

                case RepaymentScheduleType.Differentiated:
                    var principalPayment = Amount / TermMonths;

                    for (int month = 0; month < TermMonths; month++)
                    {
                        var interestPart = remainingDebt * monthlyRate;
                        var monthlyTotal = principalPayment + interestPart;

                        remainingDebt -= principalPayment;

                        // Учет досрочного платежа
                        if (earlyRepayments.TryGetValue(month + 1, out decimal earlyPayment))
                        {
                            remainingDebt -= earlyPayment;
                            if (remainingDebt < 0) remainingDebt = 0;
                        }

                        payouts[month, 0] = month + 1;
                        payouts[month, 1] = monthlyTotal;
                        payouts[month, 2] = interestPart;
                        payouts[month, 3] = principalPayment;
                        payouts[month, 4] = remainingDebt;

                        if (remainingDebt <= 0)
                        {
                            for (int i = month + 1; i < TermMonths; i++)
                                for (int j = 0; j < 5; j++)
                                    payouts[i, j] = 0;
                            break;
                        }
                    }
                    break;

            }
        }
    }

}