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
    public partial class BookingDetailGUI : Form
    {
        private Booking? booking = null;
        private Show? show = null;
        public CheckBox[]? checkBoxes = null;
        private int col = 0;
        private int row = 0;

        public BookingDetailGUI()
        {
            InitializeComponent();
        }

        public BookingDetailGUI(Booking? booking, Show? show)
        {
            InitializeComponent();
            this.show = show;
            Room? room = show != null ? RoomDAO.Get(show.RoomId) : null;
            this.col = room != null ? room.NumberCols : 0;
            this.row = room != null ? room.NumberRows : 0;
            checkBoxes = new CheckBox[this.col * this.row];
            if (booking != null)
            {
                this.booking = booking;
                this.textBoxName.Text = booking.Name;
                this.textBoxAmount.Text = booking.Amount.ToString();
                if (Setting.Username == null)
                {
                    this.textBoxName.Enabled = false;
                    this.textBoxAmount.Enabled = false;
                }
                CreateCheckbox();
            }
            else
            {
                this.booking = null;
                CreateCheckbox();
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
                        if (this.booking != null && this.booking.SeatStatus[count].Equals('1'))
                        {
                            checkBox.Checked = true;
                        }
                        checkBox.Enabled = false;
                        checkBox.AutoSize = true;
                        checkBox.Width = 84;
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
    }
}

