using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controls;
using FineUI;
using DataStructure;

namespace HRES.Pages.EvaluationManagement
{
    public partial class EvaluationResultForIndividual : PageBase
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
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void DropDownList1_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                List<string> IDs = new List<string>();
                IDs.Add((string)keys[0]);
                if (EvaluatedManagementCtrl.Delete(IDs, ref exception))
                {
                    Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

        protected void GridRowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            SetDetail(keys);
        }
        #endregion

        #region Private Method
        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DropDownList1.SelectedValue == "0")
            {
                if (EvaluationManagementCtrl.GetEvaluatedThisYear(ref table, ref exception))
                {
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                }
                else
                {
                    Alert.ShowInTop("查询被考评人信息失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (EvaluationManagementCtrl.GetEvaluatedAll(ref table, ref exception))
                {
                    Grid1.DataSource = table;
                    Grid1.DataBind();
                }
                else
                {
                    Alert.ShowInTop("查询被考评人信息失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

        private void SetDetail(object[] keys)
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
            LabStatus.Text = (string)keys[11];
        }
        #endregion
    }
}