using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;
using DataStructure;
using System.Web.Script.Serialization;
using System.Data;
using AspNet = System.Web.UI.WebControls;
using System.Text;

namespace HRES.Pages.EvaluatorManagement
{
    public partial class iframe_CheckEvaluator : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                Panel1.Title = Request.QueryString["name"] + "的考评人名单";
                BindEvaluatorToGrid();
                BindSettedEvaluatorToGrid();         //显示已设置考评人名单
                Button_Reject.OnClientClick = Window1.GetShowReference("../Common/iframe_Comment.aspx?id=" + Request.QueryString["id"] + "&parent=checkevaluator", "审核意见");
            }
        }

        #region Event
       
        protected void Button_Set_Click(object sender, EventArgs e)
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            if (EvaluatorManagementCtrl.RandomGeneEvaluator(evaluatedID, ref exception))
            {
                Alert.ShowInTop("设置成功！", MessageBoxIcon.Information);
                BindSettedEvaluatorToGrid();
                return;
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region Private Method
        private void BindEvaluatorToGrid()
        {
            DataTable table = new DataTable();
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            if (EvaluatorManagementCtrl.GetEvaluator(ref table, evaluatedID, ref exception))
            {
                table.DefaultView.Sort = "Relation ASC";
                Grid1.DataSource = table.DefaultView;
                Grid1.DataBind();
            }
            else
            {
                table.Clear();
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }

        /// <summary>
        /// 显示已设置的考评人名单
        /// </summary>
        private void BindSettedEvaluatorToGrid()
        {
            string exception = "";
            DataTable dt = new DataTable();
            string evaluatedID = Request.QueryString["id"];
            if (EvaluatorManagementCtrl.GetSettedEvaluator( evaluatedID,ref dt, ref exception))
            {
                Grid2.DataSource = dt;
                Grid2.DataBind();
            }
        }
        #endregion
    }
}