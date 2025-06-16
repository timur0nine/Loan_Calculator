namespace Ипотечный_калькулятор
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            term = new Label();
            termTextBox = new TextBox();
            termComboBox = new ComboBox();
            amountTextBox = new TextBox();
            amount = new Label();
            interestTextBox = new TextBox();
            interest = new Label();
            initialPaymentTextBox = new TextBox();
            initialPayment = new Label();
            scheduleComboBox = new ComboBox();
            type = new Label();
            earlyPaymentDataGridView = new DataGridView();
            Month = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            calculateButton = new Button();
            saveButton = new Button();
            earlyPayments = new Label();
            label7 = new Label();
            clearButton = new Button();
            label8 = new Label();
            languageComboBox = new ComboBox();
            helpButton = new Button();
            ((System.ComponentModel.ISupportInitialize)earlyPaymentDataGridView).BeginInit();
            SuspendLayout();
            // 
            // term
            // 
            term.AutoSize = true;
            term.Location = new Point(13, 14);
            term.Name = "term";
            term.Size = new Size(35, 15);
            term.TabIndex = 0;
            term.Text = "Срок";
            // 
            // termTextBox
            // 
            termTextBox.Location = new Point(74, 11);
            termTextBox.Name = "termTextBox";
            termTextBox.Size = new Size(100, 23);
            termTextBox.TabIndex = 1;
            termTextBox.TextChanged += termTextBox_TextChanged;
            // 
            // termComboBox
            // 
            termComboBox.FormattingEnabled = true;
            termComboBox.Items.AddRange(new object[] { "Лет", "Месяцев" });
            termComboBox.Location = new Point(189, 11);
            termComboBox.Name = "termComboBox";
            termComboBox.Size = new Size(96, 23);
            termComboBox.TabIndex = 2;
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(74, 46);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(211, 23);
            amountTextBox.TabIndex = 4;
            // 
            // amount
            // 
            amount.AutoSize = true;
            amount.Location = new Point(13, 49);
            amount.Name = "amount";
            amount.Size = new Size(45, 15);
            amount.TabIndex = 3;
            amount.Text = "Сумма";
            // 
            // interestTextBox
            // 
            interestTextBox.Location = new Point(157, 83);
            interestTextBox.Name = "interestTextBox";
            interestTextBox.Size = new Size(105, 23);
            interestTextBox.TabIndex = 7;
            // 
            // interest
            // 
            interest.AutoSize = true;
            interest.Location = new Point(12, 86);
            interest.Name = "interest";
            interest.Size = new Size(112, 15);
            interest.TabIndex = 6;
            interest.Text = "Процентная ставка";
            // 
            // initialPaymentTextBox
            // 
            initialPaymentTextBox.Location = new Point(157, 118);
            initialPaymentTextBox.Name = "initialPaymentTextBox";
            initialPaymentTextBox.Size = new Size(128, 23);
            initialPaymentTextBox.TabIndex = 10;
            // 
            // initialPayment
            // 
            initialPayment.AutoSize = true;
            initialPayment.Location = new Point(13, 122);
            initialPayment.Name = "initialPayment";
            initialPayment.Size = new Size(138, 15);
            initialPayment.TabIndex = 9;
            initialPayment.Text = "Первоначальный взнос";
            // 
            // scheduleComboBox
            // 
            scheduleComboBox.FormattingEnabled = true;
            scheduleComboBox.Items.AddRange(new object[] { "Annuity", "Differentiated" });
            scheduleComboBox.Location = new Point(157, 154);
            scheduleComboBox.Name = "scheduleComboBox";
            scheduleComboBox.Size = new Size(128, 23);
            scheduleComboBox.TabIndex = 11;
            scheduleComboBox.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // type
            // 
            type.AutoSize = true;
            type.Location = new Point(13, 154);
            type.Name = "type";
            type.Size = new Size(83, 15);
            type.TabIndex = 12;
            type.Text = "Тип платежей";
            // 
            // earlyPaymentDataGridView
            // 
            earlyPaymentDataGridView.AllowUserToResizeColumns = false;
            earlyPaymentDataGridView.AllowUserToResizeRows = false;
            earlyPaymentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            earlyPaymentDataGridView.Columns.AddRange(new DataGridViewColumn[] { Month, Payment });
            earlyPaymentDataGridView.Location = new Point(12, 209);
            earlyPaymentDataGridView.Name = "earlyPaymentDataGridView";
            earlyPaymentDataGridView.Size = new Size(343, 161);
            earlyPaymentDataGridView.TabIndex = 13;
            earlyPaymentDataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Month
            // 
            Month.HeaderText = "Месяц";
            Month.Name = "Month";
            // 
            // Payment
            // 
            Payment.HeaderText = "Сумма";
            Payment.Name = "Payment";
            Payment.Resizable = DataGridViewTriState.True;
            Payment.SortMode = DataGridViewColumnSortMode.NotSortable;
            Payment.Width = 200;
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(377, 208);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(121, 37);
            calculateButton.TabIndex = 14;
            calculateButton.Text = "Рассчитать";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(377, 260);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(121, 37);
            saveButton.TabIndex = 15;
            saveButton.Text = "Сохранить...";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // earlyPayments
            // 
            earlyPayments.AutoSize = true;
            earlyPayments.Location = new Point(12, 182);
            earlyPayments.Name = "earlyPayments";
            earlyPayments.Size = new Size(136, 15);
            earlyPayments.TabIndex = 16;
            earlyPayments.Text = "Досрочные погашения";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(268, 86);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 17;
            label7.Text = "%";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(377, 333);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(121, 37);
            clearButton.TabIndex = 18;
            clearButton.Text = "Новый расчет";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(11, 384);
            label8.Name = "label8";
            label8.Size = new Size(42, 30);
            label8.TabIndex = 19;
            label8.Text = "🌐";
            // 
            // languageComboBox
            // 
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Items.AddRange(new object[] { "Русский", "English", "Español", "Français" });
            languageComboBox.Location = new Point(59, 388);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(128, 23);
            languageComboBox.TabIndex = 20;
            languageComboBox.SelectedIndexChanged += languageComboBox_SelectedIndexChanged;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(377, 14);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(121, 37);
            helpButton.TabIndex = 21;
            helpButton.Text = "Помощь";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(525, 423);
            Controls.Add(helpButton);
            Controls.Add(languageComboBox);
            Controls.Add(label8);
            Controls.Add(clearButton);
            Controls.Add(label7);
            Controls.Add(earlyPayments);
            Controls.Add(saveButton);
            Controls.Add(calculateButton);
            Controls.Add(earlyPaymentDataGridView);
            Controls.Add(type);
            Controls.Add(scheduleComboBox);
            Controls.Add(initialPaymentTextBox);
            Controls.Add(initialPayment);
            Controls.Add(interestTextBox);
            Controls.Add(interest);
            Controls.Add(amountTextBox);
            Controls.Add(amount);
            Controls.Add(termComboBox);
            Controls.Add(termTextBox);
            Controls.Add(term);
            MaximizeBox = false;
            MaximumSize = new Size(541, 462);
            Name = "Form1";
            Text = "Ипотечный калькулятор";
            Load += Form1_Load;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)earlyPaymentDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label term;
        private TextBox termTextBox;
        private ComboBox termComboBox;
        private TextBox amountTextBox;
        private Label amount;
        private TextBox interestTextBox;
        private Label interest;
        private TextBox initialPaymentTextBox;
        private Label initialPayment;
        private ComboBox scheduleComboBox;
        private Label type;
        private DataGridView earlyPaymentDataGridView;
        private DataGridViewTextBoxColumn Month;
        private DataGridViewTextBoxColumn Payment;
        private Button calculateButton;
        private Button saveButton;
        private Label earlyPayments;
        private Label label7;
        private Button clearButton;
        private Label label8;
        private ComboBox languageComboBox;
        private Button helpButton;
    }
}
