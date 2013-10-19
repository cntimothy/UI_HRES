using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using System.Data;
using FineUI;

namespace HRES.Pages.EvaluationManagement
{
    public partial class StartEvaluation : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindDepartsToDropDownList();
                bindEvaluatedToGrid();
            }
        }

        #region Event
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            SetSimpleForm(keys);
        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Button_Start_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (EvaluationManagementCtrl.StartEvaluation(ref exception))
            {
                Alert.ShowInTop("设置成功！", MessageBoxIcon.Information);
                bindEvaluatedToGrid();
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void DropDownList1_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

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
            if (DropDownList1.SelectedValue == "所有部门")
            {
                if (EvaluationManagementCtrl.GetAll(ref table, ref exception))
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
            else
            {
                string depart = DropDownList1.SelectedValue;
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
        }

        /// <summary>
        /// 设置详细信息
        /// </summary>
        /// <param name="keys"></param>
        private void SetSimpleForm(object[] keys)
        {
            LabID.Text = (string)keys[0];
            LabDate.Text = (string)keys[1];
            LabName.Text = (string)keys[2];
            LabSex.Text = (string)keys[3];
            LabDepart.Text = (string)keys[4];
            LabJob.Text = (string)keys[5];
            LabIDNo.Text = (string)keys[6];
            LabBirthday.Text = (string)keys[7];
            LabFund.Text = (string)keys[8];
            LabCharacter.Text = (string)keys[9];
            LabCompany.Text = (string)keys[10];
            LabStartTime.Text = (string)keys[11];
            LabStopTime.Text = (string)keys[12];
        }

        /// <summary>
        /// 绑定部门到下拉列表
        /// </summary>
        private void bindDepartsToDropDownList()
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
            //else
            //{
            //    Alert.ShowInTop("获取部门信息失败！\n原因：" + exception, MessageBoxIcon.Error);
            //}
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