﻿using System;
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
                //Button_Close.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHideRefreshReference();
                Panel1.Title = Request.QueryString["name"] + "的考评人名单";
                bindEvaluatorToGrid();
                writeSettedNameLabel();         //显示已设置考评人名单
                Button_Reject.OnClientClick = Window1.GetShowReference("../Common/iframe_Comment.aspx?id=" + Request.QueryString["id"] + "&parent=checkevaluator", "审核意见");
            }
        }

        #region Event
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            Grid1.PageIndex = e.NewPageIndex;

            UpdateSelectedRowIndexArray();

        }

        protected void Button_Set_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            if (hfSelectedIDS.Text == "[]")
            {
                Alert.ShowInTop("请至少选择一项！", MessageBoxIcon.Warning);
                return;
            }
            List<string> evaluators = (new JavaScriptSerializer()).Deserialize<List<string>>(hfSelectedIDS.Text.Trim());
            if (EvaluatorManagementCtrl.SetEvaluator(evaluatedID, evaluators, ref exception))
            {
                Alert.ShowInTop("设置成功！\n窗口即将关闭", MessageBoxIcon.Information);
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                return;
            }
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            bindEvaluatorToGrid();
        }

        #endregion

        #region Private Method
        private void bindEvaluatorToGrid()
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

        private List<string> GetSelectedRowIndexArrayFromHiddenField()
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            List<string> ids = new List<string>();
            string currentids = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentids))
            {
                try
                {
                    ids = (new JavaScriptSerializer()).Deserialize<List<string>>(currentids);
                }
                catch (Exception)
                {
                    Alert.ShowInTop("内部错误！\n错误原因：Json反序列化错误", MessageBoxIcon.Error);
                    return null;
                }
            }

            return ids;
        }

        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();
            List<int> selectedRows = new List<int>();
            if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(Grid1.SelectedRowIndexArray);
            }
            int startPageIndex = Grid1.PageIndex * Grid1.PageSize;
            for (int i = startPageIndex, count = Math.Min(startPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
            {
                string id = Grid1.DataKeys[i][0].ToString();
                if (selectedRows.Contains(i - startPageIndex))
                {
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
                else
                {
                    if (ids.Contains(id))
                    {
                        ids.Remove(id);
                    }
                }

            }

            hfSelectedIDS.Text = (new JavaScriptSerializer()).Serialize(ids);
        }

        private void UpdateSelectedRowIndexArray()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> nextSelectedRowIndexArray = new List<int>();
            int nextStartPageIndex = Grid1.PageIndex * Grid1.PageSize;
            for (int i = nextStartPageIndex, count = Math.Min(nextStartPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
            {
                string id = Grid1.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i - nextStartPageIndex);
                }
            }
            Grid1.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }

        /// <summary>
        /// 显示已设置的考评人名单
        /// </summary>
        private void writeSettedNameLabel()
        {
            string exception = "";
            List<string> nameList = new List<string>();
            string evaluatedID = Request.QueryString["id"];
            if (EvaluatorManagementCtrl.GetSettedEvaluatorName(ref nameList, evaluatedID, ref exception))
            {
                StringBuilder sb = new StringBuilder();
                foreach (string name in nameList)
                {
                    sb.Append(name + " ");
                }
                Label_Setted.Text = sb.ToString();
            }
        }
        #endregion
    }
}