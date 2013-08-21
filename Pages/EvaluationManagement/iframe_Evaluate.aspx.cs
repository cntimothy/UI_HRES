using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controls;
using DataStructure;
using FineUI;
using System.Text.RegularExpressions;


namespace HRES.Pages.EvaluationManagement
{
    public partial class iframe_Evaluate : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHideRefreshReference();
                Relation relation = (Relation)Enum.Parse(typeof(Relation), Request.QueryString["relation"]);
                if (relation != Relation.leader)
                {
                    Grid7.Visible = false;
                }
                bindEvaluateTableToGrid();
            }
        }

        #region Event
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            List<string> scores = new List<string>();
            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                GridRow row = Grid1.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score1") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }

            for (int i = 0; i < Grid2.Rows.Count; i++)
            {
                GridRow row = Grid2.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score2") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }

            for (int i = 0; i < Grid3.Rows.Count; i++)
            {
                GridRow row = Grid3.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score3") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }

            for (int i = 0; i < Grid4.Rows.Count; i++)
            {
                GridRow row = Grid4.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score4") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }


            for (int i = 0; i < Grid5.Rows.Count; i++)
            {
                GridRow row = Grid5.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score5") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }


            for (int i = 0; i < Grid6.Rows.Count; i++)
            {
                GridRow row = Grid6.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score6") as System.Web.UI.WebControls.TextBox;
                scores.Add(tb.Text);
            }

            if (Grid7.Rows.Count != 0)
            {
                GridRow gridRow = Grid7.Rows[0];
                System.Web.UI.WebControls.DropDownList ddl = gridRow.FindControl("DropDownList1") as System.Web.UI.WebControls.DropDownList;
                scores.Add(ddl.SelectedValue);
            }
            string[] scoreArray = scores.ToArray();

            if (CheckNull(scoreArray) && isNumber(scoreArray) && isProperty(scoreArray))
            {
                string exception = "";
                string evaluatedID = Request.QueryString["id"];
                string evaluatorID = Session["UserID"].ToString();
                if (EvaluationManagementCtrl.UpdateScore(evaluatedID, evaluatorID, scores.ToArray(), ref exception))
                {
                    Alert.ShowInTop("提交成功！", MessageBoxIcon.Information);
                }
                else
                {
                    Alert.ShowInTop("提交失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                Alert.ShowInTop("请输入正确的分数！",  MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Private Method
        private void bindEvaluateTableToGrid()
        {
            string exception = "";
            EvaluateTable evaluateTable = new EvaluateTable();
            string evaluatedID = Request.QueryString["id"];
            if (EvaluationManagementCtrl.GetEvaluateTable(evaluatedID, ref evaluateTable, ref exception))
            {
                Label_EvaluatedName.Text = evaluateTable.EvaluatedName;
                Label_PostName.Text = evaluateTable.PostName;
                Label_LaborDep.Text = evaluateTable.LaborDep;
                Label_LaborUnit.Text = evaluateTable.LaborUnit;
                RadioButtonList_Relation.SelectedValue = Request.QueryString["relation"];
                Label_Period.Text = evaluateTable.StartTime + " ~ " + evaluateTable.StopTime;

                //关键岗位职责指标
                DataTable table1 = new DataTable();
                table1.Columns.Add("Title");
                table1.Columns.Add("Quota");
                foreach (Quota item in evaluateTable.KeyResponse)
                {
                    table1.Rows.Add(item.Title, item.Content[0]);
                }
                Grid1.DataSource = table1;
                Grid1.DataBind();

                //关键岗位胜任能力指标
                DataTable table2 = new DataTable();
                table2.Columns.Add("Title");
                table2.Columns.Add("Quota1");
                table2.Columns.Add("Quota2");
                table2.Columns.Add("Quota3");
                table2.Columns.Add("Quota4");
                foreach (Quota item in evaluateTable.KeyQualify)
                {
                    table2.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3]);
                }
                Grid2.DataSource = table2;
                Grid2.DataBind();

                //关键岗位工作态度指标
                DataTable table3 = new DataTable();
                table3.Columns.Add("Title");
                table3.Columns.Add("Quota1");
                table3.Columns.Add("Quota2");
                table3.Columns.Add("Quota3");
                table3.Columns.Add("Quota4");
                foreach (Quota item in evaluateTable.KeyAttitude)
                {
                    table3.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3]);
                }
                Grid3.DataSource = table3;
                Grid3.DataBind();

                //岗位职责指标
                DataTable table4 = new DataTable();
                table4.Columns.Add("Title");
                table4.Columns.Add("Quota");
                foreach (Quota item in evaluateTable.Response)
                {
                    table4.Rows.Add(item.Title, item.Content[0]);
                }
                Grid4.DataSource = table4;
                Grid4.DataBind();

                //岗位胜任能力指标
                DataTable table5 = new DataTable();
                table5.Columns.Add("Title");
                table5.Columns.Add("Quota1");
                table5.Columns.Add("Quota2");
                table5.Columns.Add("Quota3");
                table5.Columns.Add("Quota4");
                foreach (Quota item in evaluateTable.Qualify)
                {
                    table5.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3]);
                }
                Grid5.DataSource = table5;
                Grid5.DataBind();

                //岗位工作态度指标
                DataTable table6 = new DataTable();
                table6.Columns.Add("Title");
                table6.Columns.Add("Quota1");
                table6.Columns.Add("Quota2");
                table6.Columns.Add("Quota3");
                table6.Columns.Add("Quota4");
                foreach (Quota item in evaluateTable.Attitude)
                {
                    table6.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3]);
                }
                Grid6.DataSource = table6;
                Grid6.DataBind();

                //否决指标
                DataTable table7 = new DataTable();
                table7.Columns.Add("Title");
                table7.Columns.Add("Quota");
                foreach (Quota item in evaluateTable.Reject)
                {
                    table7.Rows.Add(item.Title, item.Content[0]);
                }
                Grid7.DataSource = table7;
                Grid7.DataBind();
            }
        }

        /// <summary>
        /// 检测字符串是否为表示整数,是整数返回true，否则返回false
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool isNumber(string[] items)
        {
            string pattern = @"^\d*$";
            foreach (string item in items)
            {
                if (!Regex.IsMatch(item, pattern))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检测字符串表示的数字是否在0~100之间（包括0和100），是则返回true，否则返回false
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool isProperty(string[] items)
        {
            foreach (string item in items)
            {
                int i = Convert.ToInt32(item);
                if (i < 0 || i > 100)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}