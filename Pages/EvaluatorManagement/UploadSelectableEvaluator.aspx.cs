using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;
using DataStructure;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HRES.Pages.EvaluatorManagement
{
    public partial class UploadSelectableEvaluator : PageBase
    {
        #region Protected Method
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindEvaluatorToGrid();
            }
        }

        protected void FileSelected(object sender, EventArgs e)
        {
            if (ExcelFile.HasFile)
            {
                string fileName = ExcelFile.ShortFileName;
                if (fileName.EndsWith(".xls"))
                {
                    FilePath.Text = fileName;
                    fileName = Server.MapPath("../../upload/" + fileName);
                    ExcelFile.SaveAs(fileName);
                    Submit.Enabled = true;
                }
                else
                {
                    FilePath.Text = "不正确";
                    Submit.Enabled = false;
                    return;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string exception = "";
            string fileName = Server.MapPath("../../upload/" + FilePath.Text);            
            string depart = Session["Depart"].ToString();
            if (EvaluatorManagementCtrl.UploadSelectable(fileName, depart, ref exception))
            {
                ExcelFile.Reset();
                Alert.ShowInTop("上传成功！", MessageBoxIcon.Information);
                bindEvaluatorToGrid();
            }
            else
            {
                ExcelFile.Reset();
                Alert.ShowInTop("上传失败！\n失败原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void DeleteSelected_Click(object sender, EventArgs e)
        {
            syncSelectedRowIndexArrayToHiddenField();
            string exception = "";
            string s = hfSelectedIDS.Text.Trim().TrimStart('[').TrimEnd(']');
            if (s == "")
            {
                Alert.ShowInTop("请至少选择一项！", MessageBoxIcon.Information);
                return;
            }
            List<string> IDs = new List<string>();
            string[] tempIDs = s.Split(',');
            foreach (string item in tempIDs)
            {
                IDs.Add(item.Trim('"'));
            }
            if (EvaluatorManagementCtrl.Delete(IDs, ref exception))
            {
                Alert.ShowInTop("删除成功", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("删除失败\n原因：" + exception, MessageBoxIcon.Error);
            }
            bindEvaluatorToGrid();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            syncSelectedRowIndexArrayToHiddenField();
            Grid1.PageIndex = e.NewPageIndex;
            updateSelectedRowIndexArray();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            string exception = "";
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                List<string> IDs = new List<string>();
                IDs.Add((string)keys[0]);
                if (EvaluatorManagementCtrl.Delete(IDs, ref exception))
                {
                    Alert.ShowInTop("删除成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("删除失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
        }

        protected void Button_DownloadTemplate_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode("考评人信息模板.zip"));
            string path = Server.MapPath(@"..\..\downloadfiles\template\考评人信息模板.zip");
            Response.TransmitFile(path);
        }

        #endregion

        #region Private Method

        private void bindEvaluatorToGrid()
        {
            string exception = "";
            string depart = Session["Depart"].ToString();
            DataTable table = new DataTable();
            if (EvaluatorManagementCtrl.GetSelectableEvaluatorByDepart(ref table, depart, ref exception))
            {
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }

        private List<string> getSelectedRowIndexArrayFromHiddenField()
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }

            return new List<string>(idsArray.ToObject<string[]>());
        }

        private void syncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = getSelectedRowIndexArrayFromHiddenField();

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

            hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
        }


        private void updateSelectedRowIndexArray()
        {
            List<string> ids = getSelectedRowIndexArrayFromHiddenField();

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
        #endregion
    }
}