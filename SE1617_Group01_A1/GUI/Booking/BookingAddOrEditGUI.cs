using SE1617_Group01_A1.Models;
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
        private CinemaContext context;
        private Booking? booking = null;
        private Show? show = null;
        public CheckBox[]? checkBoxes = null;
        private char[]? seats = null;
        private int col;
        private int row;

        public BookingAddOrEditGUI(Booking? booking, Show? show, char[] seats)
        {
            context = new CinemaContext();
            InitializeComponent();
            Room? room = show != null ? context.Rooms.First<Room>(room => room.RoomId == show.RoomId) : null;
            if (room != null)
            {
                this.col = room.NumberCols ?? default(int);
                this.row = room.NumberRows ?? default(int);
            }
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
            this.textBoxAmount.Enabled = false;
            this.textBoxAmount.Text = "0"; 

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
                        checkBox.MouseClick += CheckBox_MouseClick;
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

        private void CheckBox_MouseClick(object? sender, MouseEventArgs e)
        {
            if (checkBoxes != null)
            {
                int count = 0;
                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i].Checked && checkBoxes[i].Enabled == true)
                    {
                        count += 1;
                    }
                }
                this.textBoxAmount.Text = show != null ? (show.Price * count).ToString() : "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.show != null)
            {
                string name = this.textBoxName.Text;
                string amountParam = this.textBoxAmount.Text;
                decimal amount = decimal.Parse(amountParam);
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
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }
    }

}
