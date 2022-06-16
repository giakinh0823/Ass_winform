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

        public BookingDetailGUI()
        {
            InitializeComponent();
        }

        public BookingDetailGUI(Booking? booking, Show? show)
        {
            InitializeComponent();
            checkBoxes = new CheckBox[100];
            this.show = show;
            if (booking != null)
            {
                this.booking = booking;
                this.textBoxName.Text = booking.Name;
                this.textBoxAmount.Text = booking.Amount.ToString();
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
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    if (this.booking.SeatStatus[count].Equals('1'))
                    {
                        checkBox.Checked = true;
                    }
                    checkBox.Enabled = false;
                    checkBox.AutoSize = true;
                    this.Controls.Add(checkBox);
                    checkBoxes[count] = checkBox;
                    count++;
                    this.flowLayoutPanel.Controls.Add(checkBox);
                }
            }
        }
    }
}

