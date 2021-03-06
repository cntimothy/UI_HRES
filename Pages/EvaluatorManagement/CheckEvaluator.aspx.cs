﻿using System;
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
            SetDetail(keys);
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
            //设置可用性
            if (status == DocStatus.unmake || status == DocStatus.saved)
            {
                windowField_Check.Enabled = false;
            }
            else
            {
                windowField_Check.Enabled = true;
            }
            //设置颜色
            System.Web.UI.WebControls.Label labelStatus = Grid1.Rows[e.RowIndex].FindControl("Status") as System.Web.UI.WebControls.Label;
            switch (status)
            {
                case DocStatus.unmake:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#8600FF");
                    break;
                case DocStatus.saved:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#009100");
                    break;
                case DocStatus.submitted:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#007979");
                    break;
                case DocStatus.rejected:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#0000C6");
                    break;
                case DocStatus.modified:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#73BF00");
                    break;
                case DocStatus.passed:
                    labelStatus.ForeColor = System.Drawing.Color.FromName("#408080");
                    break;
                default:
                    break;
            }
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortColumnIndex = e.ColumnIndex;
            bindEvaluatedToGrid();
        }

        /// <summary>
        /// 状态下拉列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_DocStatus_SelectedChanged(object sender, EventArgs e)
        {
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
            //else
            //{
            //    Alert.ShowInTop("获取部门信息失败！/n原因：" + exception, MessageBoxIcon.Error);
            //}
        }

        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DropDownList_Depart.SelectedValue == "0")
            {
                if (EvaluatorManagementCtrl.GetAll(ref table, ref exception))
                {
                    table = dataTableFilter(table);
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
                    //Alert.ShowInTop("获取被考评人信息失败！/n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                string depart = DropDownList_Depart.SelectedValue;
                if (EvaluatorManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
                {
                    table = dataTableFilter(table);
                    string sortField = "Status";
                    string sortDirection = "ASC";
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
                    //Alert.ShowInTop("获取被考评人信息失败！/n原因：" + exception, MessageBoxIcon.Error);
                }
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

        /// <summary>
        ///根据所选状态筛选DataTable
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private DataTable dataTableFilter(DataTable source)
        {
            string DocStatusStr = DropDownList_DocStatus.SelectedValue;
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
            resultTable.Columns.Add("Status");
            resultTable.Columns.Add("Comment");

            if (DocStatusStr == "0") //对人事处管理员来说，未制作状态包含未制作和已保存两种状态
            {
                foreach (DataRow row in source.Rows)
                {
                    if (row["Status"].ToString() == DocStatusStr || row["Status"].ToString() == "1")
                    {
                        resultTable.Rows.Add(row["ID"].ToString(), row["Name"].ToString(), row["Sex"].ToString(),
                                        row["Company"].ToString(), row["Depart"].ToString(), row["LaborDepart"].ToString(),
                                        row["PostName"].ToString(), row["PostType"].ToString(), row["Fund"].ToString(),
                                        row["Character"].ToString(), row["StartTime"].ToString(), row["StopTime"].ToString(),
                                        row["Status"].ToString(), row["Comment"].ToString());
                    }
                }
            }
            else
            {
                foreach (DataRow row in source.Rows)
                {
                    if (row["Status"].ToString() == DocStatusStr)
                    {
                        resultTable.Rows.Add(row["ID"].ToString(), row["Name"].ToString(), row["Sex"].ToString(),
                                        row["Company"].ToString(), row["Depart"].ToString(), row["LaborDepart"].ToString(),
                                        row["PostName"].ToString(), row["PostType"].ToString(), row["Fund"].ToString(),
                                        row["Character"].ToString(), row["StartTime"].ToString(), row["StopTime"].ToString(),
                                        row["Status"].ToString(), row["Comment"].ToString());
                    }
                }
            }
            return resultTable;
        }
        #endregion
    }
}