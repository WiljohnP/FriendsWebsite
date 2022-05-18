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
    public class TableControl
    {
        public DataTable retrieveTableNo(String uen)
        {
            DataTable data = new DataTable();

            Entity.Table tb = new Entity.Table();
            tb.uen = uen;
            data = tb.getTableNo();
            return data;
        }

        public bool checkUENValid(String uen)
        {
            bool isValid = false;

            Entity.Table tb = new Entity.Table();
            tb.uen = uen;
            isValid = tb.CheckUENExists();
            return isValid;
        }
    }
}