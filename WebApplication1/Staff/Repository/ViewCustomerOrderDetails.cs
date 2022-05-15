using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Staff.Repository
{
    public class ViewCustomerOrderDetails
    {
        public class GetCustomerOrderDetails
        {
            public string OrderId { get; set; }
            public string OrderMenuId { get; set; }
            public string UEN { get; set; }
            public string Category { get; set; }
            public string Menu { get; set; }
            public string ImagePath { get; set; }
            public string Price { get; set; }
            public string CreatedDate { get; set; }
            public string ModifiedDate { get; set; }
            public string Quantity { get; set; }
            public string OrderState { get; set; }
        }


        public static GetCustomerOrderDetails getCustomerOrderDetails(int OrderId)
        {

            GetCustomerOrderDetails customerOrderDetails = null;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {

                String query = "  Select [dbo].[Order].Id as OrderId,[dbo].[OrderMenu].Id as OrderMenuId, [dbo].[Table].uen, [dbo].[Food].category, [dbo].[Food].menu,[dbo].[Food].path,[dbo].[Food].price,[dbo].[Order].createdDt,[dbo].[Order].modifiedDt,[dbo].[OrderMenu].Quantity,[dbo].[OrderState].orderState FROM [dbo].[Order] inner join  [dbo].[Table] on [dbo].[Order].tableId=[dbo].[Table].Id inner join  [dbo].[OrderMenu] on [dbo].[Order].Id=[dbo].[OrderMenu].OrderId inner join [dbo].[OrderState] on [dbo].[OrderMenu].OrderStateId=[dbo].[OrderState].Id inner join Food on[dbo].[OrderMenu].FoodId=[dbo].[Food].Id Where [dbo].[Order].Id=@OrderId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@OrderId", OrderId);
                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            customerOrderDetails = new GetCustomerOrderDetails()
                            {
                                OrderId = rdr.GetValue(0).ToString(),
                                OrderMenuId = rdr.GetValue(1).ToString(),
                                UEN = rdr.GetValue(2).ToString(),
                                Category = rdr.GetValue(3).ToString(),
                                Menu = rdr.GetValue(4).ToString(),
                                ImagePath = rdr.GetValue(5).ToString(),
                                Price = rdr.GetValue(6).ToString(),
                                CreatedDate = rdr.GetValue(7).ToString(),
                                ModifiedDate = rdr.GetValue(8).ToString(),
                                Quantity = rdr.GetValue(9).ToString(),
                                OrderState = rdr.GetValue(10).ToString()
                            };
                        }

                        rdr.Close();
                        command.Dispose();
                        connection.Close();
                    }
                    else
                    {
                        rdr.Close();
                        command.Dispose();
                        connection.Close();
                    }

                }

                return customerOrderDetails;
            }
        }
    }
}