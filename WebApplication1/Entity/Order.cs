using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Entity
{
    public class Order
    {
        public int orderId;
        public int tableId;
        public int orderStateId;
        public DateTime createdDt;
        public DateTime modifiedDt;

        public int orderMenuId;
        public int foodId;
        public int quantity;
        public double price;

        public string datePart;
        public string yyyyPart;
        public string mmPart;
        public string ddPart;


        public DataTable getCartListExist()
        {
            DataTable data = new DataTable();

            String sql = "Select id from [dbo].[Order] where tableId = '" + tableId + "' and  orderStateId = 1";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getFoodIdExist()
        {
            DataTable data = new DataTable();

            String sql = "Select foodId from [dbo].[OrderMenu] where foodid = " + foodId + " and orderid = " + orderId + " ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public bool setOrder()
        {
            Object data = "";

            DataTable table = getCartListExist();

            //insert if order table is empty
            if (table.Rows.Count <= 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                con.Open();
                string query = "INSERT INTO [dbo].[Order] (tableid, orderstateid, createdDt) ";
                query += " VALUES (" + tableId + ", 1,GetDate()); SELECT SCOPE_IDENTITY();";
                query += "INSERT INTO [dbo].[OrderMenu] (orderId, orderstateid, foodId, quantity, price) ";
                query += " VALUES ((SELECT SCOPE_IDENTITY()), 1, " + foodId + ", " + quantity + ", '" + price + "');";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception Ex)
                {
                    con.Close();
                    return false;
                }
            }
            //for cart is not empty
            else
            {
                DataTable dt = new DataTable();

                orderId = Convert.ToInt32(table.Rows[0][0].ToString());
                dt = getFoodIdExist();

                //insert if menu not exist in cart
                if (dt.Rows.Count <= 0)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                    con.Open();
                    string query = "UPDATE [dbo].[Order] set modifiedDt = GetDate() where id = " + Convert.ToInt32(table.Rows[0][0].ToString()) + "; ";
                    query += "INSERT INTO [dbo].[OrderMenu] (orderId, orderstateid, foodId, quantity, price) ";
                    query += " VALUES (" + Convert.ToInt32(table.Rows[0][0].ToString()) + ", 1, " + foodId + ", " + quantity + ", '" + price + "');";

                    try
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception Ex)
                    {
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                //update if menu exist in cart
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                    con.Open();
                    string query = "UPDATE [dbo].[Order] set modifiedDt = GetDate() where id = " + Convert.ToInt32(table.Rows[0][0].ToString()) + "; ";
                    query += "UPDATE [dbo].[OrderMenu] set quantity = quantity + " + quantity + " where foodId = " + foodId + " and orderid = " + Convert.ToInt32(table.Rows[0][0].ToString()) + "; ";

                    try
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception Ex)
                    {
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public DataTable getCartList()
        {
            DataTable data = new DataTable();

            String sql = "Select f.path, f.menu, f.category, om.price, om.foodid, om.quantity, (om.price * om.quantity) as totPrice from [dbo].[Order] as o inner join  [dbo].[OrderMenu] as om on o.id = om.orderid";
            sql += " inner join [dbo].[Food] as f on f.id = om.foodid";
            sql += " where o.tableId = '" + tableId + "' and om.orderstateId = 1 and o.orderstateId = 1;";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getReceiptList()
        {
            DataTable data = new DataTable();

            String sql = "Select f.path, f.menu, f.category, om.price, om.foodid, SUM(om.quantity) as quantity, (om.price * SUM(om.quantity)) as totPrice, os.orderState from [dbo].[Order] as o inner join  [dbo].[OrderMenu] as om on o.id = om.orderid";
            sql += " inner join [dbo].[Food] as f on f.id = om.foodid";
            sql += " inner join [dbo].[OrderState] as os on os.id = om.OrderStateId";
            sql += " where o.tableId = " + tableId + " and om.orderstateId IN (3,4) and o.orderstateId IN (3,4)";
            sql += " group by f.path, f.menu, f.category, om.price, om.foodid, os.orderState;";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getPaymentList()
        {
            DataTable data = new DataTable();

            String sql = "Select f.path, f.menu, f.category, om.price, om.foodid, SUM(om.quantity) as quantity, (om.price * SUM(om.quantity)) as totPrice from [dbo].[Order] as o inner join  [dbo].[OrderMenu] as om on o.id = om.orderid";
            sql += " inner join [dbo].[Food] as f on f.id = om.foodid";
            sql += " where o.tableId = " + tableId + " and om.orderstateId = 4 and o.orderstateId = 4";
            sql += " group by f.path, f.menu, f.category, om.price, om.foodid;";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();
            return data;
        }

        public bool updateCartQuantity()
        {
            DataTable table = getCartListExist();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "UPDATE [dbo].[OrderMenu] set quantity = " + quantity + " where foodId = " + foodId + " and orderid = " + Convert.ToInt32(table.Rows[0][0].ToString()) + "; ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public bool deleteCartMenu()
        {
            DataTable table = getCartListExist();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "DELETE FROM [dbo].[OrderMenu] where foodId = " + foodId + " and orderid = " + Convert.ToInt32(table.Rows[0][0].ToString()) + "; ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public bool updateOrderState()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "";

            query = "UPDATE [dbo].[OrderMenu] set orderstateid = " + orderStateId + " where orderid = " + orderId + "; ";
                query += "UPDATE [dbo].[Order] set orderstateid = " + orderStateId + " where id = " + orderId + "; ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public bool updateOrderCheckedOut()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "";

            query = "UPDATE om SET om.orderstateid = 5 FROM [dbo].[OrderMenu] om ";
            query += " INNER JOIN [dbo].[Order] o ON om.orderId = o.id WHERE o.tableid = " + tableId + " and o.orderstateid = 4 and om.orderstateid = 4; ";
            query += "UPDATE [dbo].[Order] set orderstateid = 5 where tableid = " + tableId + " and orderstateid = 4; ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                bool deleteSuccess = deleteCart();

                if (deleteSuccess = true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public int checkAllOrderCompleted()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "SELECT count(*) FROM [dbo].[Order] WHERE tableid = " + tableId + " and orderstateid = 4 ";
            query += " and (SELECT count(*) FROM [dbo].[Order] WHERE tableid = " + tableId + " and orderstateid = 3) = 0;";
            SqlCommand com = new SqlCommand(query, con);
            int exists = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            return exists;
        }

        public bool deleteCart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "";

            query = "DELETE FROM [dbo].[OrderMenu] WHERE orderId IN ((SELECT id FROM [dbo].[Order] WHERE tableid = " + tableId + " and orderstateid = 1)) ";
            query += "DELETE FROM [dbo].[Order] where tableid = " + tableId + "  and orderstateid = 1; ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }
        public DataTable getDistinctYear()
        {
            DataTable data = new DataTable();

            String sql = "select DISTINCT (DATEPART(yy, createdDt)) AS Year from[dbo].[Order] where [Order].orderStateId = 5 ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getDistinctMonthFromYear()
        {
            DataTable data = new DataTable();

            String sql = "select DISTINCT (DATEPART(mm, createdDt)) AS Month from[dbo].[Order] where (DATEPART(yyyy, createdDt)) = "+ yyyyPart+ " and [Order].orderStateId = 5 ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getYearlySales()
        {
            DataTable data = new DataTable();

            String sql = "Select [Food].[Menu] AS 'Item Name', SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Sales Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt)) = " + datePart  + " GROUP BY [Food].[Menu]";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getYearlyTotalSales()
        {
            DataTable data = new DataTable();

            String sql = "Select SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Total Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt)) = " + datePart + " ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getDailySales()
        {
            DataTable data = new DataTable();

            String sql = "select [Food].[Menu] AS 'Item Name', SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Sales Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt) = " + yyyyPart + " AND DATEPART(mm, createdDt) = " + mmPart + " AND DATEPART(dd, createdDt) = " + ddPart + ") GROUP BY [Food].[Menu]";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getDailyTotalSales()
        {
            DataTable data = new DataTable();

            String sql = "Select SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Total Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt) = " + yyyyPart + " AND DATEPART(mm, createdDt) = " + mmPart + " AND DATEPART(dd, createdDt) = " + ddPart + ") ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getMonthlySales()
        {
            DataTable data = new DataTable();

            String sql = "select [Food].[Menu] AS 'Item Name', SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Sales Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt) = " + yyyyPart + " AND DATEPART(mm, createdDt) = " + mmPart + ") GROUP BY [Food].[Menu]";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public DataTable getMonthlyTotalSales()
        {
            DataTable data = new DataTable();

            String sql = "Select SUM([OrderMenu].[Quantity]*[OrderMenu].[Price]) AS 'Total Price' from [dbo].[OrderMenu] INNER JOIN [Food] on [OrderMenu].FoodId = [Food].Id INNER JOIN [Order] on [Order].Id = [OrderMenu].OrderId where [Order].orderStateId = 5 and (DATEPART(yy, createdDt) = " + yyyyPart + " AND DATEPART(mm, createdDt) = " + mmPart + ") ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }
        //Staff Portion
        /*=============Full Fill Order============*/
        //GET Order States list for dropdown
        public static DataTable getOrderStates()
        {
            DataTable data = new DataTable();

            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;

            String query = "Select Id,OrderState from OrderState where Id in (3,4)";
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


        //Fulfil Customer Order
        public static bool FulfilCustomerOrder(int OrderMenuId, int orderStateId)
        {
            bool confirm = false;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sqlUpdateOrderMenuTable = "Update [dbo].[OrderMenu] Set OrderStateId =@OrderStateId Where Id =@OrderMenuId";
                using (SqlCommand cmdOrderMenu = new SqlCommand(sqlUpdateOrderMenuTable, connection))
                {
                    connection.Open();
                    cmdOrderMenu.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                    cmdOrderMenu.Parameters.AddWithValue("@OrderStateId", orderStateId);
                    if (cmdOrderMenu.ExecuteNonQuery() > 0)
                    {
                        confirm = true;
                        cmdOrderMenu.Dispose();
                    }

                }

                //check if any more items unfulfilled in order
                string sqlSelectOrderMenuTableByOrderId = "select count(*) from [dbo].[OrderMenu] where OrderId = @OrderMenuId and OrderStateId = 3";
                using (SqlCommand cmdOrderMenuCheck = new SqlCommand(sqlSelectOrderMenuTableByOrderId, connection))
                {
                    cmdOrderMenuCheck.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                    //if there are no more unfulfilled items, order id to complete
                    string sqlSelectOrderIdByMenuId = "select OrderId from [dbo].[OrderMenu] where id = @OrderMenuId";
                    using (SqlCommand cmdSelectOrderCheck = new SqlCommand(sqlSelectOrderIdByMenuId, connection))
                    {
                        cmdSelectOrderCheck.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                        int check = Convert.ToInt32(cmdOrderMenuCheck.ExecuteScalar().ToString());
                        if (check == 0)
                        {
                            string sqlUpdateOrderTable = "Update [dbo].[Order] Set orderStateId =@orderStateId, modifiedDt=@modifiedDt Where Id =@OrderId";

                            using (SqlCommand cmdOrder = new SqlCommand(sqlUpdateOrderTable, connection))
                            {

                                cmdOrder.Parameters.AddWithValue("@OrderId", cmdSelectOrderCheck.ExecuteScalar().ToString());
                                cmdOrder.Parameters.AddWithValue("@orderStateId", orderStateId);
                                cmdOrder.Parameters.AddWithValue("@modifiedDt", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

                                if (cmdOrder.ExecuteNonQuery() > 0)
                                {
                                    cmdOrder.Dispose();
                                }

                            }
                        }
                    }
                }
                connection.Close();
            }
            return confirm;
        }


        //Get Selected Order State
        public static string getSelectedOrderStateId(int OrderMenuId)
        {
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            var selectedOrderStateId = "";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string sql = "Select orderStateId from [dbo].[OrderMenu] where Id=@OrderMenuId";
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


        /*================View Customer Orders=================*/

        //Get Customer Orders
        public static DataTable getCustomerOrders()
        {
            DataTable data = new DataTable();

            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;

            String query = "Select [dbo].[Order].Id as OrderId,[dbo].[OrderMenu].Id as OrderMenuId, [dbo].[Table].uen, [dbo].[Food].category, [dbo].[Food].menu,[dbo].[Food].path,[dbo].[Food].price,[dbo].[Order].createdDt,[dbo].[Order].modifiedDt,[dbo].[OrderMenu].Quantity,[dbo].[OrderState].orderState FROM [dbo].[Order] inner join  [dbo].[Table] on [dbo].[Order].tableId=[dbo].[Table].Id inner join  [dbo].[OrderMenu] on [dbo].[Order].Id=[dbo].[OrderMenu].OrderId inner join [dbo].[OrderState] on [dbo].[OrderMenu].OrderStateId=[dbo].[OrderState].Id inner join Food on[dbo].[OrderMenu].FoodId=[dbo].[Food].Id where [dbo].[OrderMenu].orderStateId = 3";
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
        //Delete Customer Menu Order Item
        public static bool DeleteCustomerMenuOrderItem(int OrderMenuId)
        {
            bool confirm = false;
            int orderId = 0;
            string constr = ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string getOrderIdSql = "Select OrderId from [dbo].[OrderMenu]  Where Id=@OrderMenuId";
                SqlCommand cmdGetOrderId = new SqlCommand(getOrderIdSql, connection);
                cmdGetOrderId.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                connection.Open();
                SqlDataReader rdrCheckOrderId = cmdGetOrderId.ExecuteReader();
                while (rdrCheckOrderId.Read())
                {
                    orderId = Int32.Parse(rdrCheckOrderId[0].ToString());
                    break;
                }
                cmdGetOrderId.Dispose();
                rdrCheckOrderId.Close();

                //DELETE FROM ORDER MENU TABLE
                string deleteOrderMenuSQL = "Delete From [dbo].[OrderMenu] Where Id=@OrderMenuId";
                using (SqlCommand cmdOrderMenu = new SqlCommand())
                {
                    cmdOrderMenu.CommandText = deleteOrderMenuSQL;
                    cmdOrderMenu.CommandType = CommandType.Text;
                    cmdOrderMenu.Connection = connection;
                    cmdOrderMenu.Parameters.AddWithValue("@OrderMenuId", OrderMenuId);
                    if (cmdOrderMenu.ExecuteNonQuery() > 0)
                    {
                        String checkOrderId = "SELECT COUNT(*) FROM [dbo].[OrderMenu] where OrderId=@orderId";
                        using (SqlCommand cmdCheckOrderId = new SqlCommand(checkOrderId, connection))
                        {
                            cmdCheckOrderId.Parameters.AddWithValue("@OrderId", orderId);
                            int count = (int)cmdCheckOrderId.ExecuteScalar();
                            if (count == 0)
                            {
                                string deleteOrderSql = "Delete From [dbo].[Order] Where Id=@OrderId";
                                using (SqlCommand cmdOrder = new SqlCommand(deleteOrderSql, connection))
                                {
                                    cmdOrder.Parameters.AddWithValue("@OrderId", orderId);
                                    cmdOrder.ExecuteNonQuery();
                                    cmdOrder.Dispose();
                                }
                            }
                        }

                        confirm = true;
                    }
                    connection.Close();
                }
                return confirm;
            }

        }


        //Get Selected Product Order Quantity
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
        public static bool updateItemQuantity(int orderMenuId, int quantity)
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
                    }
                    cmdOrder.Dispose();
                    connection.Close();

                }
            }
            return confirm;
        }



        /*================View Customer Orders Details=================*/
        public class ClassGetCustomerOrderDetails
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

        //Get Customer Order Details
        public static ClassGetCustomerOrderDetails getCustomerOrderDetails(int OrderId)
        {

            ClassGetCustomerOrderDetails customerOrderDetails = null;
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
                            customerOrderDetails = new ClassGetCustomerOrderDetails()
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


                    }
                    rdr.Close();
                    command.Dispose();
                    connection.Close();

                }

                return customerOrderDetails;
            }
        }
    }
}