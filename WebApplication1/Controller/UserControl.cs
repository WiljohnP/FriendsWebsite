using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApplication1.Controller
{
    public class UserControl
    {
        public DataTable retrieveUserList()
        {
            DataTable data = new DataTable();

            WebApplication1.Entity.User us = new WebApplication1.Entity.User();

            data = us.getUserList();
            return data;
        }
    }
}