using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using System.Text;

namespace HRES.Pages.DataBaseManagement
{
    public partial class DepartManagement : System.Web.UI.Page
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                writeDeparts();
            }
        }
        #endregion

        #region Event
        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string newDepart = TextBox_NewDepart.Text.Trim();
            if (newDepart == "")
            {
                Alert.ShowInTop("请输入新部门名称", MessageBoxIcon.Error);
                return;
            }
            if (newDepart.Length > 10)
            {
                Alert.ShowInTop("新部门名称过长，请重新输入", MessageBoxIcon.Error);
                return;
            }
            string exception = "";

            if (DataBaseManagementCtrl.AddDepart(newDepart, ref exception))
            {
                Alert.ShowInTop("设置成功！", MessageBoxIcon.Information);
                writeDeparts();
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" +  exception, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Private Method
        private void writeDeparts()
        {
            string exception = "";
            List<string> departList = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (DataBaseManagementCtrl.GetAllDepart(ref departList, ref exception))
            {
                foreach (string item in departList)
                {
                    sb.Append(item + " ");
                }
                Label_Departs.Text = sb.ToString();
            }
            else
            {
                Alert.ShowInTop("未能获取部门列表！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}