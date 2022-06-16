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
    public partial class ViewSeatGUI : Form
    {
        private Booking? booking = null;
        private Show? show = null;
        public CheckBox[]? checkBoxes = null;
        private char[] seats = new char[100];

        public ViewSeatGUI()
        {
            InitializeComponent();
            checkBoxes = new CheckBox[100];
            CreateCheckbox();
        }

        public ViewSeatGUI(Show? show)
        {
            InitializeComponent();
            checkBoxes = new CheckBox[100];
            CreateCheckbox();
            this.show = show;
            DataTable dataTable = BookingDAO.findByShowDataTable(show.ShowId);
            loadData(dataTable);

        }

        public void CreateCheckbox()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Enabled = false;
                    checkBox.AutoSize = true;
                    this.Controls.Add(checkBox);
                    checkBoxes[count] = checkBox;
                    count++;
                    this.flowLayoutPanel.Controls.Add(checkBox);
                }
            }
        }


        public void UpDateCheckBox()
        {
            this.flowLayoutPanel.Controls.Clear();
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                CheckBox checkBox = checkBoxes[count];
                if (this.seats[count].Equals('1'))
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
                checkBox.Enabled = false;
                this.Controls.Add(checkBox);
                checkBoxes[count] = checkBox;
                this.flowLayoutPanel.Controls.Add(checkBox);
                count++;
            }
        }


        private void loadData(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                String seat = ((string)dr["SeatStatus"]).Trim();
                for (int j = 0; j < seat.Length; j++)
                {
                    if (seat[j].Equals('1'))
                    {
                        this.seats[j] = '1';
                    }
                }
            }
            UpDateCheckBox();
        }

    }
}
