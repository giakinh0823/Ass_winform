using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciname.DAL;
using Ciname.DTL;

namespace Ciname.GUI.ShowControl
{
    public partial class ShowAddEditGUI : Form
    {
        private Show? show = null;
        public ShowAddEditGUI(Show? show)
        {
            InitializeComponent();
            this.cBoxRoom.DataSource = RoomDAO.GetDataTable();
            this.cBoxRoom.DisplayMember = "Name";
            this.cBoxRoom.ValueMember = "RoomId";
            this.cBoxFilm.DataSource = FilmDAO.GetDataTable();
            this.cBoxFilm.DisplayMember = "Title";
            this.cBoxFilm.ValueMember = "FilmId";
            this.cBoxSlot.DataSource = new List<int>() { 1,2,3,4,5,6,7,8,9};
            if (show != null)
            {
                this.show=show;
                dateTimePicker.Value = show.ShowDate;
                this.cBoxRoom.SelectedValue = show.RoomId;
                this.cBoxRoom.Enabled = false;
                this.dateTimePicker.Enabled = false;
                this.cBoxSlot.SelectedIndex = show.Slot-1;
                this.textBoxPrice.Text = show.Price.ToString();
                this.cBoxFilm.SelectedValue = show.FilmId;
            }
            else
            {
                this.show = null;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelSlot_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            try
            {
                price = decimal.Parse(this.textBoxPrice.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Price must a double!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Price must be > 0!");
                this.DialogResult = DialogResult.None;
                return;
            }
            string? filmParam = this.cBoxFilm.SelectedValue.ToString();
            string? slotParam = this.cBoxSlot.SelectedItem.ToString();

            if (show != null)
            {
                show.Slot = int.Parse(slotParam);
                show.FilmId = int.Parse(filmParam);
                show.Price = price;
                ShowDAO.Update(show);
                MessageBox.Show("That show edited!");
            }
            else
            {
                string? roomParam = this.cBoxRoom.SelectedValue.ToString();
                int slot = int.Parse(slotParam);
                int roomId = int.Parse(roomParam);
                if (ShowDAO.GetItemByDateAndSlotAndRoom(this.dateTimePicker.Value, slot, roomId) == null)
                {
                    show = new Show();
                    show.ShowDate = this.dateTimePicker.Value;
                    show.RoomId = roomId;
                    show.Slot = slot;
                    show.FilmId = int.Parse(filmParam);
                    show.Price = price;
                    ShowDAO.Insert(show);
                    MessageBox.Show("A new show added!");
                }
                else
                {
                    MessageBox.Show("Slot has been selected!");
                    this.DialogResult = DialogResult.None;
                }
                
            }
        }
    }
}
