using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;

namespace HRES.Pages.Common
{
    public partial class iframe_Comment : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                Button_Cancel.OnClientClick = ActiveWindow.GetConfirmHideReference();
            }
        }

        protected void Button_Reject_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (TextArea_Comment.Text == "")
            {
                Alert.Show("请输入审核意见！");
                return;
            }
            if (TextArea_Comment.Text.Length > 50)
            {
                Alert.Show("最多输入50字");
                return;
            }
            if (Request.QueryString["parent"] == "checkpostbook")
            {
                if (PostBookManagementCtrl.SetRejected(Request.QueryString["id"], ref exception) &&
                    PostBookManagementCtrl.UpdateComment(TextArea_Comment.Text, Request.QueryString["id"], ref exception))
                {
                    Alert.ShowInTop("设置成功！\n窗口即将关闭", MessageBoxIcon.Information);
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
                }
                else
                {
                    Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else if (Request.QueryString["parent"] == "checkevaluator")
            {
                if (EvaluatorManagementCtrl.SetRejected(Request.QueryString["id"], ref exception) &&
                    EvaluatorManagementCtrl.UpdateComment(TextArea_Comment.Text, Request.QueryString["id"], ref exception))
                {
                    Alert.ShowInTop("设置成功！\n窗口即将关闭", MessageBoxIcon.Information);
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
                }
                else
                {
                    Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else if(Request.QueryString["parent"] == "checkevaluatetable")
            {
                if (EvaluateTableManagementCtrl.SetRejected(Request.QueryString["id"], ref exception) &&
                    EvaluateTableManagementCtrl.UpdateComment(TextArea_Comment.Text, Request.QueryString["id"], ref exception))
                {
                    Alert.ShowInTop("设置成功！\n窗口即将关闭", MessageBoxIcon.Information);
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
                }
                else
                {
                    Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }
    }
}