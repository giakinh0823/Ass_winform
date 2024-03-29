﻿namespace Ciname.GUI.ShowControl
{
    partial class ShowAddEditGUI
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
            this.cBoxRoom = new System.Windows.Forms.ComboBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelSlot = new System.Windows.Forms.Label();
            this.cBoxFilm = new System.Windows.Forms.ComboBox();
            this.labelFirm = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cBoxSlot = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cBoxRoom
            // 
            this.cBoxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxRoom.FormattingEnabled = true;
            this.cBoxRoom.Location = new System.Drawing.Point(283, 74);
            this.cBoxRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxRoom.Name = "cBoxRoom";
            this.cBoxRoom.Size = new System.Drawing.Size(350, 38);
            this.cBoxRoom.TabIndex = 0;
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(182, 76);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(72, 30);
            this.labelRoom.TabIndex = 1;
            this.labelRoom.Text = "Room:";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(192, 148);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(62, 30);
            this.Date.TabIndex = 3;
            this.Date.Text = "Date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(283, 148);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(350, 35);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // labelSlot
            // 
            this.labelSlot.AutoSize = true;
            this.labelSlot.Location = new System.Drawing.Point(201, 232);
            this.labelSlot.Name = "labelSlot";
            this.labelSlot.Size = new System.Drawing.Size(53, 30);
            this.labelSlot.TabIndex = 5;
            this.labelSlot.Text = "Slot:";
            this.labelSlot.Click += new System.EventHandler(this.labelSlot_Click);
            // 
            // cBoxFilm
            // 
            this.cBoxFilm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFilm.FormattingEnabled = true;
            this.cBoxFilm.Location = new System.Drawing.Point(281, 312);
            this.cBoxFilm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxFilm.Name = "cBoxFilm";
            this.cBoxFilm.Size = new System.Drawing.Size(350, 38);
            this.cBoxFilm.TabIndex = 6;
            // 
            // labelFirm
            // 
            this.labelFirm.AutoSize = true;
            this.labelFirm.Location = new System.Drawing.Point(197, 312);
            this.labelFirm.Name = "labelFirm";
            this.labelFirm.Size = new System.Drawing.Size(56, 30);
            this.labelFirm.TabIndex = 7;
            this.labelFirm.Text = "Film:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(281, 394);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(350, 35);
            this.textBoxPrice.TabIndex = 9;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(190, 394);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(63, 30);
            this.labelPrice.TabIndex = 10;
            this.labelPrice.Text = "Price:";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(201, 488);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 70);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(466, 488);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 70);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cBoxSlot
            // 
            this.cBoxSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSlot.FormattingEnabled = true;
            this.cBoxSlot.Location = new System.Drawing.Point(283, 230);
            this.cBoxSlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxSlot.Name = "cBoxSlot";
            this.cBoxSlot.Size = new System.Drawing.Size(350, 38);
            this.cBoxSlot.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(854, 202);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 34);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ShowAddEditGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 652);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cBoxSlot);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelFirm);
            this.Controls.Add(this.cBoxFilm);
            this.Controls.Add(this.labelSlot);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.cBoxRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowAddEditGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxRoom;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelSlot;
        private System.Windows.Forms.ComboBox cBoxFilm;
        private System.Windows.Forms.Label labelFirm;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cBoxSlot;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}