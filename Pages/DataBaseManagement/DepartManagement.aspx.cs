using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using System.Text;
using System.Data;

namespace HRES.Pages.DataBaseManagement
{
    public partial class DepartManagement : System.Web.UI.Page
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDepartsToGrid();
            }
        }
        #endregion

        #region Event
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string id = (string)keys[0];
                if (DataBaseManagementCtrl.DeleteDepart(id, ref exception))
                {
                    Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                    bindDepartsToGrid();
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

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
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" +  exception, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Private Method
        private void bindDepartsToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DataBaseManagementCtrl.GetAllDepart(ref table, ref exception))
            {
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            else
            {
                Alert.ShowInTop("未能获取部门信息！/n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}