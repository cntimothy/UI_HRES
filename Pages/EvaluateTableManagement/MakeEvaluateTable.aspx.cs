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

namespace HRES.Pages.EvaluateTableManagement
{
    public partial class MakeEvaluateTable : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                BindEvaluatedToGrid();
            }

        }
        #endregion

        #region Event
        protected void Refresh_Click(object sender, EventArgs e)
        {
            BindEvaluatedToGrid();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            SetSimpleForm(keys);
        }

        protected void Window_MakeEvaluateTable_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindEvaluatedToGrid();
        }

        #endregion

        #region Private Method

        private void BindEvaluatedToGrid()
        {
            string exception = "";
            string depart = (string)Session["Depart"];
            DataTable table = new DataTable();
            if (EvaluateTableManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
            {
                string sortField = "Status";
                string sortDirection = "ASC";
                DataView dv = table.DefaultView;
                dv.Sort = String.Format("{0} {1}", sortField, sortDirection);
                Grid1.DataSource = dv;
                Grid1.DataBind();
            }
        }

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
            LabStatus.Text = GetDocStatusForCheck(keys[13]);
            LabComment.Text = (string)keys[14];
        }
        #endregion
    }
}