using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using DataStructure;
using FineUI;
using System.Data;
using System.IO;

namespace HRES.Pages.SecondManagement
{
    public partial class MakeSecond : PageBase
    {
        #region Public Method
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindDepartListToDropDownList();
                bindSecondToGrid();
            }
        }

        protected void FileUpload_ExcelFile_FileSelected(object sender, EventArgs e)
        {
            string fileName = FileUpload_ExcelFile.ShortFileName;

            if (fileName != "系级管理员信息.xls")
            {
                Button_Submit.Enabled = false;
                Label_FileName.Text = "";
                FileUpload_ExcelFile.Reset();
                Alert.Show("无效的文件！", MessageBoxIcon.Error);
                return;
            }

            Label_FileName.Text = fileName;
            fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
            ViewState["filename"] = fileName;

            FileUpload_ExcelFile.SaveAs(Server.MapPath("~/upload/" + fileName));


            Button_Submit.Enabled = true;
            // 清空文件上传组件
            FileUpload_ExcelFile.Reset();
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string exception = "";
            string fileName = Server.MapPath("../../upload/" + ViewState["filename"].ToString());
            if (SecondManagementCtrl.AddNewByExl(fileName, ref exception))
            {
                FileUpload_ExcelFile.Reset();
                Alert.ShowInTop("上传成功！", MessageBoxIcon.Information);
                bindSecondToGrid();
            }
            else
            {
                FileUpload_ExcelFile.Reset();
                Alert.ShowInTop("上传失败！\n失败原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void DropDownList_Depart_SelectedChanged(object sender, EventArgs e)
        {
            bindSecondToGrid();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                if (SecondManagementCtrl.Delete((string)keys[0], ref exception))
                {
                    Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            if (e.CommandName == "Reset")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                if (SecondManagementCtrl.ResetPassword((string)keys[0], ref exception))
                {
                    Alert.ShowInTop("重置成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("重置失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            bindSecondToGrid();
        }

        protected void Button_DownloadTemplate_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode("系级管理员信息模版.zip"));
            
            string path = Server.MapPath(@"..\..\downloadfiles\template\系级管理员信息模版.zip");
            FileInfo fi = new FileInfo(path);
            Response.AddHeader("Content_Length", fi.Length.ToString());
            //Response.TransmitFile(path);
            Response.Filter.Close();
            Response.WriteFile(fi.FullName);
            Response.End();
        }

        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindSecondToGrid();
        }
        #endregion

        #region Private Method
        private void bindDepartListToDropDownList()
        { 
            List<string> departs = new List<string>();
            string exception = "";
            if (CommonCtrl.GetDeparts(ref departs, ref exception))
            {
                foreach (string depart in departs)
                {
                    DropDownList_Depart.Items.Add(depart, depart);
                }
            }
        }

        private void bindSecondToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DropDownList_Depart.SelectedValue == "0")
            {
                if (SecondManagementCtrl.GetAll(ref table, ref exception))
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
            else
            {
                string depart = DropDownList_Depart.SelectedValue;
                if (SecondManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
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
        }
        #endregion
    }
}