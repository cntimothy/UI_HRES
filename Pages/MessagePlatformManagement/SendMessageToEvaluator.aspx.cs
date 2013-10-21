using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using Controls;
using DataStructure;
using System.Web.Script.Serialization;

namespace HRES.Pages.EvaluationManagement
{
    public partial class MessagePlatform : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindDepartListToDropDownList();
                bindEvaluatorsToGrid(); //绑定考评人信息到Grid
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
            bindEvaluatorsToGrid();
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
            if (MessagePlatformManagementCtrl.SendMessageToEvaluators(ids, message, ref exception))
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
            bindEvaluatorsToGrid();
        }

        protected void DropDownList_Status_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatorsToGrid();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定考评人信息到Grid
        /// </summary>
        private void bindEvaluatorsToGrid()
        {
            DataTable table = new DataTable();
            string exception = "";
            if (DropDownList1.SelectedValue == "所有部门")
            {
                if (MessagePlatformManagementCtrl.GetEvaluators(ref table, ref exception))
                {
                    table = dataTableFilter(table);
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                }
                else
                {
                    table.Clear();
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                    //Alert.ShowInTop("获取考评人信息失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                string depart = DropDownList1.SelectedValue;
                if(MessagePlatformManagementCtrl.GetEvaluatorsByDepart(ref table, depart, ref exception))
                {
                    table = dataTableFilter(table);
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                }
                else
                {
                    table.Clear();
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                    //Alert.ShowInTop("获取考评人信息失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 绑定部门到下拉列表
        /// </summary>
        private void bindDepartListToDropDownList()
        {
            string exception = "";
            List<string> departs = new List<string>();
            if (CommonCtrl.GetDeparts(ref departs, ref exception))
            {
                foreach (string item in departs)
                {
                    DropDownList1.Items.Add(item, item);
                }
            }
            else
            {
                Alert.ShowInTop("获取部门信息失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 用于保持跨页选中
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 用于保持跨页选中
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 用于保持跨页选中
        /// </summary>
        /// <returns></returns>
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
        ///根据所选状态筛选DataTable
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private DataTable dataTableFilter(DataTable source)
        {
            string DocStatusStr = DropDownList_Status.SelectedValue;
            if (DocStatusStr == "-1")       //所有状态
            {
                return source;
            }

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("ID");
            resultTable.Columns.Add("Name");
            resultTable.Columns.Add("Sex");
            resultTable.Columns.Add("Company");
            resultTable.Columns.Add("Telephone");
            resultTable.Columns.Add("Status");
            resultTable.Columns.Add("Finished");
            resultTable.Columns.Add("Unfinished");

            foreach (DataRow row in source.Rows)
            {
                if (row["Status"].ToString() == DocStatusStr)
                {
                    //resultTable.Rows.Add(row.ItemArray);
                    resultTable.Rows.Add(row["ID"].ToString(), row["Name"].ToString(), row["Sex"].ToString(),
                                        row["Company"].ToString(), row["Telephone"].ToString(),
                                        row["Status"].ToString(), row["Finished"].ToString(), row["Unfinished"].ToString());
                }
            }
            return resultTable;
        }
        #endregion
    }
}