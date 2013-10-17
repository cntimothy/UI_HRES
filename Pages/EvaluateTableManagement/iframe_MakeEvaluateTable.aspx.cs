using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;
using DataStructure;
using System.Text;
using System.Web.Script.Serialization;

namespace HRES.Pages.EvaluateTableManagement
{
    public partial class iframe_MakeEvaluateTable : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                if (!checkPostBook())
                {
                    Alert.ShowInTop("被考评人岗位责任书尚未通过审核！\n窗口即将关闭", MessageBoxIcon.Error);
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
                }

                Button_Close.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                Button_Close_Shadow.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

                DocStatus curStatus = (DocStatus)Enum.Parse(typeof(DocStatus), Request.QueryString["status"]);
                if (curStatus == DocStatus.submitted || curStatus == DocStatus.passed)  //当文档状态为已提交或者已通过时，保存、提交、清空按钮不可用
                {
                    Button_Save.Enabled = false;
                    Button_Submit.Enabled = false;
                    Button_Clear.Enabled = false;
                    Button_Save_Shadow.Enabled = false;
                    Button_Submit_Shadow.Enabled = false;
                    Button_Clear_Shadow.Enabled = false;

                    DropDownList_Template.Enabled = false;
                }

                if (curStatus == DocStatus.passed)      //只有当文档状态为已通过时，导出按钮才可用
                {
                    Button_Export.Enabled = true;
                    Button_Export_Shadow.Enabled = true;
                }

                loadEvaluateTable("");
                bindEvaluateTableSubmittedNameIdDicToDropDownList();
            }
            if (Page.Request.Params["__EVENTTARGET"] != null && Page.Request.Params["__EVENTTARGET"].ToString().Replace('$', '_') == DropDownList_Template.ClientID)
            {
                loadEvaluateTable(DropDownList_Template.SelectedValue);
            }
        }
        #endregion

        #region Event
        #region TriggerBoxEvent
        //关键岗位责任指标触发器
        protected void TriggerBox_KeyResponse_1_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyResponse_1.ClientID, TextArea_KeyResponse_1.ClientID, HiddenField_KeyResponse_1.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_KeyResponse_2_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyResponse_2.ClientID, TextArea_KeyResponse_2.ClientID, HiddenField_KeyResponse_2.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_KeyResponse_3_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyResponse_3.ClientID, TextArea_KeyResponse_3.ClientID, HiddenField_KeyResponse_3.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_KeyResponse_4_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyResponse_4.ClientID, TextArea_KeyResponse_4.ClientID, HiddenField_KeyResponse_4.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_KeyResponse_5_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyResponse_5.ClientID, TextArea_KeyResponse_5.ClientID, HiddenField_KeyResponse_5.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        //岗位责任指标触发器
        protected void TriggerBox_Response_1_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Response_1.ClientID, TextArea_Response_1.ClientID, HiddenField_Response_1.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_Response_2_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Response_2.ClientID, TextArea_Response_2.ClientID, HiddenField_Response_2.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_Response_3_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Response_3.ClientID, TextArea_Response_3.ClientID, HiddenField_Response_3.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_Response_4_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Response_4.ClientID, TextArea_Response_4.ClientID, HiddenField_Response_4.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        protected void TriggerBox_Response_5_Click(object sender, EventArgs e)
        {
            syncSelectedWCR();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Response_5.ClientID, TextArea_Response_5.ClientID, HiddenField_Response_5.ClientID)
                + Window_ShowQuota.GetShowReference("iframe_ShowWCR.aspx?id=" + Request.QueryString["id"] + "&selected=" + Server.UrlEncode(hfSelectedWCR.Text)));
        }

        //关键岗位胜任能力指标触发器
        protected void TriggerBox_KeyQualify_1_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyQualify_1.ClientID, TextArea_KeyQualify_1.ClientID, HiddenField_KeyQualify_1.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyQualify_2_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyQualify_2.ClientID, TextArea_KeyQualify_2.ClientID, HiddenField_KeyQualify_2.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyQualify_3_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyQualify_3.ClientID, TextArea_KeyQualify_3.ClientID, HiddenField_KeyQualify_3.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyQualify_4_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyQualify_4.ClientID, TextArea_KeyQualify_4.ClientID, HiddenField_KeyQualify_4.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyQualify_5_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyQualify_5.ClientID, TextArea_KeyQualify_5.ClientID, HiddenField_KeyQualify_5.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }



        //关键工作态度指标触发器
        protected void TriggerBox_KeyAttitude_1_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyAttitude_1.ClientID, TextArea_KeyAttitude_1.ClientID, HiddenField_KeyAttitude_1.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyAttitude_2_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyAttitude_2.ClientID, TextArea_KeyAttitude_2.ClientID, HiddenField_KeyAttitude_2.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyAttitude_3_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyAttitude_3.ClientID, TextArea_KeyAttitude_3.ClientID, HiddenField_KeyAttitude_3.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyAttitude_4_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyAttitude_4.ClientID, TextArea_KeyAttitude_4.ClientID, HiddenField_KeyAttitude_4.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_KeyAttitude_5_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_KeyAttitude_5.ClientID, TextArea_KeyAttitude_5.ClientID, HiddenField_KeyAttitude_5.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        //岗位胜任能力指标触发器
        protected void TriggerBox_Qualify_1_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Qualify_1.ClientID, TextArea_Qualify_1.ClientID, HiddenField_Qualify_1.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Qualify_2_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Qualify_2.ClientID, TextArea_Qualify_2.ClientID, HiddenField_Qualify_2.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Qualify_3_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Qualify_3.ClientID, TextArea_Qualify_3.ClientID, HiddenField_Qualify_3.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Qualify_4_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Qualify_4.ClientID, TextArea_Qualify_4.ClientID, HiddenField_Qualify_4.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Qualify_5_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Qualify_5.ClientID, TextArea_Qualify_5.ClientID, HiddenField_Qualify_5.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }



        //工作态度指标触发器
        protected void TriggerBox_Attitude_1_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Attitude_1.ClientID, TextArea_Attitude_1.ClientID, HiddenField_Attitude_1.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Attitude_2_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Attitude_2.ClientID, TextArea_Attitude_2.ClientID, HiddenField_Attitude_2.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Attitude_3_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Attitude_3.ClientID, TextArea_Attitude_3.ClientID, HiddenField_Attitude_3.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Attitude_4_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Attitude_4.ClientID, TextArea_Attitude_4.ClientID, HiddenField_Attitude_4.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }

        protected void TriggerBox_Attitude_5_Click(object sender, EventArgs e)
        {
            syncSelectedQuota();
            PageContext.RegisterStartupScript(Window_ShowQuota.GetSaveStateReference(TriggerBox_Attitude_5.ClientID, TextArea_Attitude_5.ClientID, HiddenField_Attitude_5.ClientID)
            + Window_ShowQuota.GetShowReference("iframe_ShowQuota.aspx?selected=" + Server.UrlEncode(hfSelectedQuota.Text)));
        }
        
        #endregion

        protected void DropDownList_Template_SelectedChanged(object sender, EventArgs e)
        {
        }

        protected void Window_ShowQuota_Close(object sender, WindowCloseEventArgs e)
        {

        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            DocStatus curStatus = (DocStatus)Enum.Parse(typeof(DocStatus), Request.QueryString["status"]);
            DocStatus nextStatus = GetNextDocStatus(curStatus, DocOperation.save);
            EvaluateTable evaluateTable = getNewEvaluateTable();
            string evaluatedID = Request.QueryString["id"];
            string exception = "";
            if (EvaluateTableManagementCtrl.UpdateEvaluateTable(evaluatedID, evaluateTable, nextStatus, ref exception))
            {
                Alert.ShowInTop("保存成功！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("保存失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            DocStatus curStatus = (DocStatus)Enum.Parse(typeof(DocStatus), Request.QueryString["status"]);
            DocStatus nextStatus = GetNextDocStatus(curStatus, DocOperation.submit);
            EvaluateTable evaluateTable = getNewEvaluateTable();
            if (!checkEvaluateTableNull(evaluateTable))
            {
                Alert.ShowInTop("有未填写项！", MessageBoxIcon.Error);
                return;
            }

            if (!checkItemEnough(evaluateTable))
            {
                Alert.ShowInTop("考核表中每项指标至少填写两项！", MessageBoxIcon.Error);
                return;
            }

            if (!checkRepetition(evaluateTable))
            {
                Alert.ShowInTop("考核表中不允许有重复项！请检查", MessageBoxIcon.Error);
                return;
            }
            string evaluatedID = Request.QueryString["id"];
            string exception = "";
            if (EvaluateTableManagementCtrl.UpdateEvaluateTable(evaluatedID, evaluateTable, nextStatus, ref exception))
            {
                Alert.ShowInTop("提交成功！\n窗口即将关闭", MessageBoxIcon.Information);
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("提交失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Button_Export_Click(object sender, EventArgs e)
        { 
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            EvaluateTable evaluateTable = new EvaluateTable();
            if (EvaluateTableManagementCtrl.GetEvaluateTable(evaluatedID, ref evaluateTable, ref exception))
            {
                string sourceName = "";
                if (ExportManagementCtrl.ExportEvaluateTable(ref sourceName, evaluateTable, ref exception))
                {
                    string targetName = "";
                    if (ExportManagementCtrl.ConvertExcelToPDF(ref targetName, sourceName, ref exception))
                    {
                        Response.ClearContent();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(targetName));
                        string path = Server.MapPath("..\\..\\downloadfiles\\" + targetName);
                        Response.TransmitFile(path);
                    }
                    else
                    {
                        Alert.ShowInTop("导出失败！\n原因：" + exception, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Alert.ShowInTop("导出失败！\n原因：" + exception, MessageBoxIcon.Error);
                }
            }
            else
            {
                Alert.ShowInTop("导出失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private Method

        /// <summary>
        /// 将已提交考核表的被考评人姓名id字典绑定到下拉列表
        /// </summary>
        private void bindEvaluateTableSubmittedNameIdDicToDropDownList()
        {
            string exception = "";
            Dictionary<string, string> nameIdDic = new Dictionary<string, string>();
            string depart = (string)Session["Depart"];
            if (EvaluateTableManagementCtrl.GetSubmittedNameIdDic(ref nameIdDic, depart, ref exception))
            {
                foreach (string name in nameIdDic.Keys)
                {
                    DropDownList_Template.Items.Add(name, nameIdDic[name]);
                }
            }
            //else
            //{
            //    Alert.ShowInTop(exception);
            //}
        }

        /// <summary>
        /// 载入考核表
        /// </summary>
        private void loadEvaluateTable(string id)
        {
            string evaluatedID = "";
            if (id == "" || id == "0")
            {
                evaluatedID = Request.QueryString["id"];
            }
            else
            {
                evaluatedID = id;
            }
            Panel1.Title = Request.QueryString["name"] + "的考核表";
            EvaluateTable evaluateTable = new EvaluateTable();
            string exception = "";
            if (EvaluateTableManagementCtrl.GetEvaluateTable(evaluatedID, ref evaluateTable, ref exception))
            {
                Label_Comment.Text = evaluateTable.Comment;

                Label_EvaluatedName.Text = evaluateTable.EvaluatedName;
                Label_PostName.Text = evaluateTable.PostName;
                Label_LaborDep.Text = evaluateTable.LaborDep;
                Label_LaborUnit.Text = evaluateTable.LaborUnit;
                Label_Period.Text = evaluateTable.StartTime + " ~ " + evaluateTable.StopTime;

                for (int i = 0; i < evaluateTable.KeyResponse.Count; i++)
                {
                    SimpleForm sf = Panel3.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    tb.Text = evaluateTable.KeyResponse[i].Title;
                    ta.Text = evaluateTable.KeyResponse[i].Content[0];
                    hf.Text = evaluateTable.KeyResponse[i].Title + "&" + evaluateTable.KeyResponse[i].Content[0];
                }

                for (int i = 0; i < evaluateTable.KeyQualify.Count; i++)
                {
                    SimpleForm sf = Panel4.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    tb.Text = evaluateTable.KeyQualify[i].Title;
                    ta.Text = "优：" + evaluateTable.KeyQualify[i].Content[0]
                        + " 良：" + evaluateTable.KeyQualify[i].Content[1]
                        + " 中：" + evaluateTable.KeyQualify[i].Content[2]
                        + " 差：" + evaluateTable.KeyQualify[i].Content[3];

                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    hf.Text = evaluateTable.KeyQualify[i].Title
                    + "&" + evaluateTable.KeyQualify[i].Content[0]
                    + "^" + evaluateTable.KeyQualify[i].Content[1]
                    + "^" + evaluateTable.KeyQualify[i].Content[2]
                    + "^" + evaluateTable.KeyQualify[i].Content[3];
                }

                for (int i = 0; i < evaluateTable.KeyAttitude.Count; i++)
                {
                    SimpleForm sf = Panel5.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    tb.Text = evaluateTable.KeyAttitude[i].Title;
                    ta.Text = "优：" + evaluateTable.KeyAttitude[i].Content[0]
                        + " 良：" + evaluateTable.KeyAttitude[i].Content[1]
                        + " 中：" + evaluateTable.KeyAttitude[i].Content[2]
                        + " 差：" + evaluateTable.KeyAttitude[i].Content[3];

                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    hf.Text = evaluateTable.KeyAttitude[i].Title
                    + "&" + evaluateTable.KeyAttitude[i].Content[0]
                    + "^" + evaluateTable.KeyAttitude[i].Content[1]
                    + "^" + evaluateTable.KeyAttitude[i].Content[2]
                    + "^" + evaluateTable.KeyAttitude[i].Content[3];
                }

                for (int i = 0; i < evaluateTable.Response.Count; i++)
                {
                    SimpleForm sf = Panel6.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    tb.Text = evaluateTable.Response[i].Title;
                    ta.Text = evaluateTable.Response[i].Content[0];
                    hf.Text = evaluateTable.Response[i].Title + "&" + evaluateTable.Response[i].Content[0];
                }

                for (int i = 0; i < evaluateTable.Qualify.Count; i++)
                {
                    SimpleForm sf = Panel7.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    tb.Text = evaluateTable.Qualify[i].Title;
                    ta.Text = "优：" + evaluateTable.Qualify[i].Content[0]
                        + " 良：" + evaluateTable.Qualify[i].Content[1]
                        + " 中：" + evaluateTable.Qualify[i].Content[2]
                        + " 差：" + evaluateTable.Qualify[i].Content[3];

                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    hf.Text = evaluateTable.Qualify[i].Title
                    + "&" + evaluateTable.Qualify[i].Content[0]
                    + "^" + evaluateTable.Qualify[i].Content[1]
                    + "^" + evaluateTable.Qualify[i].Content[2]
                    + "^" + evaluateTable.Qualify[i].Content[3];
                }

                for (int i = 0; i < evaluateTable.Attitude.Count; i++)
                {
                    SimpleForm sf = Panel8.Items[i] as SimpleForm;
                    sf.Collapsed = false;
                    TriggerBox tb = sf.Items[0] as TriggerBox;
                    TextArea ta = sf.Items[1] as TextArea;
                    tb.Text = evaluateTable.Attitude[i].Title;
                    ta.Text = "优：" + evaluateTable.Attitude[i].Content[0]
                        + " 良：" + evaluateTable.Attitude[i].Content[1]
                        + " 中：" + evaluateTable.Attitude[i].Content[2]
                        + " 差：" + evaluateTable.Attitude[i].Content[3];

                    FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                    hf.Text = evaluateTable.Attitude[i].Title
                    + "&" + evaluateTable.Attitude[i].Content[0]
                    + "^" + evaluateTable.Attitude[i].Content[1]
                    + "^" + evaluateTable.Attitude[i].Content[2]
                    + "^" + evaluateTable.Attitude[i].Content[3];
                }

                TextArea_Reject1.Text = "累计旷工3天以上的；\n严重失职，营私舞弊，给本单位造成3000元以上经济损失或者其它严重后果的；\n同时与其他用人单位建立劳动关系，对完成本单位工作任务造成严重影响，或者经本单位提出，拒不改正的；\n违背职业道德，行贿、受贿价值超过3000元以上的；\n被依法追究刑事责任的；";
                TextArea_Reject2.Text = evaluateTable.Reject[0].Content[0];
            }
            else    //如果该被考评人的岗位责任书尚未制定，则被考评人姓名、岗位名称、用工部门、用工单位和考核时间段从父网页获取
            {
                Label_EvaluatedName.Text = Request.QueryString["name"];
                Label_PostName.Text = Request.QueryString["postname"];
                Label_LaborDep.Text = Request.QueryString["labordepart"];
                Label_LaborUnit.Text = Request.QueryString["depart"];
                Label_Period.Text = Request.QueryString["starttime"] + " ~ " + Request.QueryString["stoptime"];
                TextArea_Reject1.Text = "累计旷工3天以上的；\n严重失职，营私舞弊，给本单位造成3000元以上经济损失或者其它严重后果的；\n同时与其他用人单位建立劳动关系，对完成本单位工作任务造成严重影响，或者经本单位提出，拒不改正的；\n违背职业道德，行贿、受贿价值超过3000元以上的；\n被依法追究刑事责任的；";
            }
        }

        /// <summary>
        /// 获取当前页面中的考核表
        /// </summary>
        /// <returns></returns>
        private EvaluateTable getNewEvaluateTable()
        {
            EvaluateTable evaluateTable = new EvaluateTable();
            evaluateTable.EvaluatedName = Label_EvaluatedName.Text.Trim();
            evaluateTable.PostName = Label_PostName.Text.Trim();
            evaluateTable.LaborDep = Label_LaborDep.Text.Trim();
            evaluateTable.LaborUnit = Label_LaborUnit.Text.Trim();
            evaluateTable.StartTime = Label_Period.Text.Split('~')[0].Trim();
            evaluateTable.StopTime = Label_Period.Text.Split('~')[1].Trim();
            foreach (ControlBase item in Panel3.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = new string[]{hf.Text.Split('&')[1]};
                evaluateTable.KeyResponse.Add(new Quota(title, content));
            }

            foreach (ControlBase item in Panel4.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = hf.Text.Split('&')[1].Split('^');
                evaluateTable.KeyQualify.Add(new Quota(title, content));
            }

            foreach (ControlBase item in Panel5.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = hf.Text.Split('&')[1].Split('^');
                evaluateTable.KeyAttitude.Add(new Quota(title, content));
            }

            foreach (ControlBase item in Panel6.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text == "")
                {
                    break;
                }
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = new string[] { hf.Text.Split('&')[1] };
                evaluateTable.Response.Add(new Quota(title, content));
            }

            foreach (ControlBase item in Panel7.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = hf.Text.Split('&')[1].Split('^');
                evaluateTable.Qualify.Add(new Quota(title, content));
            }

            foreach (ControlBase item in Panel8.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                string[] content = hf.Text.Split('&')[1].Split('^');
                evaluateTable.Attitude.Add(new Quota(title, content));
            }

            evaluateTable.Reject.Add(new Quota("其他", new string[] { TextArea_Reject2.Text.Trim() }));

            return evaluateTable;
        }

        /// <summary>
        /// 查询被考评人的岗位责任书是否已通过，已通过返回true，否则返回false
        /// </summary>
        /// <returns></returns>
        private bool checkPostBook()
        {
            string evaluatedID = Request.QueryString["id"];
            string exception = "";
            if (EvaluateTableManagementCtrl.IsExist(evaluatedID, ref exception))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查考核表是否有未填项，如果有则返回false，否则返回true
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        private bool checkEvaluateTableNull(EvaluateTable et)
        {
            //if (et.EvaluatedName == "" || et.PostName == "" || et.LaborDep == "" || et.LaborUnit == "" || et.StartTime == "" || et.StopTime == "")
            //    return false;
            if (et.EvaluatedName == "" || et.PostName == "" || et.LaborDep == "" || et.LaborUnit == "" )
                return false;
            else
                return true;
        }

        /// <summary>
        /// 检查考核表中各项指标的数量是否足够，不够返回false，否则返回true
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        private bool checkItemEnough(EvaluateTable et)
        {
            if (et.KeyResponse.Count < 2 || et.KeyQualify.Count < 2 || et.KeyAttitude.Count < 2
                || et.Response.Count < 2 || et.Qualify.Count < 2 || et.Attitude.Count < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 清空所有项目
        /// </summary>
        private void clearAll()
        {
            Label_Period.Text = "";

            foreach (ControlBase cb in Panel3.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            foreach (ControlBase cb in Panel4.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            foreach (ControlBase cb in Panel5.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            foreach (ControlBase cb in Panel6.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            foreach (ControlBase cb in Panel7.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            foreach (ControlBase cb in Panel8.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                tb.Text = "";
                ta.Text = "";
                hf.Text = "";
            }

            TextArea_Reject1.Text = "累计旷工3天以上的；\n严重失职，营私舞弊，给本单位造成3000元以上经济损失或者其它严重后果的；\n同时与其他用人单位建立劳动关系，对完成本单位工作任务造成严重影响，或者经本单位提出，拒不改正的；\n违背职业道德，行贿、受贿价值超过3000元以上的；\n被依法追究刑事责任的；";
            TextArea_Reject2.Text = "";
        }

        /// <summary>
        /// 检查是否有重复项，无返回true，否则返回false
        /// </summary>
        /// <param name="evaluateTable"></param>
        /// <returns></returns>
        private bool checkRepetition(EvaluateTable evaluateTable)
        {
            List<string> contentList = new List<string>();
            foreach (Quota quota in evaluateTable.KeyResponse)  //检查关键岗位职责指标
            {
                if (contentList.Contains(quota.Content[0]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            foreach (Quota quota in evaluateTable.KeyQualify)   //检查关键岗位胜任能力指标
            {
                if (contentList.Contains(quota.Content[0] + quota.Content[1] + quota.Content[2] + quota.Content[3]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            foreach (Quota quota in evaluateTable.KeyAttitude)  //检查关键岗位工作态度指标
            {
                if (contentList.Contains(quota.Content[0] + quota.Content[1] + quota.Content[2] + quota.Content[3]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            foreach (Quota quota in evaluateTable.Response)     //检查岗位职责指标
            {
                if (contentList.Contains(quota.Content[0]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            foreach (Quota quota in evaluateTable.Qualify)      //检查岗位胜任能力指标
            {
                if (contentList.Contains(quota.Content[0] + quota.Content[1] + quota.Content[2] + quota.Content[3]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            foreach (Quota quota in evaluateTable.Attitude)     //检查工作态度指标
            {
                if (contentList.Contains(quota.Content[0] + quota.Content[1] + quota.Content[2] + quota.Content[3]))
                {
                    return false;
                }
                else
                {
                    contentList.Add(quota.Content[0]);
                }
            }
            return true;
        }

        /// <summary>
        /// 同步已选择的工作内容与要求到hiddenfield
        /// </summary>
        /// <returns></returns>
        private void syncSelectedWCR()
        {
            List<string> selectedWCR = new List<string>();
            foreach (ControlBase item in Panel3.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedWCR.Add(title);
            }

            foreach (ControlBase item in Panel6.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text == "")
                {
                    break;
                }
                TextArea ta = sf.Items[1] as TextArea;
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedWCR.Add(title);
            }

            StringBuilder sb = new StringBuilder();
            foreach (string WCR in selectedWCR)
            {
                sb.Append(WCR + "$");
            }
            hfSelectedWCR.Text = sb.ToString(); 
        }

        /// <summary>
        /// 同步已选择的指标到hiddenfield
        /// </summary>
        private void syncSelectedQuota()
        {
            List<string> selectedQuota = new List<string>();
            foreach (ControlBase item in Panel4.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedQuota.Add(title);
            }
            foreach (ControlBase item in Panel5.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedQuota.Add(title);
            }
            foreach (ControlBase item in Panel7.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedQuota.Add(title);
            }
            foreach (ControlBase item in Panel8.Items)
            {
                SimpleForm sf = item as SimpleForm;
                TriggerBox tb = sf.Items[0] as TriggerBox;
                if (tb.Text.Trim() == "")
                {
                    break;
                }
                FineUI.HiddenField hf = sf.Items[2] as FineUI.HiddenField;
                string title = hf.Text.Split('&')[0].Trim();
                selectedQuota.Add(title);
            }

            StringBuilder sb = new StringBuilder();
            foreach (string quota in selectedQuota)
            {
                sb.Append(quota + "$");
            }
            hfSelectedQuota.Text = sb.ToString(); 
        }
        #endregion
    }
}