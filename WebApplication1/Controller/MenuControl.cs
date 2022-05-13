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
    public class MenuControl
    {
        public DataTable retrieveMenuList()
        {
            DataTable data = new DataTable();

            Entity.Menu mn = new Entity.Menu();

            data = mn.getMenuList();
            return data;
        }

        public DataTable retrieveAvaiableMenu()
        {
            DataTable data = new DataTable();

            Entity.Menu mn = new Entity.Menu();

            data = mn.getAvailableMenu();
            return data;
        }

        public bool insertMenu(String menu, String category, Double price, String status, String path)
        {
            Entity.Menu mn = new Entity.Menu();
            mn.menu = menu;
            mn.category = category;
            mn.price = price;
            mn.status = status;
            mn.path = path;
            bool insertSuccess = mn.setMenu();
            return insertSuccess;
        }

        public DataTable retrieveMenuName(String menu)
        {
            DataTable data = new DataTable();

            Entity.Menu mn = new Entity.Menu();
            mn.menu = menu;
            data = mn.getMenuName();
            return data;
        }

        public DataTable retrieveMenuDetail(int id)
        {
            DataTable data = new DataTable();

            Entity.Menu mn = new Entity.Menu();
            mn.id = id;
            data = mn.getMenuDetail();
            return data;
        }

        public bool modifyMenu(int id, String menu, String category, Double price, String status, String path)
        {
            Entity.Menu mn = new Entity.Menu();
            mn.id = id;
            mn.menu = menu;
            mn.category = category;
            mn.price = price;
            mn.status = status;
            mn.path = path;
            bool updateSuccess = mn.updateMenu();
            return updateSuccess;
        }

        public bool removeMenu(int id)
        {
            Entity.Menu mn = new Entity.Menu();
            mn.id = id;
            bool deleteSuccess = mn.deleteMenu();
            return deleteSuccess;
        }
    }
}