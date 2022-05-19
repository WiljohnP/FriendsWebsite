using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Staff.Repository
{
    public class ViewCustomerOrders
    {
        public static DataTable getCustomerOrders()
        {
            DataTable data = new DataTable();

            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;

            String query = " Select [dbo].[Order].Id as OrderId,[dbo].[OrderMenu].Id as OrderMenuId, [dbo].[Table].uen, [dbo].[Food].category, [dbo].[Food].menu,[dbo].[Food].path,[dbo].[Food].price,[dbo].[Order].createdDt,[dbo].[Order].modifiedDt,[dbo].[OrderMenu].Quantity,[dbo].[OrderState].orderState FROM [dbo].[Order] inner join  [dbo].[Table] on [dbo].[Order].tableId=[dbo].[Table].Id inner join  [dbo].[OrderMenu] on [dbo].[Order].Id=[dbo].[OrderMenu].OrderId inner join [dbo].[OrderState] on [dbo].[OrderMenu].OrderStateId=[dbo].[OrderState].Id inner join Food on[dbo].[OrderMenu].FoodId=[dbo].[Food].Id";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static bool DeleteCustomerMenuOrderItem(int OrderMenuId)
        {
            bool confirm = false;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {

                //DELETE FROM ORDER MENU TABLE
                string deleteOrderMenuSQL = "Delete From [dbo].[OrderMenu] Where Id=@OrderMenuId";
                using (SqlCommand cmdOrderMenu = new SqlCommand())
                {
                    cmdOrderMenu.CommandText = deleteOrderMenuSQL;
                    cmdOrderMenu.CommandType = CommandType.Text;
                    cmdOrderMenu.Connection = connection;
                    connection.Open();
                    cmdOrderMenu.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                    if (cmdOrderMenu.ExecuteNonQuery() > 0)
                    {
                        confirm = true;
                    }
                    connection.Close();
                }
                return confirm;
            }

        }
    }
    
}