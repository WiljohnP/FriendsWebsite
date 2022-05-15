using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Staff.Repository
{
    public class UpdateItemQuantity
    {

        //return the detail model for update or detail
        public static string getSelectedQuantity(int OrderMenuId)
        {
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            var selectedOrderStateId = "";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sql = "Select Quantity from [dbo].[OrderMenu] where Id=@OrderMenuId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            selectedOrderStateId = rdr[0].ToString();
                        }
                    }

                    rdr.Close();
                    command.Dispose();
                    connection.Close();


                }

                return selectedOrderStateId;
            }

        }




        //Update quantity for specfic product
        public static bool updateItemQuantity(int orderMenuId,int quantity)
        {
            bool confirm = false;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sqlUpdateOrderTable = "Update [dbo].[OrderMenu] Set Quantity=@ItemQuantity Where Id =@OrderMenuId";

                using (SqlCommand cmdOrder = new SqlCommand(sqlUpdateOrderTable, connection))
                {
                    connection.Open();
                    cmdOrder.Parameters.AddWithValue("@OrderMenuId", orderMenuId);
                    cmdOrder.Parameters.AddWithValue("@ItemQuantity", quantity);

                    if (cmdOrder.ExecuteNonQuery() > 0)
                    {
                        confirm = true;
                        cmdOrder.Dispose();
                        connection.Close();

                    }

                }
            }
            return confirm;
        }
    }
}