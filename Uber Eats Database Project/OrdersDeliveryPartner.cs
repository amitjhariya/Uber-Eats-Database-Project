﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Uber_Eats_Database_Project
{
    public partial class OrdersDeliveryPartner : Form
    {
        int pending = 1, type;
        bool erg3 = false;
        DataSet ds;
        OracleDataAdapter adapter1, adapter2;
        OracleCommandBuilder builder;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public OrdersDeliveryPartner(int t)
        {
            InitializeComponent();
            type = t;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrdersDeliveryPartner_Shown(object sender, EventArgs e)
        {
            if (erg3)
                this.Close();
        }

        private void orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void food_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (type == 1)
            {
                DialogResult dialogResult = CustomMsgBox.Show("Do you want to take this order?", 2);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(orders.Rows[e.RowIndex].Cells[0].Value);
                    ds.Tables[0].Rows[e.RowIndex][4] = "pd";
                    OracleConnection con = new OracleConnection(Helper.constr);
                    builder = new OracleCommandBuilder(adapter1);
                    adapter1.Update(ds.Tables[0]);
                    con.Open();
                    OracleCommand cmd = new OracleCommand(@"insert into trip 
                                                        (order_id, deliverypartner_username, distance_of_trip, deliveryfees) 
                                                        values (" + id.ToString() + ", '" + Helper.currentUserName + "', " +
                                                        "ROUND(DBMS_RANDOM.VALUE(0,200),2), 0)", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                }
            }
        }

        private void OrdersDeliveryPartner_Load(object sender, EventArgs e)
        {
            if (type == pending)
            {
                try
                {
                    adapter1 = new OracleDataAdapter("select o.* from orders o where status = 'pp'", new OracleConnection(Helper.constr));
                    adapter2 = new OracleDataAdapter("select o.ORDER_ID, f.* from food f, order_food offf, orders o where o.ORDER_ID = offf.ORDER_ID and offf.RESTAURANT_NAME = f.RESTAURANT_NAME and offf.RESTAURANT_LOCATION = f.RESTAURANT_LOCATION and offf.FOOD_NAME= f.FOOD_NAME and o.status = 'pp'", new OracleConnection(Helper.constr));
                    ds = new DataSet();
                    adapter1.Fill(ds, "order");
                    adapter2.Fill(ds, "food");
                    DataRelation r1 = new DataRelation("fk1", ds.Tables[0].Columns["order_id"], ds.Tables[1].Columns["order_id"]);
                    ds.Relations.Add(r1);
                    BindingSource bs_Master = new BindingSource(ds, "order");
                    BindingSource bs_child1 = new BindingSource(bs_Master, "fk1");
                    orders.DataSource = bs_Master;
                    food.DataSource = bs_child1;
                }
                catch
                {
                    erg3 = true;
                    CustomMsgBox.Show("There's no orders to show");
                }
            }
            else
            {
                try
                {
                    adapter1 = new OracleDataAdapter("select o.* from orders o, trip t where t.DELIVERYPARTNER_USERNAME = '" + Helper.currentUserName + "' and t.ORDER_ID = o.ORDER_ID and o.status = 'd'", new OracleConnection(Helper.constr));
                    adapter2 = new OracleDataAdapter("select o.ORDER_ID, f.* from food f, order_food offf, orders o, trip t where o.ORDER_ID = offf.ORDER_ID and t.order_id = o.order_id and offf.RESTAURANT_NAME = f.RESTAURANT_NAME and offf.RESTAURANT_LOCATION = f.RESTAURANT_LOCATION and offf.FOOD_NAME= f.FOOD_NAME and t.DELIVERYPARTNER_USERNAME = '" + Helper.currentUserName + "' and o.status = 'd'", new OracleConnection(Helper.constr));
                    ds = new DataSet();
                    adapter1.Fill(ds, "order");
                    adapter2.Fill(ds, "food");
                    DataRelation r1 = new DataRelation("fk1", ds.Tables[0].Columns["order_id"], ds.Tables[1].Columns["order_id"]);
                    ds.Relations.Add(r1);
                    BindingSource bs_Master = new BindingSource(ds, "order");
                    BindingSource bs_child1 = new BindingSource(bs_Master, "fk1");
                    orders.DataSource = bs_Master;
                    food.DataSource = bs_child1;
                }
                catch
                {
                    erg3 = true;
                    CustomMsgBox.Show("There's no orders to show");
                }
            }
        }
    }
}
