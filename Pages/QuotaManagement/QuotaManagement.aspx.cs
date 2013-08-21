using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using System.Data;

namespace HRES.Pages.QuotaManagement
{
    public partial class QuotaManagement : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindQuotaLibToGrid();
                Button_New.OnClientClick = Window_NewQuota.GetShowReference("iframe_NewQuota.aspx");
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
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string level1 = (string)keys[0];
                string level2 = (string)keys[1];
                if (QuotaManagementCtrl.DeleteQuota(level1, level2, ref exception))
                {
                    Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
                bindQuotaLibToGrid();
            }
        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindQuotaLibToGrid();
        }
        protected void Window_NewQuota_Close(object sender, WindowCloseEventArgs e)
        {
            bindQuotaLibToGrid();
        }
        #endregion

        #region Private Method
        private void bindQuotaLibToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (QuotaManagementCtrl.GetQuotaLib(ref table, ref exception))
            {
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }
        #endregion
    }
}