﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using FineUI;
using Controls;
using System.Data;

namespace HRES.Pages.MessagePlatformManagement
{
    public partial class SendMessageToSecond : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindSecondsToGrid();
            }
        }

        #region Event
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            Grid1.PageIndex = e.NewPageIndex;

            UpdateSelectedRowIndexArray();

        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindSecondsToGrid();
        }

        protected void Button_Send_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            List<string> ids = (new JavaScriptSerializer()).Deserialize<List<string>>(hfSelectedIDS.Text.Trim());
            if (ids.Count == 0)
            {
                Alert.ShowInTop("请至少选择一项！", MessageBoxIcon.Warning);
                return;
            }

            string exception = "";
            string message = TextArea_Message.Text;
            if (MessagePlatformManagementCtrl.SendMessageToSeconds(ids, message, ref exception))
            {
                Alert.ShowInTop("发送成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("发送失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void DropDownList1_SelectedChanged(object sender, EventArgs e)
        {
            bindSecondsToGrid();
        }
        #endregion

        #region Private Method
        private void bindSecondsToGrid()
        {
            DataTable table = new DataTable();
            string exception = "";
            if (MessagePlatformManagementCtrl.GetSeconds(ref table, ref exception))
            {
                Grid1.DataSource = table;
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
            List<string> ids = new List<string>();
            string currentStr = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentStr))
            {
                try
                {
                    ids = (new JavaScriptSerializer()).Deserialize<List<string>>(currentStr);
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

        #endregion
    }
}