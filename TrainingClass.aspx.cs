﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagement
{
    public partial class TrainingClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection
                ("Server=LAPTOP-SMQPLLME\\SQLEXPRESS; UId=admin1; Password=123456; Database=clubone;");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct className from TrainingClass", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dlTrainingClass.DataSource = dt;
                dlTrainingClass.DataBind();

                SqlCommand cmd2 = new SqlCommand("select name, age, email, phone, experience from Tutor", conn);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dlTutor.DataSource = dt2;
                dlTutor.DataBind();
            }
        }

        protected void BookingTrainingClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookingTrainingClass.aspx");
        }
    }
}