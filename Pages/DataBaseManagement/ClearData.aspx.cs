using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;

namespace HRES.Pages.DataBaseManagement
{
    public partial class ClearDataBase : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            { 
                
            }
        }

        #region Event
        protected void Button_ClearAll_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (DataBaseManagementCtrl.ClearDataBase(ref exception))
            {
                Alert.ShowInTop("清空成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("清空失败！\n原因" + exception, MessageBoxIcon.Error);
            }
        }


        protected void Button_ClearQuotaLib_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (DataBaseManagementCtrl.ClearQuotaLib(ref exception))
            {
                Alert.ShowInTop("清空成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("清空失败！\n原因" + exception, MessageBoxIcon.Error);
            }
        }


        protected void Button_DeleteTempFiles_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (DataBaseManagementCtrl.ClearTempFiles(ref exception))
            {
                Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("删除失败！\n原因" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}