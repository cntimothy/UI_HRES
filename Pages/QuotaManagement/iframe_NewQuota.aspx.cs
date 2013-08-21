using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;

namespace HRES.Pages.QuotaManagement
{
    public partial class iframe_NewQuota : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                //Button_Close.OnClientClick = ActiveWindow.GetHideReference();
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHideRefreshReference();
            }
        }

        #region Event
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (!CheckNull(new string[] { TextBox_Level1.Text, TextBox_Level2.Text, TextArea_Quota1.Text, TextArea_Quota2.Text, TextArea_Quota3.Text, TextArea_Quota4.Text }))
            {
                Alert.ShowInTop("项目不可为空！");
                return;
            }
            string level1 = TextBox_Level1.Text.Trim();
            string level2 = TextBox_Level2.Text.Trim();
            string[] quotas = new string[] { TextArea_Quota1.Text.Trim(), TextArea_Quota2.Text.Trim(), TextArea_Quota3.Text.Trim(), TextArea_Quota4.Text.Trim() };
            if (!checkNull(level1, level2, quotas[0], quotas[1], quotas[2], quotas[3]))
            {
                Alert.ShowInTop("请填写完整！", MessageBoxIcon.Error);
                return;
            }
            if (QuotaManagementCtrl.AddQuota(level1, level2, quotas, ref exception))
            {
                Alert.ShowInTop("保存成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("保存失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 检查参数是否为空，如果有空，返回false，否则返回true
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
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
        #endregion
    }
}