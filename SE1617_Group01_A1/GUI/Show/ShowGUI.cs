using Ciname.GUI.BookingController;
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

namespace Ciname.GUI.ShowControl
{
    public partial class ShowGUI : Form
    {
        private CinemaContext context;
        public ShowGUI()
        {
            context = new CinemaContext();
            InitializeComponent();
            this.btnCreate.Visible = false;
            if (Setting.Username != null)
            {
                this.btnCreate.Visible = true;
            }
        }

        private void ShowGUI_Load(object sender, EventArgs e)
        {
            List<Show> shows = context.Shows.OrderByDescending(show => show.ShowId).ToList<Show>();
            loadData(shows);
            this.comboBoxFilm.DataSource = context.Films.ToList();
            this.comboBoxFilm.DisplayMember = "Title";
            this.comboBoxFilm.ValueMember = "FilmId";
            this.comboBoxRoom.DataSource = context.Rooms.ToList();
            this.comboBoxRoom.DisplayMember = "Name";
            this.comboBoxRoom.ValueMember = "RoomId";
        }

        private void loadData(List<Show> shows) { 
        
            showGridView.DataSource = shows;
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

                showGridView.Columns.Add(btnBooking);
              

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

                showGridView.Columns.Add(btnBooking);
            }
            labelTotalNumber.Text = (showGridView.Rows.Count-1).ToString();
        }

        private void showGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void showGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex< showGridView.Rows.Count && e.RowIndex >= 0) 
            {
                int showId = (int)showGridView.Rows[e.RowIndex].Cells["ShowID"].Value;
                Show? show = context.Shows.First<Show>(item => item.ShowId == showId);
                if (Setting.Username != null)
                {
                    if (e.ColumnIndex == showGridView.Columns["Edit"].Index)
                    {
                        ShowAddEditGUI showAddEditGUI = new ShowAddEditGUI(show);
                        DialogResult dialogResult = showAddEditGUI.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            showGridView.Columns.Clear();
                            showGridView.Refresh();
                            List<Show> shows = context.Shows.OrderByDescending(show => show.ShowId).ToList<Show>();
                            loadData(shows);
                        }
                    }
                    else if (e.ColumnIndex == showGridView.Columns["Delete"].Index)
                    {
                        DialogResult dialogResult =
                            MessageBox.Show("Do you wan't delete?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            context.Shows.Remove(show);
                            context.SaveChanges();
                            showGridView.Columns.Clear();
                            showGridView.Refresh();
                            List<Show> shows = context.Shows.OrderByDescending(show => show.ShowId).ToList<Show>();
                            loadData(shows);
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
                ShowAddEditGUI showAddEditGUI = new ShowAddEditGUI(null);
                DialogResult dialogResult = showAddEditGUI.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    showGridView.Columns.Clear();
                    showGridView.Refresh();
                   List<Show> shows = context.Shows.OrderByDescending(show => show.ShowId).ToList<Show>();
                    loadData(shows);
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
            int? roomId = roomParam!=null ? int.Parse(roomParam) : null;
            int? filmId = filmParam!=null ? int.Parse(filmParam) : null;
            showGridView.Columns.Clear();
            showGridView.Refresh();
            List<Show> shows = context.Shows.Where(item => (item.RoomId == roomId && item.FilmId == filmId && item.ShowDate == this.dateTimePicker.Value)).ToList();
            loadData(shows);
            labelTotalNumber.Text = (showGridView.Rows.Count-1).ToString();
        }

        private void ShowGUI_Activated(object sender, EventArgs e)
        {

        }
    }
}
