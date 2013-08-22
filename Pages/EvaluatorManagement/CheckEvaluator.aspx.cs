using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;
using System.Data;
using DataStructure;

namespace HRES.Pages.EvaluatorManagement
{
    public partial class CheckEvaluator : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindDepartsToDropDownList();
                bindEvaluatedToGrid();
            }

        }
        #endregion

        #region Event
        protected void Refresh_Click(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            setSimpleForm(keys);
        }

        protected void Window_CheckEvaluator_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void DropDownList_Depart_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            WindowField windowField_Check = Grid1.FindColumn("WindowField_Check") as WindowField;
            DataRowView row = e.DataItem as DataRowView;
            string strStatus = row["Status"].ToString();
            DocStatus status = (DocStatus)Enum.Parse(typeof(DocStatus), strStatus);
            if (status == DocStatus.unmake || status == DocStatus.saved)
            {
                windowField_Check.Enabled = false;
            }
            else
            {
                windowField_Check.Enabled = true;
            }
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortColumnIndex = e.ColumnIndex;
            bindEvaluatedToGrid();
        }
        #endregion

        #region Private Method
        private void bindDepartsToDropDownList()
        {
            string exception = "";
            List<string> departs = new List<string>();
            if (CommonCtrl.GetDeparts(ref departs, ref exception))
            {
                foreach (string depart in departs)
                {
                    DropDownList_Depart.Items.Add(depart, depart);
                }
            }
            else
            {
                Alert.ShowInTop("获取部门信息失败！/n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DropDownList_Depart.SelectedValue == "0")
            {
                if (EvaluatorManagementCtrl.GetAll(ref table, ref exception))
                {
                    string sortField = Grid1.SortField;
                    string sortDirection = Grid1.SortDirection;
                    DataView dv = table.DefaultView;
                    dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
                    Grid1.DataSource = dv;
                    Grid1.DataBind();
                }
                else
                {
                    Alert.ShowInTop("获取被考评人信息失败！/n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                string depart = DropDownList_Depart.SelectedValue;
                if (EvaluatorManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
                {
                    string sortField = "Status";
                    string sortDirection = "ASC";
                    DataView dv = table.DefaultView;
                    dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
                    Grid1.DataSource = dv;
                    Grid1.DataBind();
                }
                else
                {
                    Alert.ShowInTop("获取被考评人信息失败！/n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

        private void setSimpleForm(object[] keys)
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
            LabStatus.Text = GetDocStatusForCheck(keys[13]);
            LabComment.Text = (string)keys[14];
        }
        #endregion
    }
}