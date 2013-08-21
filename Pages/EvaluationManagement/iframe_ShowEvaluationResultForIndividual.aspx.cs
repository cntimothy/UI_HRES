using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;
using System.Data;
using DataStructure;

namespace HRES.Pages.EvaluationManagement
{
    public partial class iframe_ShowEvaluationResultForIndividual : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                bindYearToDropDownList();
                bindEvaluationResultToGrid();
            }
        }

        #region Event
        protected void DropDownList_Year_SelectedChanged(object sender, EventArgs e)
        {
            bindEvaluationResultToGrid();
        }

        protected void Button_Export_Click(object sender, EventArgs e)
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            string evaluatedName = Request.QueryString["name"];
            EvaluationResult evaluationResult;
            if (EvaluationManagementCtrl.GetEvaluationResultByEvaluatedAndYear(out evaluationResult, evaluatedID, DropDownList_Year.SelectedValue, ref exception))
            {
                string filename = "";
                if (ExportManagementCtrl.ExportEvaluationResultForIndividual(ref filename, evaluatedName, evaluationResult, ref exception))
                {
                    Response.ClearContent();
                    Response.ContentType = "application/excel";
                    Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(filename));
                    string path = Server.MapPath("..\\..\\downloadfiles\\" + filename);
                    Response.TransmitFile(path);
                }
            }
            else
            {
                Alert.ShowInTop("导出失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private Method
        private void bindYearToDropDownList()
        {
            string exception = "";
            Dictionary<string, string> idYearDic = new Dictionary<string, string>();
            string evaluatedID = Request.QueryString["id"];
            if (EvaluationManagementCtrl.GetEvaluationResultYears(ref idYearDic, evaluatedID, ref exception))
            {
                foreach (string id in idYearDic.Keys)
                {
                    DropDownList_Year.Items.Add(idYearDic[id], id);
                }
            }
            else
            {
                Alert.ShowInTop("获取年份信息失败！/n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        private void bindEvaluationResultToGrid()
        {
            string exception = "";
            EvaluationResult evaluationResult;
            string evaluatedID = Request.QueryString["id"];
            if (EvaluationManagementCtrl.GetEvaluationResultByEvaluatedAndYear(out evaluationResult, evaluatedID, DropDownList_Year.SelectedValue, ref exception))
            {
                Label_EvaluatedName.Text = Request.QueryString["name"];
                Label_PostName.Text = evaluationResult.PostName;
                Label_LaborDep.Text = evaluationResult.LaborDep;
                Label_LaborUnit.Text = evaluationResult.LaborUnit;
                Label_Period.Text = evaluationResult.StartTime + " ~ " + evaluationResult.StopTime;

                if (evaluationResult.Is360)
                {
                    gen360Grid(evaluationResult);
                }
                else
                {
                    gen270Grid(evaluationResult);
                }
            }
            else
            {
                Alert.ShowInTop("获取考评结果失败！/n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        private void gen360Grid(EvaluationResult evaluationResult)
        {
            FineUI.BoundField bf;

            bf = new FineUI.BoundField();
            bf.DataField = "quota";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "指标";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "leader";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "领导/上级（60%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "colleague";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "同事（10%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "subordinate";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "下属（15%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "services";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "服务对象/客户（15%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "result";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "小计";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            DataTable table = new DataTable();
            table.Columns.Add("quota");
            table.Columns.Add("leader");
            table.Columns.Add("colleague");
            table.Columns.Add("subordinate");
            table.Columns.Add("services");
            table.Columns.Add("result");

            DataRow row = table.NewRow();
            row["quota"] = "关键绩效指标（50%）";
            row["leader"] = evaluationResult.KeyScore[0];
            row["colleague"] = evaluationResult.KeyScore[1];
            row["subordinate"] = evaluationResult.KeyScore[2];
            row["services"] = evaluationResult.KeyScore[3];
            row["result"] = evaluationResult.KeyScore[4];
            table.Rows.Add(row);

            DataRow row1 = table.NewRow();
            row1["quota"] = "岗位职责指标（20%）";
            row1["leader"] = evaluationResult.ResponseScore[0];
            row1["colleague"] = evaluationResult.ResponseScore[1];
            row1["subordinate"] = evaluationResult.ResponseScore[2];
            row1["services"] = evaluationResult.ResponseScore[3];
            row1["result"] = evaluationResult.ResponseScore[4];
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["quota"] = "岗位胜任能力指标（15%）";
            row2["leader"] = evaluationResult.QualifyScore[0];
            row2["colleague"] = evaluationResult.QualifyScore[1];
            row2["subordinate"] = evaluationResult.QualifyScore[2];
            row2["services"] = evaluationResult.QualifyScore[3];
            row2["result"] = evaluationResult.QualifyScore[4];
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["quota"] = "工作态度指标（15%）";
            row3["leader"] = evaluationResult.AttitudeScore[0];
            row3["colleague"] = evaluationResult.AttitudeScore[1];
            row3["subordinate"] = evaluationResult.AttitudeScore[2];
            row3["services"] = evaluationResult.AttitudeScore[3];
            row3["result"] = evaluationResult.AttitudeScore[4];
            table.Rows.Add(row3);

            DataRow row4 = table.NewRow();
            row4["quota"] = "否决指标（100%）";
            row4["leader"] = evaluationResult.RejectScore[0];
            row4["colleague"] = evaluationResult.RejectScore[1];
            row4["subordinate"] = evaluationResult.RejectScore[2];
            row4["services"] = evaluationResult.RejectScore[3];
            row4["result"] = evaluationResult.RejectScore[4];
            table.Rows.Add(row4);

            DataRow row5 = table.NewRow();
            row5["quota"] = "小计";
            row5["leader"] = evaluationResult.ResultScore[0];
            row5["colleague"] = evaluationResult.ResultScore[1];
            row5["subordinate"] = evaluationResult.ResultScore[2];
            row5["services"] = evaluationResult.ResultScore[3];
            row5["result"] = evaluationResult.ResultScore[4];
            table.Rows.Add(row5);

            DataRow row6 = table.NewRow();
            row6["quota"] = "考评者数量（50%）";
            row6["leader"] = evaluationResult.EvaluatorNum[0];
            row6["colleague"] = evaluationResult.EvaluatorNum[1];
            row6["subordinate"] = evaluationResult.EvaluatorNum[2];
            row6["services"] = evaluationResult.EvaluatorNum[3];
            row6["result"] = evaluationResult.EvaluatorNum[4];
            table.Rows.Add(row6);

            Grid1.DataSource = table;
            Grid1.DataBind();

            RadioButtonList_EvaluationLevel.SelectedValue = Convert.ToString((int)evaluationResult.EvaluationLevel);
        }

        private void gen270Grid(EvaluationResult evaluationResult)
        {
            FineUI.BoundField bf;

            bf = new FineUI.BoundField();
            bf.DataField = "quota";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "指标";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "leader";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "领导/上级（65%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "colleague";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "同事（15%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "services";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "服务对象/客户（20%）";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "result";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "小计";
            bf.Width = 150;
            Grid1.Columns.Add(bf);

            DataTable table = new DataTable();
            table.Columns.Add("quota");
            table.Columns.Add("leader");
            table.Columns.Add("colleague");
            table.Columns.Add("services");
            table.Columns.Add("result");

            DataRow row = table.NewRow();
            row["quota"] = "关键绩效指标（50%）";
            row["leader"] = evaluationResult.KeyScore[0];
            row["colleague"] = evaluationResult.KeyScore[1];
            row["services"] = evaluationResult.KeyScore[2];
            row["result"] = evaluationResult.KeyScore[3];
            table.Rows.Add(row);

            DataRow row1 = table.NewRow();
            row1["quota"] = "岗位职责指标（20%）";
            row1["leader"] = evaluationResult.ResponseScore[0];
            row1["colleague"] = evaluationResult.ResponseScore[1];
            row1["services"] = evaluationResult.ResponseScore[2];
            row1["result"] = evaluationResult.ResponseScore[3];
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["quota"] = "岗位胜任能力指标（15%）";
            row2["leader"] = evaluationResult.QualifyScore[0];
            row2["colleague"] = evaluationResult.QualifyScore[1];
            row2["services"] = evaluationResult.QualifyScore[2];
            row2["result"] = evaluationResult.QualifyScore[3];
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["quota"] = "工作态度指标（15%）";
            row3["leader"] = evaluationResult.AttitudeScore[0];
            row3["colleague"] = evaluationResult.AttitudeScore[1];
            row3["services"] = evaluationResult.AttitudeScore[2];
            row3["result"] = evaluationResult.AttitudeScore[3];
            table.Rows.Add(row3);

            DataRow row4 = table.NewRow();
            row4["quota"] = "否决指标（100%）";
            row4["leader"] = evaluationResult.RejectScore[0];
            row4["colleague"] = evaluationResult.RejectScore[1];
            row4["services"] = evaluationResult.RejectScore[2];
            row4["result"] = evaluationResult.RejectScore[3];
            table.Rows.Add(row4);

            DataRow row5 = table.NewRow();
            row5["quota"] = "小计";
            row5["leader"] = evaluationResult.ResultScore[0];
            row5["colleague"] = evaluationResult.ResultScore[1];
            row5["services"] = evaluationResult.ResultScore[2];
            row5["result"] = evaluationResult.ResultScore[3];
            table.Rows.Add(row5);

            DataRow row6 = table.NewRow();
            row6["quota"] = "考评者数量（50%）";
            row6["leader"] = evaluationResult.EvaluatorNum[0];
            row6["colleague"] = evaluationResult.EvaluatorNum[1];
            row6["services"] = evaluationResult.EvaluatorNum[2];
            row6["result"] = evaluationResult.EvaluatorNum[3];
            table.Rows.Add(row6);

            Grid1.DataSource = table;
            Grid1.DataBind();

            RadioButtonList_EvaluationLevel.SelectedValue = Convert.ToString((int)evaluationResult.EvaluationLevel);
        }
        #endregion
    }
}