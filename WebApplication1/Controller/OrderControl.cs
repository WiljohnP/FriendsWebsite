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
    }
}