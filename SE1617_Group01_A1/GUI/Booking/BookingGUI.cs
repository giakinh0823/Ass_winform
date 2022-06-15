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
    public partial class BookingGUI : Form
    {
        private Show? show = null;
        private CheckBox[]? checkBoxes = null;
        private char[] seats = new char[100];
        public BookingGUI(Show? show)
        {
            InitializeComponent();
            checkBoxes = new CheckBox[100];
            if(show != null)
            {
                CreateCheckbox();
                this.show = show;
                DataTable dataTable = BookingDAO.findByShowDataTable(show.ShowId);
                loadData(dataTable);
            }
            else
            {
                this.show = null;
            }
        }
        public void CreateCheckbox()
        {
           int count = 0;
           for(int i = 0; i < 10; i++)
           {
                for (int j = 0; j < 10; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Enabled = false;
                    checkBox.Location = new Point(this.Location.X + this.Width/2 - (10*30/2) + j * 30, this.Location.Y + i * 30 + 50);
                    this.Controls.Add(checkBox);
                    checkBoxes[count] = checkBox;
                    count++;
                }
           }   
        }


        public void UpDateCheckBox()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
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
                    count++;
                }
            }
        }


        private void BookingGUI_Load(object sender, EventArgs e)
        {

        }

        private void loadData(DataTable dataTable)
        {
            Array.Fill(this.seats, '0');
            bookingGridView.DataSource = dataTable;
            bookingGridView.Columns["BookingID"].Visible = false;
            bookingGridView.Columns["ShowID"].Visible = false;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };

            bookingGridView.Columns.Add(btnDetail);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            bookingGridView.Columns.Add(btnDelete);
            numberOfBooking.Text = (bookingGridView.Rows.Count - 1).ToString();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BookingAddOrEditGUI bookingAddOrEditGUI = new BookingAddOrEditGUI(null, show, this.seats);
            DialogResult dialogResult =  bookingAddOrEditGUI.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                DataTable dataTable = BookingDAO.findByShowDataTable(show.ShowId);
                bookingGridView.Columns.Clear();
                bookingGridView.Refresh();
                if(bookingGridView.Rows.Count > 0)
                {
                    bookingGridView.Rows.Clear();
                }
                loadData(dataTable);
            }
        }

        private void bookingGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bookingGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < bookingGridView.Rows.Count - 1 && e.RowIndex >=0 )
            {
                int bookingId = (int)bookingGridView.Rows[e.RowIndex].Cells["BookingID"].Value;
                Booking booking = BookingDAO.Get(bookingId);
                if (e.ColumnIndex == bookingGridView.Columns["Delete"].Index)
                {
                    DialogResult dialogResult =
                        MessageBox.Show("Do you wan't delete?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        BookingDAO.Delete(booking.BookingId);
                        bookingGridView.Columns.Clear();
                        if (bookingGridView.Rows.Count > 0)
                        {
                            bookingGridView.Rows.Clear();
                        }
                        bookingGridView.Refresh();
                        DataTable dataTable = BookingDAO.findByShowDataTable(show.ShowId);
                        loadData(dataTable);
                    }
                }
                else if (e.ColumnIndex == bookingGridView.Columns["Detail"].Index)
                {
                    BookingDetailGUI bookingDetailGUI = new BookingDetailGUI(booking, show);
                    bookingDetailGUI.ShowDialog();
                }
            }   
        }
    }

}
