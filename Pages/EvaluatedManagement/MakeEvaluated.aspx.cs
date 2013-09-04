using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using DataStructure;
using Controls;
using System.Data;

namespace HRES.Pages.EvaluatedManagement
{
    public partial class MakeEvaluated : PageBase
    {
        #region Protected Method
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindDepartListToDropDownList();
                bindEvaluatedToGrid();
            }
        }

        protected void FileUpload_ExcelFile_FileSelected(object sender, EventArgs e)
        {
            //if (ExcelFile.HasFile)
            //{
            //    string fileName = ExcelFile.ShortFileName;
            //    if (fileName.EndsWith(".xls"))
            //    {
            //        FilePath.Text = fileName;
            //        fileName = Server.MapPath("../../upload/" + fileName);
            //        ExcelFile.SaveAs(fileName);
            //        Submit.Enabled = true;
            //        ExcelFile.Reset();
            //    }
            //    else
            //    {
            //        FilePath.Text = "不正确";
            //        Submit.Enabled = false;
            //        ExcelFile.Reset();
            //        return;
            //    }
            //}
            if (FileUpload_ExcelFile.HasFile)
            {
                string fileName = FileUpload_ExcelFile.ShortFileName;

                if (fileName != "被考评人信息.xls")
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
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string exception = "";
            string fileName = Server.MapPath("../../upload/" + ViewState["filename"].ToString());
            if (EvaluatedManagementCtrl.AddNewByExl(fileName, ref exception))
            {
                FileUpload_ExcelFile.Reset();
                Alert.ShowInTop("上传成功！", MessageBoxIcon.Information);
                bindEvaluatedToGrid();
            }
            else
            {
                FileUpload_ExcelFile.Reset();
                Alert.ShowInTop("上传失败！\n失败原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void DeleteAll_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (EvaluatedManagementCtrl.DeleteAll(ref exception))
            {
                Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                bindEvaluatedToGrid();
            }
            else
            {
                Alert.ShowInTop("删除失败\n失败原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void DropDownList_Depart_SelectedChanged(object sender, EventArgs e)
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
                    bindEvaluatedToGrid();
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
                bindEvaluatedToGrid();
            }
        }

        protected void GridRowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            SetDetail(keys);
        }

        protected void Button_DownloadTemplate_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode("被考评人信息模板.zip"));
            string path = Server.MapPath(@"..\..\downloadfiles\template\被考评人信息模板.zip");
            Response.TransmitFile(path);
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

        private void bindEvaluatedToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (DropDownList_Depart.SelectedValue == "0")
            {
                if (EvaluatedManagementCtrl.GetAll(ref table, ref exception))
                {
                    //Alert.ShowInTop("未查询到被考评人信息！\n原因：" + exception, MessageBoxIcon.Error);
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
                if (EvaluatedManagementCtrl.GetAllByDepart(ref table, depart, ref exception))
                {
                    //Alert.ShowInTop("未查询到被考评人信息！\n原因：" + exception, MessageBoxIcon.Error);
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