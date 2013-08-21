using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using DataStructure;

namespace HRES.Pages.AccountManagement
{
    public partial class ChangePassword : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
        }

        protected void Button_ChangePassword_Click(object sender, EventArgs e)
        {
            string exception = "";
            string oldPassword = TextBox1.Text.Trim();
            string newPassword = TextBox2.Text.Trim();
            if (oldPassword.Length != 6 || newPassword.Length != 6)
            {
                Alert.ShowInTop("密码必须六位！");
                return;
            }
            if(checkNull(oldPassword, newPassword))
            {
                string id = Session["UserID"].ToString();
                if (AccountManagementCtrl.ChangePassword(id, LoginType.manager, newPassword, oldPassword, ref exception))
                {
                    Alert.ShowInTop("修改成功！请重新登录", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("修改失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }            
        }

        private bool checkNull(params string[] items)
        {
            foreach (string item in items)
            {
                if (item == "")
                {
                    return false;
                }
            }
            return true;
        }
    }
}