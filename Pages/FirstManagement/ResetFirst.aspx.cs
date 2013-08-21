using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using System.Data;

namespace HRES.Pages.FirstManagement
{
    public partial class ResetFirst : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkSession();
                bindFirstToGrid();
            }
        }

        #region Event
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Reset")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string id = (string)keys[0];
                if (FirstManagementCtrl.ResetPassword(id, ref exception))
                {
                    Alert.ShowInTop("重置密码成功！新密码为000000", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("重置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
                bindFirstToGrid();
            }
        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindFirstToGrid();
        }
        #endregion

        #region Private Method
        private void bindFirstToGrid()
        {
            string exception = "";
            List<string> IDs = new List<string>();
            if (FirstManagementCtrl.GetAll(ref IDs, ref exception))
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                foreach (string id in IDs)
                {
                    table.Rows.Add(id);
                }
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }
        #endregion
    }
}