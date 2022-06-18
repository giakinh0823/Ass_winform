using Ciname.DAL;
using Ciname.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciname.GUI.BookingController
{

    public partial class BookingAddOrEditGUI : Form
    {
        private Booking? booking = null;
        private Show? show = null;
        public CheckBox[]? checkBoxes = null;
        private char[]? seats = null;
        private int col;
        private int row;

        public BookingAddOrEditGUI(Booking? booking, Show? show, char[] seats)
        {
            if (Setting.Username!=null)
            {
                InitializeComponent();
                Room? room = show != null ? RoomDAO.Get(show.RoomId) : null;
                this.col = room != null ? room.NumberCols : 0;
                this.row = room != null ? room.NumberRows : 0;
                checkBoxes = new CheckBox[this.col * this.row];
                this.show = show;
                this.seats = seats;
                if (booking != null)
                {
                    this.booking = booking;
                    CreateCheckbox();
                }
                else
                {
                    this.booking = null;
                    CreateCheckbox();
                }
            }

        }

        public void CreateCheckbox()
        {
            if (checkBoxes != null)
            {
                int count = 0;
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < this.col; j++)
                    {
                        CheckBox checkBox = new CheckBox();
                        if (this.seats!=null && this.seats[count].Equals('1'))
                        {
                            checkBox.Checked = true;
                            checkBox.Enabled = false;
                        }
                        checkBox.Width = 84;
                        checkBox.AutoSize = true;
                        checkBox.Anchor = AnchorStyles.None;
                        checkBoxes[count] = checkBox;
                        count++;
                        this.flowLayoutPanel.Controls.Add(checkBox);
                        if (j + 1 == this.col)
                        {
                            this.flowLayoutPanel.SetFlowBreak(checkBox, true);
                        }
                    }
                }
                this.flowLayoutPanel.AutoScroll = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.show != null)
            {
                string name = this.textBoxName.Text;
                string amountParam = this.textBoxAmount.Text;
                decimal amount;
                try
                {
                    amount = decimal.Parse(amountParam);
                }
                catch (Exception)
                {
                    MessageBox.Show("Amount must a double!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be >= 0!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name must be not empty!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                bool isChoose = false;
                string seats = "";
                if (checkBoxes != null)
                {
                    for (int i = 0; i < checkBoxes.Length; i++)
                    {
                        if (checkBoxes[i].Checked && this.seats!= null && this.seats[i].Equals('1') && checkBoxes[i].Enabled == true)
                        {
                            MessageBox.Show("Seat has bean selected!");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                        else if (checkBoxes[i].Checked && checkBoxes[i].Enabled == true)
                        {
                            seats += 1;
                            isChoose = true;
                        }
                        else
                        {
                            seats += 0;
                        }
                    }
                }
                if (!isChoose)
                {
                    MessageBox.Show("Please choose seats!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                Booking booking = new Booking();
                booking.Name = name;
                booking.Amount = amount;
                booking.SeatStatus = seats;
                booking.ShowId = this.show.ShowId;
                BookingDAO.Insert(booking);
            }
        }
    }

}
