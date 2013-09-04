﻿using System;
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
            SetDetail(keys);
        }

        protected void Window_MakeEvaluateTable_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            bindEvaluatedToGrid();
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortColumnIndex = e.ColumnIndex;
            bindEvaluatedToGrid();
        }
        #endregion

        #region Private Method

        private void bindEvaluatedToGrid()
        {
            string exception = "";
            string depart = (string)Session["Depart"];
            DataTable table = new DataTable();
            if (EvaluateTableManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
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
        }
        #endregion
    }
}