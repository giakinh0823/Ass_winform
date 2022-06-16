namespace Ciname.GUI.BookingController
{
    partial class BookingGUI
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
            this.bookingGridView = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.labelNumberOfBooking = new System.Windows.Forms.Label();
            this.numberOfBooking = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bookingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingGridView
            // 
            this.bookingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookingGridView.Location = new System.Drawing.Point(11, 252);
            this.bookingGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bookingGridView.Name = "bookingGridView";
            this.bookingGridView.RowHeadersWidth = 72;
            this.bookingGridView.RowTemplate.Height = 37;
            this.bookingGridView.Size = new System.Drawing.Size(728, 202);
            this.bookingGridView.TabIndex = 0;
            this.bookingGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingGridView_CellClick);
            this.bookingGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingGridView_CellContentClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(7, 182);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(165, 31);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create a new booking..";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // labelNumberOfBooking
            // 
            this.labelNumberOfBooking.AutoSize = true;
            this.labelNumberOfBooking.Location = new System.Drawing.Point(11, 228);
            this.labelNumberOfBooking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberOfBooking.Name = "labelNumberOfBooking";
            this.labelNumberOfBooking.Size = new System.Drawing.Size(115, 15);
            this.labelNumberOfBooking.TabIndex = 2;
            this.labelNumberOfBooking.Text = "Number of booking:";
            // 
            // numberOfBooking
            // 
            this.numberOfBooking.AutoSize = true;
            this.numberOfBooking.Location = new System.Drawing.Point(138, 228);
            this.numberOfBooking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numberOfBooking.Name = "numberOfBooking";
            this.numberOfBooking.Size = new System.Drawing.Size(13, 15);
            this.numberOfBooking.TabIndex = 3;
            this.numberOfBooking.Text = "0";
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(653, 212);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(83, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(5, 4);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(239, 25);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(257, 199);
            this.flowLayoutPanel.TabIndex = 18;
            // 
            // BookingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(743, 460);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.numberOfBooking);
            this.Controls.Add(this.labelNumberOfBooking);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.bookingGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BookingGUI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookingGUI";
            this.Load += new System.EventHandler(this.BookingGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bookingGridView;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label labelNumberOfBooking;
        private System.Windows.Forms.Label numberOfBooking;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}