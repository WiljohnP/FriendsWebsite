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
                    return true;
                }
                catch (Exception Ex)
                {
                    return false;
                }
                con.Close();
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

            String sql = "Select f.path, f.menu, f.category, om.price, om.foodid, SUM(om.quantity) as quantity, (om.price * SUM(om.quantity)) as totPrice from [dbo].[Order] as o inner join  [dbo].[OrderMenu] as om on o.id = om.orderid";
            sql += " inner join [dbo].[Food] as f on f.id = om.foodid";
            sql += " where o.tableId = " + tableId + " and om.orderstateId IN (3,4) and o.orderstateId IN (3,4)";
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

            String sql = "select DISTINCT (DATEPART(yy, createdDt)) AS Year from[dbo].[Order]";

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
    }
}