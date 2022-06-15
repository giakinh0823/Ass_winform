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
            ((System.ComponentModel.ISupportInitialize)(this.bookingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingGridView
            // 
            this.bookingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookingGridView.Location = new System.Drawing.Point(12, 372);
            this.bookingGridView.Name = "bookingGridView";
            this.bookingGridView.RowHeadersWidth = 72;
            this.bookingGridView.RowTemplate.Height = 37;
            this.bookingGridView.Size = new System.Drawing.Size(1313, 429);
            this.bookingGridView.TabIndex = 0;
            this.bookingGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingGridView_CellContentClick);
            this.bookingGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingGridView_CellClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 264);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(279, 44);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create a new booking..";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // labelNumberOfBooking
            // 
            this.labelNumberOfBooking.AutoSize = true;
            this.labelNumberOfBooking.Location = new System.Drawing.Point(12, 324);
            this.labelNumberOfBooking.Name = "labelNumberOfBooking";
            this.labelNumberOfBooking.Size = new System.Drawing.Size(200, 30);
            this.labelNumberOfBooking.TabIndex = 2;
            this.labelNumberOfBooking.Text = "Number of booking:";
            // 
            // numberOfBooking
            // 
            this.numberOfBooking.AutoSize = true;
            this.numberOfBooking.Location = new System.Drawing.Point(222, 326);
            this.numberOfBooking.Name = "numberOfBooking";
            this.numberOfBooking.Size = new System.Drawing.Size(24, 30);
            this.numberOfBooking.TabIndex = 3;
            this.numberOfBooking.Text = "0";
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(1169, 314);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // BookingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 813);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.numberOfBooking);
            this.Controls.Add(this.labelNumberOfBooking);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.bookingGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BookingGUI";
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
    }
}