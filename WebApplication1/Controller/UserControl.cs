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
    public class UserControl
    {
        public DataTable retrieveUserList()
        {
            DataTable data = new DataTable();

            Entity.User us = new Entity.User();

            data = us.getUserList();
            return data;
        }

        public bool insertUser(string username, string staffNumber, Int32 phoneNumber, int status, string password, int type)
        {
            Entity.User us = new Entity.User();
            us.username = username;
            us.staffNumber = staffNumber;
            us.phoneNumber = phoneNumber;
            us.status = status;
            us.password = hashPlaintext(password);
            us.type = type;
            bool insertSuccess = us.setUser();
            return insertSuccess;
        }

        public string validateLogin(string tb1, string tbpassword)
        {
            if (isUserExists(tb1))
            {
                string ret = validatePassword(tb1, tbpassword);
                if (ret != "wrong password")
                {
                    if (ret == "manager" || ret == "staff" || ret == "owner") { return ret; } // login successful
                    else { return "error"; } // error
                }
                else { return "fail"; } // wrong password
            } else { return "fail"; } // user doesnt exists

        }

        public bool isUserExists(string tb1)
        {
            Entity.User us = new Entity.User();
            int cu = us.checkUser(tb1);
            if (cu == 1)
                return true;
            else
                return false;
        }

        public string validatePassword(string tb1, string tbpassword)
        {
            Entity.User us = new Entity.User();
            string[] dr = us.getPass(tb1);
            string hashFromDB = dr[0];
            string role = dr[1];

            string hashFromInput = hashPlaintext(tbpassword);

            if (hashFromInput == hashFromDB)
            {
                return role;
            }
            else 
            {
                return "wrong password";
            }
        }

        public string hashPlaintext(string pass) 
        {
            var algorithm = SHA512.Create();
            var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }

    }
}