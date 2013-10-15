﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Web.Script.Serialization;
using Controls;

namespace HRES.Pages.EvaluateTableManagement
{
    public partial class iframe_ShowWCR : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkSession();
                Button_Close.OnClientClick = ActiveWindow.GetHideReference();
                bindWorkContentToDropDownList();
            }
        }

        #region Event
        protected void DropDownList1_SelectedChange(object sender, EventArgs e)
        {
            Dictionary<string, string> WCRDic = (new JavaScriptSerializer()).Deserialize<Dictionary<string, string>>((string)(ViewState["WCRDic"]));
            TextArea1.Text = WCRDic[DropDownList1.SelectedValue].Replace("\n", "");
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string title = DropDownList1.SelectedValue;
            if (title == "请选择")
            {
                Alert.Show("请先选择指标!");
                return;
            }
            string quota = TextArea1.Text;

            //去掉换行符
            title = title.Replace("\n", "").Replace("\r","");
            quota = quota.Replace("\n", "").Replace("\r", "");

            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(title, quota, title + "&" + quota) + ActiveWindow.GetHideReference());
        }
        #endregion

        #region Private Method
        private void bindWorkContentToDropDownList()
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            List<string[]> WCR = new List<string[]>();
            Dictionary<string, string> dic = new Dictionary<string,string>();
            if(EvaluateTableManagementCtrl.GetworkContntRequest(evaluatedID, ref WCR, ref exception))
            {
                foreach(string[] item in WCR)
                {
                    DropDownList1.Items.Add(item[0].Replace("\n", "").Replace("\r", ""), item[0].Replace("\n", "").Replace("\r", ""));
                    dic.Add(item[0].Replace("\n", "").Replace("\r", ""), item[1].Replace("\n", "").Replace("\r", ""));
                }
                ViewState["WCRDic"] = (new JavaScriptSerializer()).Serialize(dic);
            }
            else
            {
                Alert.ShowInTop("获取工作内容与要求失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        
        #endregion
    }
}