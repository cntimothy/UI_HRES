﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using DataStructure;

namespace HRES
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void IBLogin_Click(object sender, ImageClickEventArgs e)
        {
            string exception = "";
            UserInfo userInfo = new UserInfo();
            string id = UserName.Text; ;
            string passWord = Password.Text;
            if (id == "" || passWord == "")
            {
                ErrorMessage.Text = "用户名密码不能为空！";
                ErrorMessage.Visible = true;
                return;
            }
            LoginType loginType = (LoginType)Convert.ToInt32(LoginType.SelectedValue);
            if (LoginManagementCtrl.LoginIn(ref userInfo, id, passWord, loginType, ref exception))
            {
                Session["UserID"] = userInfo.Id;
                Session["UserName"] = userInfo.Name;
                Session["AccessLevel"] = userInfo.AccessLevel;
                Session["Depart"] = userInfo.Depart;
                Response.Redirect("Pages/HomePage.aspx");
            }
            else
            {
                ErrorMessage.Text = "请输入正确的用户名、密码并选择正确的身份！";
                ErrorMessage.Visible = true;
            }
        }
    }
}