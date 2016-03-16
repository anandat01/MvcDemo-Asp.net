using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;

namespace AspMvcDemo.Models
{
    public class FirstModel
    {
        public class first {
            SqlConnection con = new SqlConnection("Data Source=(local);database=mvctest;user=YourUserName;password=YourPassword");
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }

            public List<first> getdata(int id, string name, string address) {
                if (id.ToString() == null) { id = 0; }
                List<first> objlist = new List<first>(5000);
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed ) {
                    con.Open();
                }
                string smt = "";
                if (id == 0)
                {
                    smt = "select id, name, address from mvcdemo";
                }
                else
                {
                    smt = "select id, name, address from mvcdemo where id='"+ id +"'";
                }
                SqlDataAdapter da = new SqlDataAdapter(smt, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Table");
                int i = 0;
                while (i<ds.Tables[0].Rows.Count) {
                    first obj1 = new first();
                    obj1.id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]);
                    obj1.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                    obj1.address = Convert.ToString(ds.Tables[0].Rows[i]["address"]);

                    objlist.Add(obj1);
                    i++;
                }
                return objlist;
            }
            public void updatedata(int id, string name, string address)
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {

                    con.Open();
                }
                string smt = "Update mvcdemo set name = '" + name + "', address = '" + address + "' where id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(smt, con);
                cmd.ExecuteNonQuery();

            }
            public void deletedata(int id)
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {

                    con.Open();
                }
                string smt = "delete from mvcdemo where id =  " + id + "";
                SqlCommand cmd = new SqlCommand(smt, con);
                cmd.ExecuteNonQuery();

            }
            public void insertdata(string name, string address) {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed) {
                    con.Open();
                }
                string smt = "insert into mvcdemo values ('" + name + "','" + address + "')";
                SqlCommand cmd = new SqlCommand(smt, con);
                cmd.ExecuteNonQuery();
            }

        }
    }
}