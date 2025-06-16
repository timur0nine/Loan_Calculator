namespace Ипотечный_калькулятор
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            LoanDataGridView = new DataGridView();
            Month = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            Interest = new DataGridViewTextBoxColumn();
            Remaining = new DataGridViewTextBoxColumn();
            saveButton = new Button();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)LoanDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LoanDataGridView
            // 
            LoanDataGridView.AllowUserToResizeColumns = false;
            LoanDataGridView.AllowUserToResizeRows = false;
            LoanDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoanDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoanDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LoanDataGridView.Columns.AddRange(new DataGridViewColumn[] { Month, Payment, Interest, Remaining });
            LoanDataGridView.Location = new Point(12, 12);
            LoanDataGridView.Name = "LoanDataGridView";
            LoanDataGridView.Size = new Size(543, 346);
            LoanDataGridView.TabIndex = 14;
            // 
            // Month
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Month.DefaultCellStyle = dataGridViewCellStyle1;
            Month.HeaderText = "Месяц";
            Month.Name = "Month";
            Month.ReadOnly = true;
            // 
            // Payment
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            Payment.DefaultCellStyle = dataGridViewCellStyle2;
            Payment.FillWeight = 150F;
            Payment.HeaderText = "Платеж";
            Payment.Name = "Payment";
            Payment.ReadOnly = true;
            Payment.Resizable = DataGridViewTriState.True;
            Payment.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // interest
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            Interest.DefaultCellStyle = dataGridViewCellStyle3;
            Interest.FillWeight = 150F;
            Interest.HeaderText = "Платеж по процентам";
            Interest.Name = "interest";
            Interest.ReadOnly = true;
            // 
            // Remaining
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            Remaining.DefaultCellStyle = dataGridViewCellStyle4;
            Remaining.FillWeight = 150F;
            Remaining.HeaderText = "Остаток";
            Remaining.Name = "Remaining";
            Remaining.ReadOnly = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(297, 374);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(121, 37);
            saveButton.TabIndex = 16;
            saveButton.Text = "Сохранить...";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(170, 374);
            backButton.Name = "backButton";
            backButton.Size = new Size(121, 37);
            backButton.TabIndex = 17;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 427);
            Controls.Add(backButton);
            Controls.Add(saveButton);
            Controls.Add(LoanDataGridView);
            Name = "Form2";
            Text = "Результат";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)LoanDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView LoanDataGridView;
        private Button saveButton;
        private Button backButton;
        private DataGridViewTextBoxColumn Month;
        private DataGridViewTextBoxColumn Payment;
        private DataGridViewTextBoxColumn Interest;
        private DataGridViewTextBoxColumn Remaining;
    }
}