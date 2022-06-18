using Ciname.GUI.BookingController;
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

namespace Ciname.GUI.ShowControl
{
    public partial class ShowGUI : Form
    {
        public ShowGUI()
        {
            InitializeComponent();
            this.btnCreate.Visible = false;
            if (Setting.Username != null)
            {
                this.btnCreate.Visible = true;
            }
        }

        private void ShowGUI_Load(object sender, EventArgs e)
        {
            DataTable dataTable = ShowDAO.GetDataTable();
            loadData(dataTable);
            this.comboBoxFilm.DataSource = FilmDAO.GetDataTable();
            this.comboBoxFilm.DisplayMember = "Title";
            this.comboBoxFilm.ValueMember = "FilmId";
            this.comboBoxRoom.DataSource = RoomDAO.GetDataTable();
            this.comboBoxRoom.DisplayMember = "Name";
            this.comboBoxRoom.ValueMember = "RoomId";
        }

        private void loadData(DataTable dataTable) { 
        
            showGridView.DataSource = dataTable;
            int countColumn = dataTable.Columns.Count;
            showGridView.Columns["ShowID"].Visible = false;
            showGridView.Columns["Status"].Visible = false;

            if (Setting.Username != null)
            {
                DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
                {
                    Name = "Bookings",
                    Text = "Bookings",
                    UseColumnTextForButtonValue = true
                };

                showGridView.Columns.Insert(countColumn, btnBooking);
              

                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };

                showGridView.Columns.Add(btnEdit);

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                showGridView.Columns.Add(btnDelete);
            }
            else
            {
                DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
                {
                    Name = "Bookings",
                    Text = "Bookings",
                    UseColumnTextForButtonValue = true
                };

                showGridView.Columns.Insert(countColumn, btnBooking);
            }
            labelTotalNumber.Text = (showGridView.Rows.Count-1).ToString();
        }

        private void showGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void showGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex< showGridView.Rows.Count-1 && e.RowIndex >= 0) 
            {
                int showId = (int)showGridView.Rows[e.RowIndex].Cells["ShowID"].Value;
                Show? show = ShowDAO.get(showId);
                if (Setting.Username != null)
                {
                    if (e.ColumnIndex == showGridView.Columns["Edit"].Index)
                    {
                        ShowAddEditGUI showAddEditGUI = new ShowAddEditGUI(show, this.dateTimePicker.Value);
                        DialogResult dialogResult = showAddEditGUI.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            showGridView.Columns.Clear();
                            showGridView.Refresh();
                            DataTable dataTable = ShowDAO.GetDataTable();
                            loadData(dataTable);
                        }
                    }
                    else if (e.ColumnIndex == showGridView.Columns["Delete"].Index)
                    {
                        DialogResult dialogResult =
                            MessageBox.Show("Do you wan't delete?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ShowDAO.Delete(showId);
                            showGridView.Columns.Clear();
                            showGridView.Refresh();
                            DataTable dataTable = ShowDAO.GetDataTable();
                            loadData(dataTable);
                        }
                    }
                    else if (e.ColumnIndex == showGridView.Columns["Bookings"].Index)
                    {
                        BookingGUI bookingGUI = new BookingGUI(show);
                        DialogResult dialogResult = bookingGUI.ShowDialog();
                    }
                }
                else
                {
                    if (e.ColumnIndex == showGridView.Columns["Bookings"].Index)
                    {
                        BookingGUI bookingGUI = new BookingGUI(show);
                        DialogResult dialogResult = bookingGUI.ShowDialog();
                    }
                }

            }
                
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Setting.Username != null)
            {
                ShowAddEditGUI showAddEditGUI = new ShowAddEditGUI(null, this.dateTimePicker.Value);
                DialogResult dialogResult = showAddEditGUI.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    showGridView.Columns.Clear();
                    showGridView.Refresh();
                    DataTable dataTable = ShowDAO.GetDataTable();
                    loadData(dataTable);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string? roomParam = this.comboBoxRoom.SelectedValue.ToString();
            string? filmParam = this.comboBoxFilm.SelectedValue.ToString();
            int roomId = int.Parse(roomParam);
            int filmId = int.Parse(filmParam);
            showGridView.Columns.Clear();
            showGridView.Refresh();
            DataTable dataTable = ShowDAO.FindByRoomAndFilmAndDateDataTable(this.dateTimePicker.Value, filmId, roomId);
            loadData(dataTable);
            labelTotalNumber.Text = (showGridView.Rows.Count-1).ToString();
        }

        private void ShowGUI_Activated(object sender, EventArgs e)
        {

        }
    }
}
