using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace sad
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection("Data Source=SPIRO4-PC;Initial Catalog=TryNow;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String date = DateTime.Today.ToString("dd/MM/yyyy");
            String time = DateTime.Now.ToString("h:mm:ss tt");
            sc.Open();
            SqlCommand scom = new SqlCommand("Select * from Login_Details where Username = '"+TextBox1.Text+"' and Password = '"+TextBox2.Text+"'",sc);
            scom.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(scom);
            sda.Fill(ds);
            sc.Close();
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)

            {
                sc.Open();
                SqlCommand insert = new SqlCommand("insert into log(Username,Time,Date) values(@param1,@param2,@param3)", sc);
                insert.Parameters.AddWithValue("@param1", TextBox1.Text);
                insert.Parameters.AddWithValue("@param2", time);
                insert.Parameters.AddWithValue("@param3", date);
                insert.ExecuteNonQuery();
                sc.Close();
                
                Label3.Text = "Login Successful";
                
            }
            else
            {
                 Label3.Text = "Login Failed";
            }
            //sc.Open();
            //SqlCommand insert = new SqlCommand("insert into log(Username,Time,Date) values(@param1,@param2,@param3)", sc);
            //insert.Parameters.AddWithValue("@param1", TextBox1.Text);
            //insert.Parameters.AddWithValue("@param2", time);
            //insert.Parameters.AddWithValue("@param3", date);

            //insert.ExecuteNonQuery();
            //sc.Close();
        }

       

       
    }
}
