namespace Ciname.GUI.ShowControl
{
    partial class ShowGUI
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
            this.showGridView = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.comboBoxFilm = new System.Windows.Forms.ComboBox();
            this.labelFilm = new System.Windows.Forms.Label();
            this.labelRoom = new System.Windows.Forms.Label();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labelTheTotalNumber = new System.Windows.Forms.Label();
            this.labelTotalNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // showGridView
            // 
            this.showGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showGridView.Location = new System.Drawing.Point(19, 434);
            this.showGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showGridView.Name = "showGridView";
            this.showGridView.ReadOnly = true;
            this.showGridView.RowHeadersWidth = 72;
            this.showGridView.RowTemplate.Height = 37;
            this.showGridView.Size = new System.Drawing.Size(1510, 494);
            this.showGridView.TabIndex = 0;
            this.showGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showGridView_CellClick);
            this.showGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showGridView_CellContentClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(70, 294);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(254, 60);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Add a new";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // comboBoxFilm
            // 
            this.comboBoxFilm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilm.FormattingEnabled = true;
            this.comboBoxFilm.Location = new System.Drawing.Point(168, 78);
            this.comboBoxFilm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxFilm.Name = "comboBoxFilm";
            this.comboBoxFilm.Size = new System.Drawing.Size(302, 38);
            this.comboBoxFilm.TabIndex = 2;
            // 
            // labelFilm
            // 
            this.labelFilm.AutoSize = true;
            this.labelFilm.Location = new System.Drawing.Point(70, 80);
            this.labelFilm.Name = "labelFilm";
            this.labelFilm.Size = new System.Drawing.Size(56, 30);
            this.labelFilm.TabIndex = 3;
            this.labelFilm.Text = "Film:";
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(70, 224);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(72, 30);
            this.labelRoom.TabIndex = 5;
            this.labelRoom.Text = "Room:";
            this.labelRoom.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Location = new System.Drawing.Point(168, 216);
            this.comboBoxRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(302, 38);
            this.comboBoxRoom.TabIndex = 4;
            this.comboBoxRoom.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(168, 152);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(302, 35);
            this.dateTimePicker.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(507, 204);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(144, 64);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelTheTotalNumber
            // 
            this.labelTheTotalNumber.AutoSize = true;
            this.labelTheTotalNumber.Location = new System.Drawing.Point(70, 382);
            this.labelTheTotalNumber.Name = "labelTheTotalNumber";
            this.labelTheTotalNumber.Size = new System.Drawing.Size(203, 30);
            this.labelTheTotalNumber.TabIndex = 9;
            this.labelTheTotalNumber.Text = "The number of total:";
            // 
            // labelTotalNumber
            // 
            this.labelTotalNumber.AutoSize = true;
            this.labelTotalNumber.Location = new System.Drawing.Point(278, 382);
            this.labelTotalNumber.Name = "labelTotalNumber";
            this.labelTotalNumber.Size = new System.Drawing.Size(24, 30);
            this.labelTotalNumber.TabIndex = 10;
            this.labelTotalNumber.Text = "0";
            // 
            // ShowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1545, 944);
            this.Controls.Add(this.labelTotalNumber);
            this.Controls.Add(this.labelTheTotalNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.labelFilm);
            this.Controls.Add(this.comboBoxFilm);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.showGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowGUI";
            this.Activated += new System.EventHandler(this.ShowGUI_Activated);
            this.Load += new System.EventHandler(this.ShowGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showGridView;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox comboBoxFilm;
        private System.Windows.Forms.Label labelFilm;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labelTheTotalNumber;
        private System.Windows.Forms.Label labelTotalNumber;
    }
}