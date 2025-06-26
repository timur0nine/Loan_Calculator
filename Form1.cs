using System.Reflection;
using System.Threading.Tasks;
using LoanLogic;
namespace Ипотечный_калькулятор
{
    public partial class Form1 : Form
    {
        public static string HeaderMonth = "Месяц";
        public static string HeaderPayment = "Сумма";
        public static string HeaderInterest = "Проценты";
        public static string HeaderPrincipal = "Тело";
        public static string HeaderRemaining = "Остаток";
        public static string LabelTotal = "Итого";
        public static string ButtonSaveText = "Сохранить";
        public static string ButtonBackText = "Назад";
        public static string Form2Title = "График платежей";

        public static string msgInvalidAmount = "Некорректная сумма.";
        public static string msgInvalidTerm = "Некорректный срок.";
        public static string msgInvalidRate = "Процентная ставка должна быть от 0 до 100.";
        public static string msgNoTermType = "Не выбран тип срока.";
        public static string msgNoSchedule = "Не выбран тип графика платежей.";
        public static string msgInvalidInitial = "Первоначальный взнос должен быть неотрицательным и меньше суммы кредита.";
        public static string msgEarlyMonth = "Неверный номер месяца досрочного платежа в строке";
        public static string msgEarlyPayment = "Неверная сумма досрочного платежа в строке";
        public static string msgGeneralError = "Ошибка:";
        public static string msgCaption = "Ошибка ввода";


        Loan loan = new Loan();
        private HelpProvider helpProvider = new HelpProvider();

        private Loan currentLoan;
        private string helpFilePath;
        public Form1()
        {
            
            InitializeComponent();

            languageComboBox.SelectedIndex = 0;

            helpProvider.HelpNamespace = "CalculatorHelp.chm";

            helpProvider.SetHelpKeyword(termTextBox, "vvod_dannykh.htm");
            helpProvider.SetHelpKeyword(amountTextBox, "vvod_dannykh.htm");
            helpProvider.SetHelpKeyword(initialPaymentTextBox, "vvod_dannykh.htm");
            helpProvider.SetHelpNavigator(termTextBox, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(amountTextBox, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(initialPaymentTextBox, HelpNavigator.Topic);

            helpProvider.SetHelpKeyword(termComboBox, "vvod_dannykh.htm");
            helpProvider.SetHelpKeyword(scheduleComboBox, "vvod_dannykh.htm");
            helpProvider.SetHelpNavigator(termComboBox, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(scheduleComboBox, HelpNavigator.Topic);

            helpProvider.SetHelpKeyword(calculateButton, "rasschet_dannykh.htm");
            helpProvider.SetHelpKeyword(saveButton, "rasschet_dannykh.htm");
            helpProvider.SetHelpKeyword(clearButton, "rasschet_dannykh.htm");
            helpProvider.SetHelpNavigator(calculateButton, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(saveButton, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(clearButton, HelpNavigator.Topic);

            helpProvider.SetHelpKeyword(earlyPaymentDataGridView, "table_kontrol.htm");
            helpProvider.SetHelpNavigator(earlyPaymentDataGridView, HelpNavigator.Topic);





            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            string helpFilePath = System.IO.Path.Combine(Application.StartupPath, "CalculatorHelp.chm");
            Help.ShowHelp(this, helpFilePath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(termTextBox.Text, out int term) || term <= 0)
                    throw new ArgumentException(msgInvalidTerm);

                if (termComboBox.SelectedIndex == -1)
                    throw new ArgumentException(msgNoTermType);

                if (termComboBox.SelectedIndex == 0) // если "лет"
                    term *= 12;

                if (!decimal.TryParse(amountTextBox.Text, out decimal amount) || amount <= 0)
                    throw new ArgumentException(msgInvalidAmount);

                if (!double.TryParse(interestTextBox.Text, out double rate) || rate < 0 || rate > 100)
                    throw new ArgumentException(msgInvalidRate);

                decimal initialPayment = 0;
                if (!string.IsNullOrWhiteSpace(initialPaymentTextBox.Text))
                {
                    if (!decimal.TryParse(initialPaymentTextBox.Text, out initialPayment) || initialPayment < 0 || initialPayment >= amount)
                        throw new ArgumentException(msgInvalidInitial);
                }

                if (scheduleComboBox.SelectedIndex == -1)
                    throw new ArgumentException(msgNoSchedule);

                var scheduleType = (scheduleComboBox.SelectedIndex == 0);

                var loanAmount = amount - initialPayment;

                loan = new Loan(scheduleType, loanAmount, term, rate);

                // Обработка досрочных платежей
                for (int i = 0; i < earlyPaymentDataGridView.Rows.Count - 1; i++)
                {
                    var row = earlyPaymentDataGridView.Rows[i];
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        if (!int.TryParse(row.Cells[0].Value.ToString(), out int month) || month < 1 || month > term)
                            throw new ArgumentException(msgEarlyMonth+msgEarlyPayment + $"{i + 1}.");

                        if (!decimal.TryParse(row.Cells[1].Value.ToString(), out decimal payment) || payment <= 0)
                            throw new ArgumentException(msgEarlyPayment+ $"{ i + 1}.");

                        loan.AddEarlyRepayment(month, payment);
                    }
                }

                loan.Calculate();
                var resultForm = new Form2(loan, this);
                this.Hide();
                resultForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(msgGeneralError + $"{ex.Message}", msgCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void termTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save(loan);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            loan = null;

            termTextBox.Clear();
            termComboBox.SelectedIndex = -1;
            amountTextBox.Clear();
            interestTextBox.Clear();
            initialPaymentTextBox.Clear();
            scheduleComboBox.SelectedIndex = -1;
            earlyPaymentDataGridView.Rows.Clear();
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int schedule = scheduleComboBox.SelectedIndex;
            int termType = termComboBox.SelectedIndex;
            scheduleComboBox.SelectedIndex = -1;
            termComboBox.SelectedIndex = -1;
            switch (languageComboBox.SelectedIndex)
            {
                case 0: // Русский
                    term.Text = "Срок";
                    termComboBox.Items.Clear();
                    termComboBox.Items.AddRange(["Лет", "Месяцев"]);
                    amount.Text = "Сумма";
                    interest.Text = "Процентная ставка";
                    scheduleComboBox.Items.Clear();
                    scheduleComboBox.Items.AddRange(["Аннуитетные", "Дифференцированные"]);
                    initialPayment.Text = "Первоначальный взнос";
                    type.Text = "Тип платежей";
                    earlyPayments.Text = "Досрочные погашения";
                    calculateButton.Text = "Рассчитать";
                    saveButton.Text = "Сохранить...";
                    clearButton.Text = "Новый расчет";
                    helpButton.Text = "Помощь";
                    this.Text = "Ипотечный калькулятор";

                    HeaderMonth = "Месяц";
                    HeaderPayment = "Сумма";
                    HeaderInterest = "Платеж по процентам";
                    HeaderPrincipal = "Основной долг";
                    HeaderRemaining = "Остаток долга";
                    LabelTotal = "Итого";
                    ButtonSaveText = "Сохранить";
                    ButtonBackText = "Назад";
                    Form2Title = "График платежей";

                    msgInvalidAmount = "Некорректная сумма.";
                    msgInvalidTerm = "Некорректный срок.";
                    msgInvalidRate = "Процентная ставка должна быть от 0 до 100.";
                    msgNoTermType = "Не выбран тип срока.";
                    msgNoSchedule = "Не выбран тип графика платежей.";
                    msgInvalidInitial = "Первоначальный взнос должен быть неотрицательным и меньше суммы кредита.";
                    msgEarlyMonth = "Неверный номер месяца досрочного платежа в строке";
                    msgEarlyPayment = "Неверная сумма досрочного платежа в строке";
                    msgGeneralError = "Ошибка:";
                    msgCaption = "Ошибка ввода";
                    break;

                case 1: // English
                    term.Text = "Term";
                    termComboBox.Items.Clear();
                    termComboBox.Items.AddRange(["Years", "Months"]);
                    amount.Text = "Amount";
                    interest.Text = "Interest Rate";
                    scheduleComboBox.Items.Clear();
                    scheduleComboBox.Items.AddRange(["Annuity", "Differentiated"]);
                    initialPayment.Text = "Initial Payment";
                    type.Text = "Payment Type";
                    earlyPayments.Text = "Early Payments";
                    calculateButton.Text = "Calculate";
                    saveButton.Text = "Save...";
                    clearButton.Text = "New Calculation";
                    helpButton.Text = "Help";
                    this.Text = "Mortgage Calculator";

                    HeaderMonth = "Month";
                    HeaderPayment = "Payment";
                    HeaderInterest = "Interest";
                    HeaderPrincipal = "Principal";
                    HeaderRemaining = "Remaining";
                    LabelTotal = "Total";
                    ButtonSaveText = "Save";
                    ButtonBackText = "Back";
                    Form2Title = "Payment Schedule";

                    msgInvalidAmount = "Invalid amount.";
                    msgInvalidTerm = "Invalid term.";
                    msgInvalidRate = "Interest rate must be between 0 and 100.";
                    msgNoTermType = "Term type not selected.";
                    msgNoSchedule = "Payment schedule type not selected.";
                    msgInvalidInitial = "Initial payment must be non-negative and less than the loan amount.";
                    msgEarlyMonth = "Invalid early payment month in line";
                    msgEarlyPayment = "Invalid early payment amount in line";
                    msgGeneralError = "Error:";
                    msgCaption = "Input Error";
                    break;

                case 2: // Español
                    term.Text = "Plazo";
                    termComboBox.Items.Clear();
                    termComboBox.Items.AddRange(["Años", "Meses"]);
                    amount.Text = "Monto";
                    interest.Text = "Tasa de interés";
                    scheduleComboBox.Items.Clear();
                    scheduleComboBox.Items.AddRange(["Anualidades", "Diferenciado"]);
                    initialPayment.Text = "Pago inicial";
                    type.Text = "Tipo de pago";
                    earlyPayments.Text = "Pagos anticipados";
                    calculateButton.Text = "Calcular";
                    saveButton.Text = "Guardar...";
                    clearButton.Text = "Nuevo cálculo";
                    helpButton.Text = "Ayuda";
                    this.Text = "Calculadora de hipotecas";

                    HeaderMonth = "Mes";
                    HeaderPayment = "Pago";
                    HeaderInterest = "Interés";
                    HeaderPrincipal = "Principal";
                    HeaderRemaining = "Saldo";
                    LabelTotal = "Total";
                    ButtonSaveText = "Guardar";
                    ButtonBackText = "Atrás";
                    Form2Title = "Calendario de pagos";

                    msgInvalidAmount = "Monto inválido.";
                    msgInvalidTerm = "Plazo inválido.";
                    msgInvalidRate = "La tasa de interés debe estar entre 0 y 100.";
                    msgNoTermType = "No se seleccionó el tipo de plazo.";
                    msgNoSchedule = "No se seleccionó el tipo de calendario de pagos.";
                    msgInvalidInitial = "El pago inicial debe ser no negativo y menor que el monto del préstamo.";
                    msgEarlyMonth = "Número de mes inválido en la línea de pago anticipado";
                    msgEarlyPayment = "Monto de pago anticipado inválido en la línea";
                    msgGeneralError = "Error:";
                    msgCaption = "Error de entrada";
                    break;

                case 3: // Français
                    term.Text = "Durée";
                    termComboBox.Items.Clear();
                    termComboBox.Items.AddRange(["Ans", "Mois"]);
                    amount.Text = "Montant";
                    interest.Text = "Taux d’intérêt";
                    scheduleComboBox.Items.Clear();
                    scheduleComboBox.Items.AddRange(["Annuités", "Différencié"]);
                    initialPayment.Text = "Acompte initial";
                    type.Text = "Type de paiement";
                    earlyPayments.Text = "Remboursements anticipés";
                    calculateButton.Text = "Calculer";
                    saveButton.Text = "Enregistrer...";
                    clearButton.Text = "Nouveau calcul";
                    helpButton.Text = "Aide";
                    this.Text = "Calculatrice hypothécaire";

                    HeaderMonth = "Mois";
                    HeaderPayment = "Paiement";
                    HeaderInterest = "Intérêts";
                    HeaderPrincipal = "Principal";
                    HeaderRemaining = "Solde";
                    LabelTotal = "Total";
                    ButtonSaveText = "Enregistrer";
                    ButtonBackText = "Retour";
                    Form2Title = "Calendrier des paiements";

                    msgInvalidAmount = "Montant invalide.";
                    msgInvalidTerm = "Durée invalide.";
                    msgInvalidRate = "Le taux d’intérêt doit être compris entre 0 et 100.";
                    msgNoTermType = "Type de durée non sélectionné.";
                    msgNoSchedule = "Type de calendrier de paiements non sélectionné.";
                    msgInvalidInitial = "L’acompte initial doit être non négatif et inférieur au montant du prêt.";
                    msgEarlyMonth = "Numéro de mois invalide dans la ligne de remboursement anticipé";
                    msgEarlyPayment = "Montant invalide dans la ligne de remboursement anticipé";
                    msgGeneralError = "Erreur :";
                    msgCaption = "Erreur de saisie";
                    break;
            }
            scheduleComboBox.SelectedIndex = schedule;
            termComboBox.SelectedIndex = termType;

            Month.HeaderText = HeaderMonth;
            Payment.HeaderText = HeaderPayment;
        }
        public static void Save(Loan loan)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Сохранить график платежей"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoanExcelExporter.Export(loan, saveFileDialog.FileName, (HeaderMonth, HeaderPayment, HeaderInterest, HeaderPrincipal, HeaderRemaining, LabelTotal) );
                    MessageBox.Show("Файл успешно сохранен.", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка");
                }
            }
        }
    }

}
