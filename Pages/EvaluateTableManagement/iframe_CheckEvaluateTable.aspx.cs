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
using System.IO;

namespace HRES.Pages.EvaluateTableManagement
{
    public partial class iframe_CheckEvaluateTable : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                //Button_Close.OnClientClick = ActiveWindow.GetHideReference();
                Button_Close.OnClientClick = ActiveWindow.GetHideRefreshReference();
                Button_Reject.OnClientClick = Window1.GetShowReference("../Common/iframe_Comment.aspx?id=" + Request.QueryString["id"] + "&parent=checkevaluatetable", "审核意见");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            loadEvaluateTable();
        }

        #endregion

        #region Event
        protected void Button_Pass_Click(object sender, EventArgs e)
        {
            string evaluatedID = Request.QueryString["id"];
            string exception = "";
            if (EvaluateTableManagementCtrl.SetPass(evaluatedID, ref exception))
            {
                Alert.ShowInTop("设置成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Information);
            }
        }

        protected void Button_Export_Click(object sender, EventArgs e)
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            EvaluateTable evaluateTable = new EvaluateTable();
            if (EvaluateTableManagementCtrl.GetEvaluateTable(evaluatedID, ref evaluateTable, ref exception))
            {
                string filename = "";
                if (ExportManagementCtrl.ExportEvaluateTable(ref filename, evaluateTable, ref exception))
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

        #region Private
        private void loadEvaluateTable()
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            Panel1.Title = name + "的考核表";
            EvaluateTable evaluateTable = new EvaluateTable();
            if (EvaluateTableManagementCtrl.GetEvaluateTable(evaluatedID, ref evaluateTable, ref exception))
            {
                Label_EvaluatedName.Text = evaluateTable.EvaluatedName;
                Label_PostName.Text = evaluateTable.PostName;
                Label_LaborDep.Text = evaluateTable.LaborDep;
                Label_LaborUnit.Text = evaluateTable.LaborUnit;
                Label_Period.Text = evaluateTable.StartTime + " ~ " + evaluateTable.StopTime;

                int count = 1;
                foreach (Quota item in evaluateTable.KeyResponse)
                {
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_KeyResponse_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_KeyResponse_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_KeyResponse_" + count;
                    ta.Label = "内容";
                    ta.Text = item.Content[0];
                    sf.Items.Add(ta);
                    Panel3.Items.Add(sf);
                    count++;
                }

                count = 1;
                foreach (Quota item in evaluateTable.KeyQualify)
                { 
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_KeyQualify_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_KeyQualify_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_KeyQualify_" + count;
                    ta.Label = "内容";
                    ta.Text = "优：" + item.Content[0]
                        + "良：" + item.Content[1]
                        + "中：" + item.Content[2]
                        + "差：" + item.Content[3];
                    sf.Items.Add(ta);
                    Panel4.Items.Add(sf);
                    count++;
                }

                count = 1;
                foreach (Quota item in evaluateTable.KeyAttitude)
                {
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_KeyAttitude_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_KeyAttitude_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_KeyAttitude_" + count;
                    ta.Label = "内容";
                    ta.Text = "优：" + item.Content[0]
                        + "良：" + item.Content[1]
                        + "中：" + item.Content[2]
                        + "差：" + item.Content[3];
                    sf.Items.Add(ta);
                    Panel5.Items.Add(sf);
                    count++;
                }

                count = 1;
                foreach (Quota item in evaluateTable.Response)
                {
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_Response_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_Response_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_Response_" + count;
                    ta.Label = "内容";
                    ta.Text = item.Content[0];
                    sf.Items.Add(ta);
                    Panel6.Items.Add(sf);
                    count++;
                }

                count = 1;
                foreach (Quota item in evaluateTable.Qualify)
                {
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_Qualify_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_Qualify_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_Qualify_" + count;
                    ta.Label = "内容";
                    ta.Text = "优：" + item.Content[0]
                        + "良：" + item.Content[1]
                        + "中：" + item.Content[2]
                        + "差：" + item.Content[3];
                    sf.Items.Add(ta);
                    Panel7.Items.Add(sf);
                    count++;
                }

                count = 1;
                foreach (Quota item in evaluateTable.Attitude)
                {
                    SimpleForm sf = new SimpleForm();
                    sf.ID = "SimpleForm_Attitude_" + count;
                    sf.ShowHeader = false;
                    sf.ShowBorder = true;
                    sf.BodyPadding = "5px";
                    FineUI.TextBox tb = new FineUI.TextBox();
                    tb.ID = "TextBox_Attitude_" + count;
                    tb.Label = "标题";
                    tb.Text = item.Title;
                    sf.Items.Add(tb);
                    FineUI.TextArea ta = new FineUI.TextArea();
                    ta.ID = "TextArea_Attitude_" + count;
                    ta.Label = "内容";
                    ta.Text = "优：" + item.Content[0]
                        + "良：" + item.Content[1]
                        + "中：" + item.Content[2]
                        + "差：" + item.Content[3];
                    sf.Items.Add(ta);
                    Panel8.Items.Add(sf);
                    count++;
                }

                SimpleForm sf__reject = new SimpleForm();
                sf__reject.ID = "SimpleForm_Reject";
                sf__reject.ShowBorder = true;
                sf__reject.ShowHeader = false;
                sf__reject.BodyPadding = "5px";
                TextArea ta1 = new TextArea();
                ta1.Label = "严重违反规章制度";
                ta1.Text = "累计旷工3天以上的；\n严重失职，营私舞弊，给本单位造成3000元以上经济损失或者其它严重后果的；\n同时与其他用人单位建立劳动关系，对完成本单位工作任务造成严重影响，或者经本单位提出，拒不改正的；\n违背职业道德，行贿、受贿价值超过3000元以上的；\n被依法追究刑事责任的；";
                TextArea ta2 = new TextArea();
                ta2.Label = "其他";
                ta2.Text = evaluateTable.Reject[0].Content[0];
                sf__reject.Items.Add(ta1);
                sf__reject.Items.Add(ta2);
                Panel9.Items.Add(sf__reject);

                Label_Comment.Text = evaluateTable.Comment;
            }
            else
            {
                Alert.ShowInTop("查询失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}