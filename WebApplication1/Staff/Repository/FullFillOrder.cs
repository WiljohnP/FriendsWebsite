using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Staff.Repository
{
    public class FullFillOrder
    {
        //GET Order States list for dropdown
        public static DataTable getOrderStates()
        {
            DataTable data = new DataTable();

            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;

            String query = "Select Id,OrderState from OrderState";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        con.Close();
                        sda.Dispose();
                        return dt;

                    }
                }
            }
        }


        //FullFill Customer Order
        public static bool fullFillCustomerOrder(int orderId,int orderStateId)
        {
            bool confirm = false;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sqlUpdateOrderTable = "Update [dbo].[Order] Set orderStateId =@orderStateId, modifiedDt=@modifiedDt Where Id =@OrderId";
                
                using (SqlCommand cmdOrder = new SqlCommand(sqlUpdateOrderTable, connection))
                {
                    connection.Open();
                    cmdOrder.Parameters.AddWithValue("@OrderId", orderId);
                    cmdOrder.Parameters.AddWithValue("@orderStateId", orderStateId);
                    cmdOrder.Parameters.AddWithValue("@modifiedDt", DateTime.Now.ToString());

                    if (cmdOrder.ExecuteNonQuery() > 0)
                    {
                        cmdOrder.Dispose();
                        string sqlUpdateOrderMenuTable = "Update [dbo].[OrderMenu] Set OrderStateId =@OrderStateId Where OrderId =@OrderId";
                        using (SqlCommand cmdOrderMenu = new SqlCommand(sqlUpdateOrderMenuTable, connection))
                        {
                            cmdOrderMenu.Parameters.AddWithValue("@OrderId", orderId);
                            cmdOrderMenu.Parameters.AddWithValue("@OrderStateId", orderStateId);
                            if (cmdOrderMenu.ExecuteNonQuery() > 0)
                            {
                                confirm = true;
                                cmdOrderMenu.Dispose();
                                connection.Close();
                            }

                        }

                    }
                   
                }
            }
            return confirm;
        }


        //Get Selected Order State


        //return the detail model for update or detail
        public static string getSelectedOrderStateId(int OrderId)
        {
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            var selectedOrderStateId="";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sql = "Select orderStateId from [dbo].[Order] where Id=@OrderId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@OrderId", OrderId);
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

    }
}