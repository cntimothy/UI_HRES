using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using Controls;
using DataStructure;

namespace HRES.Pages.EvaluationManagement
{
    public partial class StopEvaluation : PageBase
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
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            LinkButtonField linkButtonField_Operation = Grid1.FindColumn("LinkButtonField_Operation") as LinkButtonField;
            DataRowView row = e.DataItem as DataRowView;
            string strStatus = row["Status"].ToString();
            EvaluationStatusForEvaluated status = (EvaluationStatusForEvaluated)Enum.Parse(typeof(EvaluationStatusForEvaluated), strStatus);
            if (status == EvaluationStatusForEvaluated.started)
            {
                linkButtonField_Operation.Enabled = true;
            }
            else
            {
                linkButtonField_Operation.Enabled = false;
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            SetDetail(keys);
        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void DropDownList1_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Stop")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string id = (string)keys[0];
                if (EvaluationManagementCtrl.StopEvaluation(id, ref exception))
                {
                    Alert.ShowInTop("设置成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
                bindEvaluatedToGrid();
            }
        }

        /// <summary>
        /// 考评状态下拉列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_EvaluationStatus_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定被考评人信息到Grid
        /// </summary>
        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            string depart = Session["Depart"].ToString();
            if (EvaluationManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
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
            }
        }

        /// <summary>
        ///设置详细个人信息
        /// </summary>
        /// <param name="keys"></param>
        private void SetDetail(object[] keys)
        {
            Label_ID.Text = (string)keys[0];
            Label_Name.Text = (string)keys[1];
            Label_Sex.Text = (string)keys[2];
            Label_Company.Text = (string)keys[3];
            Label_Depart.Text = (string)keys[4];
            Label_LaborDepart.Text = (string)keys[5];
            Label_PostName.Text = (string)keys[6];
            Label_PostType.Text = (string)keys[7];
            Label_Fund.Text = (string)keys[8];
            Label_Character.Text = (string)keys[9];
            Label_StartTime.Text = (string)keys[10];
            Label_StopTime.Text = (string)keys[11];
            Label_Summary.Text = (string)keys[14];
            Label_Finished.Text = (string)keys[15];
            Label_Unfinished.Text = (string)keys[16];

        }

        /// <summary>
        ///根据所选状态筛选DataTable
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private DataTable dataTableFilter(DataTable source)
        {
            string DocStatusStr = DropDownList_EvaluationStatus.SelectedValue;
            if (DocStatusStr == "-1")       //所有状态
            {
                return source;
            }

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("ID");
            resultTable.Columns.Add("Name");
            resultTable.Columns.Add("Sex");
            resultTable.Columns.Add("Company");
            resultTable.Columns.Add("Depart");
            resultTable.Columns.Add("LaborDepart");
            resultTable.Columns.Add("PostName");
            resultTable.Columns.Add("PostType");
            resultTable.Columns.Add("Fund");
            resultTable.Columns.Add("Character");
            resultTable.Columns.Add("StartTime");
            resultTable.Columns.Add("StopTime");
            resultTable.Columns.Add("Summary");
            resultTable.Columns.Add("Status");
            resultTable.Columns.Add("Finished");
            resultTable.Columns.Add("Unfinished");
            foreach (DataRow row in source.Rows)
            {
                if (row["Status"].ToString() == DocStatusStr)
                {
                    resultTable.Rows.Add(row.ItemArray);
                }
            }
            return resultTable;
        }
        #endregion
    }
}