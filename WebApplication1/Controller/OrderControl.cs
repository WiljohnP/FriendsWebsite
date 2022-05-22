using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Controller
{
    public class OrderControl
    {
        public DataTable retrieveCartLstExist(int tableId)
        {
            DataTable data = new DataTable();

            Entity.Order mn = new Entity.Order();
            mn.tableId = tableId;
            data = mn.getCartListExist();
            return data;
        }

        public DataTable retrieveCartList(int tableId)
        {
            DataTable data = new DataTable();

            Entity.Order mn = new Entity.Order();
            mn.tableId = tableId;
            data = mn.getCartList();
            return data;
        }

        public DataTable retrieveReceiptList(int tableId)
        {
            DataTable data = new DataTable();

            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            data = od.getReceiptList();
            return data;
        }

        public DataTable retrievePaymentList(int tableId)
        {
            DataTable data = new DataTable();

            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            data = od.getPaymentList();
            return data;
        }

        public bool insertOrder(int tableId, int foodid, int quantity, double price)
        {
            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            od.foodId = foodid;
            od.quantity = quantity;
            od.price = price;
            bool insertSucccess = od.setOrder();
            return insertSucccess;
        }

        public bool modifyQuantity(int tableId, int foodid, int quantity)
        {
            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            od.foodId = foodid;
            od.quantity = quantity;
            bool updateSucccess = od.updateCartQuantity();
            return updateSucccess;
        }

        public bool removeOrderMenu(int tableId, int foodid)
        {
            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            od.foodId = foodid;
            bool deleteSucccess = od.deleteCartMenu();
            return deleteSucccess;
        }

        public DataTable retrieveCartId(int tableId)
        {
            DataTable data = new DataTable();

            Entity.Order mn = new Entity.Order();
            mn.tableId = tableId;
            data = mn.getCartListExist();
            return data;
        }

        public bool modifyOrderState(int orderId, int orderStateId)
        {
            Entity.Order od = new Entity.Order();
            od.orderId = orderId;
            od.orderStateId = orderStateId;
            bool updateSucccess = od.updateOrderState();
            return updateSucccess;
        }

        public int retrieveCheckAllOrderCompleted(int tableId)
        {
            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            int count = od.checkAllOrderCompleted();
            return count;
        }

        public bool modifyOrderCheckedOut(int tableId)
        {
            Entity.Order od = new Entity.Order();
            od.tableId = tableId;
            bool updateSucccess = od.updateOrderCheckedOut();
            return updateSucccess;
        }

        public DataTable getDistinctYear()
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            data = od.getDistinctYear();
            return data;
        }

        public DataTable getDistinctMonthFromYear(string yyyyPart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.yyyyPart = yyyyPart;
            data = od.getDistinctMonthFromYear();
            return data;
        }

        public DataTable getYearlySales(string datePart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.datePart = datePart;
            data = od.getYearlySales();
            return data;
        }

        public DataTable getYearlyTotalSales(string datePart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.datePart = datePart;
            data = od.getYearlyTotalSales();
            return data;
        }

        public DataTable getDailySales(string yyyyPart, string mmPart, string ddPart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.yyyyPart = yyyyPart;
            od.mmPart = mmPart;
            od.ddPart = ddPart;
            data = od.getDailySales();
            return data;
        }

        public DataTable getDailyTotalSales(string yyyyPart, string mmPart, string ddPart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.yyyyPart = yyyyPart;
            od.mmPart = mmPart;
            od.ddPart = ddPart;
            data = od.getDailyTotalSales();
            return data;
        }

        public DataTable getMonthlySales(string yyyyPart, string mmPart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.yyyyPart = yyyyPart;
            od.mmPart = mmPart;
            data = od.getMonthlySales();
            return data;
        }

        public DataTable getMonthlyTotalSales(string yyyyPart, string mmPart)
        {
            DataTable data;

            Entity.Order od = new Entity.Order();
            od.yyyyPart = yyyyPart;
            od.mmPart = mmPart;
            data = od.getMonthlyTotalSales();
            return data;
        }
        //Staff Portion
        //GET Order States list for dropdown

        public static DataTable getOrderStates()
        {
            return Entity.Order.getOrderStates();
        }
        //FullFill Customer Order
        public static bool fullFillCustomerOrder(int orderId, int orderStateId)
        {
            return Entity.Order.fullFillCustomerOrder(orderId, orderStateId);
        }

        //Get Selected Order State
        public static string getSelectedOrderStateId(int orderId)
        {
            return Entity.Order.getSelectedOrderStateId(orderId);
        }


        /*================View Customer Orders=================*/

        //Get Customer Orders
        public static DataTable getCustomerOrders()
        {
            return Entity.Order.getCustomerOrders();
        }

        //Delete Customer Menu Order Item
        public static bool DeleteCustomerMenuOrderItem(int orderMenuId)
        {
            return Entity.Order.DeleteCustomerMenuOrderItem(orderMenuId);
        }

        //Get Selected Product Order Quantity
        public static string getSelectedQuantity(int orderMenuId)
        {
            return Entity.Order.getSelectedQuantity(orderMenuId);
        }
        //Update quantity for specfic product
        public static bool updateItemQuantity(int orderMenuId, int quantity)
        {
            return Entity.Order.updateItemQuantity(orderMenuId, quantity);
        }

        //Get Customer Order Details
        public static Entity.Order.ClassGetCustomerOrderDetails getCustomerOrderDetails(int orderId)
        {
            return Entity.Order.getCustomerOrderDetails(orderId);
        }
    }
}