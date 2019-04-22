﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Uber_Eats_Database_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text += Helper.currentUserName;
            if (Helper.currentUserRole == 1) //Customer
            {
                ToggleUser(true);
            }
            else if (Helper.currentUserRole == 2) //Delivery Partner
            {
                ToggleUser(false);
            }
            else //Admin
            {

            }
        }
        private void ToggleUser(bool UserEnable)
        {
            //Enable Partner Controls
            PendingOrdersBtn.Enabled = !UserEnable;
            PendingOrdersBtn.Visible = !UserEnable;
            DeliveredOrdersBtn.Enabled = !UserEnable;
            DeliveredOrdersBtn.Visible = !UserEnable;
            DAccountBtn.Enabled = !UserEnable;
            DAccountBtn.Visible = !UserEnable;
            //Disable Customer Controls
            OrdersBtn.Enabled = UserEnable;
            OrdersBtn.Visible = UserEnable;
            AccountBtn.Enabled = UserEnable;
            AccountBtn.Visible = UserEnable;
            CartBtn.Enabled = UserEnable;
            CartBtn.Visible = UserEnable;
            MenusBtn.Enabled = UserEnable;
            MenusBtn.Visible = UserEnable;
        }
        
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenusBtn_Click(object sender, EventArgs e)
        {
            //Menus menuform = new Menus();
            //menuform.Show();
            //this.Hide();
        }

        private void DAccountBtn_Click(object sender, EventArgs e)
        {
            //Account acc = new Account();
            //acc.Show();
            //this.Hide();
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            //Account acc = new Account();
            //acc.Show();
            //this.Hide();
            CustomerAccount ac = new CustomerAccount();
            ac.Show();
            this.Hide();
        }

        private void DeliveredOrdersBtn_Click(object sender, EventArgs e)
        {
            //Delivered d = new Delivered();
            //d.Show();
            //this.Hide();
        }

        private void PendingOrdersBtn_Click(object sender, EventArgs e)
        {
            //Porders p = new Porders();
            //p.Show();
            //this.Hide();
        }

        private void CartBtn_Click(object sender, EventArgs e)
        {
            //Cart c = new Cart();
            //c.Show();
            //this.Hide();
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            //Orders o = new Orders();
            //o.Show();
            //this.Hide();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            PendingDelivering pd = new PendingDelivering();
            pd.Show();
            this.Hide();
            pd.FormClosing += letsShow;
            
        }
        public void letsShow(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        #region Buttons Hovers
        private void DAccountBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void DAccountBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void MenusBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void AccountBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void DeliveredOrdersBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void PendingOrdersBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void CartBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void OrdersBtn_MouseEnter(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Green);
        }

        private void AccountBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void MenusBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void PendingOrdersBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void CartBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void OrdersBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }

        private void DeliveredOrdersBtn_MouseLeave(object sender, EventArgs e)
        {
            Helper.onHover((Button)sender, Color.Black);
        }
        #endregion
    }
}
