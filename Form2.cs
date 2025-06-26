using LoanLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Ипотечный_калькулятор
{
    public partial class Form2 : Form
    {
        private readonly Loan loan;
        private readonly Form1 mainForm;

        public Form2(Loan loan, Form1 form1)
        {
            InitializeComponent();
            this.loan = loan;
            this.mainForm = form1;

            this.Text = Form1.Form2Title;
            saveButton.Text = Form1.ButtonSaveText;
            backButton.Text = Form1.ButtonBackText;

            LoanDataGridView.Columns[0].HeaderText = Form1.HeaderMonth;
            LoanDataGridView.Columns[1].HeaderText = Form1.HeaderPayment;
            LoanDataGridView.Columns[2].HeaderText = Form1.HeaderInterest;
            LoanDataGridView.Columns[3].HeaderText = Form1.HeaderRemaining;

            FillLoanData();

            LoanDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
        }

        private void FillLoanData()
        {
            LoanDataGridView.Rows.Clear();

            decimal totalPayment = 0;
            decimal totalInterest = 0;

            for (int i = 0; i < loan.TermMonths; i++)
            {
                var month = (int)loan.Payouts[i, 0];
                var payment = loan.Payouts[i, 1];
                var interest = loan.Payouts[i, 2];
                var remaining = loan.Payouts[i, 4];

                if (i>0 && loan.Payouts[i-1, 4] > 0) LoanDataGridView.Rows.Add(month, payment, interest, remaining);

                totalPayment += payment;
                totalInterest += interest;
            }
            LoanDataGridView.Rows.Add();

            LoanDataGridView.Rows.Add(Form1.LabelTotal, totalPayment, totalInterest, "");
            LoanDataGridView.Rows[LoanDataGridView.Rows.Count - 2].DefaultCellStyle.Font = new Font(LoanDataGridView.Font, FontStyle.Bold);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Form1.Save(loan);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void LoanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
