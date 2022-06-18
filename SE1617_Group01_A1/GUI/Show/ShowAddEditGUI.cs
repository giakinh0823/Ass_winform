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
        public ShowAddEditGUI(Show? show, DateTime datetime)
        {
            InitializeComponent();
            List<Room> rooms = RoomDAO.List();
            List<Room> newRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                if (show != null)
                {
                    List<Show>? listShows = ShowDAO.GetItemByDate(datetime, room.RoomId);
                    if (room.RoomId == room.RoomId || listShows == null || listShows.Count < 9)
                    {
                        newRooms.Add(room);
                    }
                }
                else {
                    List<Show>? listShows = ShowDAO.GetItemByDate(datetime, room.RoomId);
                    if(listShows==null || listShows.Count < 9)
                    {
                        newRooms.Add(room);
                    }
                }
            }
            this.cBoxRoom.DataSource = newRooms;
            this.cBoxRoom.DisplayMember = "Name";
            this.cBoxRoom.ValueMember = "RoomId";
            this.cBoxFilm.DataSource = FilmDAO.GetDataTable();
            this.cBoxFilm.DisplayMember = "Title";
            this.cBoxFilm.ValueMember = "FilmId";
            this.cBoxRoom.Enabled = false;
            this.dateTimePicker.Enabled = false;

            if (show != null)
            {
                List<dynamic> listSlot = new List<dynamic>();
                List<Show>? list = ShowDAO.GetItemByDate(show.ShowDate, show.RoomId);
                if (list != null && list.Count > 0)
                {
                    for(int i=0; i< 9; i++)
                    {
                        bool isHas = false;
                        foreach (Show item in list)
                        {
                            if(item.Slot != show.Slot)
                            {
                                if (i + 1 == item.Slot)
                                {
                                    isHas = true;
                                    break;
                                }
                            }
                        }
                        if (!isHas)
                        {
                            listSlot.Add(new { Key = i + 1, Value = i + 1 });
                        }
                    }
                }
                this.cBoxSlot.DataSource = listSlot;
                this.cBoxSlot.ValueMember = "Key";
                this.cBoxSlot.DisplayMember = "Value";


                this.show=show;
                dateTimePicker.Value = show.ShowDate;
                this.cBoxRoom.SelectedValue = show.RoomId;
                this.cBoxSlot.SelectedValue = show.Slot;
                this.textBoxPrice.Text = show.Price.ToString();
                this.cBoxFilm.SelectedValue = show.FilmId;
            }
            else
            {
                if(newRooms!=null && newRooms.Count > 0)
                {
                    List<Show>? list = ShowDAO.GetItemByDate(datetime, newRooms[0].RoomId);
                    List<dynamic> listSlot = new List<dynamic>();
                    if (list != null && list.Count > 0)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            bool isHas = false;
                            foreach (Show item in list)
                            {
                                if (i + 1 == item.Slot)
                                {
                                    isHas = true;
                                    break;
                                }
                            }
                            if (!isHas)
                            {
                                listSlot.Add(new { Key = i + 1, Value = i + 1 });
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            listSlot.Add(new { Key = i + 1, Value = i + 1 });
                        }
                    }
                    if (listSlot.Count > 0)
                    {
                        this.cBoxSlot.DataSource = listSlot;
                        this.cBoxSlot.ValueMember = "Key";
                        this.cBoxSlot.DisplayMember = "Value";
                    }
                    this.show = null;
                    this.dateTimePicker.Value = datetime;
                }
                else
                {
                    MessageBox.Show("Room is full");
                }
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

            string? filmParam = this.cBoxFilm.SelectedValue!=null ? this.cBoxFilm.SelectedValue.ToString(): null;
            string? slotParam = this.cBoxSlot.SelectedValue!=null ? this.cBoxSlot.SelectedValue.ToString(): null;

            if (show != null)
            {
                int slot = slotParam!=null ? int.Parse(slotParam): -1;
                int film = filmParam!=null ? int.Parse(filmParam): -1;
                if(slot!=-1 && film != -1)
                {
                    if (ShowDAO.GetItemByDateAndSlotAndRoom(show.ShowDate, slot, show.RoomId) != null)
                    {
                        MessageBox.Show("Slot has been selected!");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    show.Slot = slot;
                    show.FilmId = film;
                    show.Price = price;
                    ShowDAO.Update(show);
                    MessageBox.Show("That show edited!");
                }
                else
                {
                    MessageBox.Show("Can't set field slot or film!");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                string? roomParam = this.cBoxRoom.SelectedValue!= null ? this.cBoxRoom.SelectedValue.ToString() : null;
                int roomId = roomParam!=null ? int.Parse(roomParam) : -1;
                int slot = slotParam != null ? int.Parse(slotParam) : -1;
                int film = filmParam != null ? int.Parse(filmParam) : -1;
                if (roomId!=-1 && slot != -1 && film!=-1)
                {
                    if (ShowDAO.GetItemByDateAndSlotAndRoom(this.dateTimePicker.Value, slot, roomId) == null)
                    {
                        show = new Show();
                        show.ShowDate = this.dateTimePicker.Value;
                        show.RoomId = roomId;
                        show.Slot = slot;
                        show.FilmId = film;
                        show.Price = price;
                        ShowDAO.Insert(show);
                        MessageBox.Show("A new show added!");
                    }
                    else
                    {
                        MessageBox.Show("Slot has been selected!");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Can't save show!");
                }
                
            }
        }
    }
}
