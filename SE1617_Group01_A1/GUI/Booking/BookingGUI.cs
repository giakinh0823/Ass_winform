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
        private int col = 0;
        private int row = 0;
        private char[]? seats = null;
        public BookingGUI(Show? show)
        {
            InitializeComponent();
            Room? room = show!= null? RoomDAO.Get(show.RoomId): null;
            this.col = room!=null ? room.NumberCols : 0;
            this.row = room != null ? room.NumberRows : 0;
            checkBoxes = new CheckBox[this.col * this.row];
            seats = new char[this.col * this.row];
            if (show != null)
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
            if (Setting.Username == null)
            {
                this.btnCreate.Visible = false;
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
                        checkBox.AutoSize = true;
                        checkBox.Width = 84;
                        checkBox.Enabled = false;
                        checkBox.Anchor = AnchorStyles.None;
                        checkBoxes[count] = checkBox;
                        this.flowLayoutPanel.Controls.Add(checkBox);
                        count++;
                        if (j + 1 == this.col)
                        {
                            this.flowLayoutPanel.SetFlowBreak(checkBox, true);
                        }
                    }
                }
            }
        }


        public void UpDateCheckBox()
        {
            if (checkBoxes != null)
            {
                this.flowLayoutPanel.Controls.Clear();
                int count = 0;
                for (int i = 0; i < this.row; i++)
                {
                    for (int j = 0; j < this.col; j++)
                    {
                        CheckBox checkBox = checkBoxes[count];
                        if (this.seats !=null && this.seats[count].Equals('1'))
                        {
                            checkBox.Checked = true;
                        }
                        else
                        {
                            checkBox.Checked = false;
                        }
                        checkBoxes[count] = checkBox;
                        this.flowLayoutPanel.Controls.Add(checkBox);
                        if (j + 1 == this.col)
                        {
                            this.flowLayoutPanel.SetFlowBreak(checkBox, true);
                        }
                        count++;
                    }
                }
                this.flowLayoutPanel.AutoScroll = true;
            }
        }



        private void BookingGUI_Load(object sender, EventArgs e)
        {

        }

        private void loadData(DataTable dataTable)
        {
            if (this.seats != null)
            {
                Array.Fill(this.seats, '0');
            }
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

            if(Setting.Username != null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                bookingGridView.Columns.Add(btnDelete);
            }

            numberOfBooking.Text = (bookingGridView.Rows.Count - 1).ToString();
            if (this.seats != null)
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Setting.Username != null)
            {
                if(show!=null && this.seats != null)
                {
                    BookingAddOrEditGUI bookingAddOrEditGUI = new BookingAddOrEditGUI(null, show, this.seats);
                    DialogResult dialogResult = bookingAddOrEditGUI.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        DataTable dataTable = BookingDAO.findByShowDataTable(show.ShowId);
                        bookingGridView.Columns.Clear();
                        bookingGridView.Refresh();
                        if (bookingGridView.Rows.Count > 0)
                        {
                            bookingGridView.Rows.Clear();
                        }
                        loadData(dataTable);
                    }
                }
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
                Booking? booking = BookingDAO.Get(bookingId);
                if(booking != null)
                {
                    if (Setting.Username!=null && bookingGridView.Columns["Delete"]!=null 
                        && e.ColumnIndex == bookingGridView.Columns["Delete"].Index)
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
                    else if (bookingGridView.Columns["Detail"]!=null 
                        && e.ColumnIndex == bookingGridView.Columns["Detail"].Index)
                    {
                        BookingDetailGUI bookingDetailGUI = new BookingDetailGUI(booking, show);
                        bookingDetailGUI.ShowDialog();
                    }
                }
            }   
        }

    }

}
