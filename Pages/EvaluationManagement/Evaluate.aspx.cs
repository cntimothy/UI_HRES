using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controls;
using FineUI;

namespace HRES.Pages.EvaluationManagement
{
    public partial class Evaluate : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindEvaluatedToGrid();
            }
        }

        #region Event
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }
        #endregion

        #region Private Method
        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            string evaluatorID = Session["UserID"].ToString();
            if (EvaluationManagementCtrl.GetEvaluatedByEvaluator(ref table, evaluatorID, ref exception))
            {
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            else
            {
                Alert.ShowInTop("获取被考评人信息失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}