using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Controls;
using DataStructure;

namespace HRES.Pages.PostBookManagement
{
    public partial class iframe_MakePostBook : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHideRefreshReference();
                Button_Close_Shadow.OnClientClick = ActiveWindow.GetConfirmHideRefreshReference();
                Button_Reject.OnClientClick = Window1.GetShowReference("../Common/iframe_Comment.aspx?id=" + Request.QueryString["id"] + "&parent=checkpostbook", "审核意见");
                Button_Reject_Shadow.OnClientClick = Window1.GetShowReference("../Common/iframe_Comment.aspx?id=" + Request.QueryString["id"], "审核意见");

                loadPostBook();     //载入岗位责任书

                setToolbarVisible();    //根据用户身份，设置工具栏中按钮的可见性
                setEnabled();           //根据岗位责任书的状态设置按钮的可用性
            }
        }

        #region Event
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string exception = "";
            PostBook pb = getPostBook();

            DocStatus curStatus = (DocStatus)Convert.ToInt32(Request.QueryString["status"]);
            DocStatus nextStatus = GetNextDocStatus(curStatus, DocOperation.save);
            pb.Status = nextStatus;     //填写下一个状态域

            if (PostBookManagementCtrl.UpdatePostBook(pb, ref exception))
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
            string exception = "";
            if (!checkNull())   //检查项是否有空
            {
                Alert.ShowInTop("有未填项，请检查！", MessageBoxIcon.Error);
                return;
            }

            PostBook pb = getPostBook();
            if (pb.WorkContentRequest.Count < 6)    //工作内容与要求至少需要6项
            {
                Alert.ShowInTop("请填写至少6项工作内容与要求！");
                return;
            }
            foreach (string[] item in pb.WorkContentRequest)        //检查是否存在工作内容与要求中填写了标题却没填其他项
            {
                if (!CheckNull(item))
                {
                    Alert.ShowInTop("工作内容与要求中尚有未填写项！");
                    return;
                }
            }

            List<string> tempTitleList = new List<string>();        //检查工作内容与要求中的标题是否有重复项
            foreach (string[] item in pb.WorkContentRequest)
            {
                if (tempTitleList.Contains(item[0]))
                {
                    Alert.ShowInTop("工作内容与要求中有重复项，请重新填写", MessageBoxIcon.Error);
                    return;
                }
                tempTitleList.Add(item[0]);
            }

            DocStatus curStatus = (DocStatus)Convert.ToInt32(Request.QueryString["status"]);
            DocStatus nextStatus = GetNextDocStatus(curStatus, DocOperation.submit);
            pb.Status = nextStatus;         //填写下一个状态域

            if (PostBookManagementCtrl.UpdatePostBook(pb, ref exception))
            {
                Alert.ShowInTop("提交成功！\n窗口即将关闭", MessageBoxIcon.Information);
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("提交失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            TextBox_LaborUnit.Text = "";
            TextBox_LaborDepart.Text = "";
            TextBox_PostName.Text = "";
            TextArea_EduBg.Text = "";
            TextArea_Certificate.Text = "";
            TextArea_Experience.Text = "";
            TextArea_Skill.Text = "";
            TextArea_Personality.Text = "";
            TextArea_PhyCond.Text = "";
            TextArea_WorkOutline.Text = "";
            TextArea_Power.Text = "";
            TextArea_Response.Text = "";
            TextBox_DirectLeader.Text = "";
            TextBox_Subordinate.Text = "";
            TextBox_Colleague.Text = "";
            TextBox_Services.Text = "";
            TextBox_Relations.Text = "";
            TextArea_WorkEnter.Text = "";
            TextArea_PostAssess.Text = "";
            TextArea_Others.Text = "";
            foreach (ControlBase item in Panel6.Items)
            {
                try
                {
                    SimpleForm sf = item as SimpleForm;
                    TextArea ta0 = sf.Items[0] as TextArea;
                    TextArea ta1 = sf.Items[1] as TextArea;
                    TextArea ta2 = sf.Items[2] as TextArea;
                    TextArea ta3 = sf.Items[3] as TextArea;
                    ta0.Text = "";
                    ta1.Text = "";
                    ta2.Text = "";
                    ta3.Text = "";
                    sf.Collapsed = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        protected void Button_Pass_Click(object sender, EventArgs e)
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            if (PostBookManagementCtrl.SetPass(evaluatedID, ref exception))
            {
                Alert.ShowInTop("设置成功！\n窗口即将关闭", MessageBoxIcon.Information);
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("设置失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        protected void Button_Export_Click(object sender, EventArgs e)
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            string evaluatedName = Request.QueryString["name"];
            PostBook postBook = new PostBook();
            if (PostBookManagementCtrl.GetPostBook(ref postBook, evaluatedID, ref exception))
            {
                string filename = "";
                if (ExportManagementCtrl.ExportPostBook(ref filename, evaluatedName, postBook, ref exception))
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
        /// <summary>
        /// 载入岗位责任书
        /// </summary>
        private void loadPostBook()
        {
            string exception = "";
            string evaluatedID = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            Panel1.Title = name + "的岗位责任书";
            PostBook pb = new PostBook();
            if (PostBookManagementCtrl.GetPostBook(ref pb, evaluatedID, ref exception))
            {

                foreach (string[] content in pb.WorkContentRequest)
                {
                    if (content.Length != 4)
                    {
                        return;
                    }
                }
                string evaluatedName = Request.QueryString["name"];
                Label_Comment.Text = pb.Comment;

                Radio_Employer.SelectedValue = pb.Employer;
                TextBox_LaborUnit.Text = pb.LaborUnit;
                TextBox_LaborDepart.Text = pb.LaborDepart;
                TextBox_PostName.Text = pb.PostName;
                Radio_PostType.SelectedValue = pb.PostType;
                TextArea_EduBg.Text = pb.EduBg;
                TextArea_Certificate.Text = pb.Certificate;
                TextArea_Experience.Text = pb.Experience;
                TextArea_Skill.Text = pb.Skill;
                TextArea_Personality.Text = pb.Personality;
                TextArea_PhyCond.Text = pb.PhyCond;
                TextArea_WorkOutline.Text = pb.WorkOutline;
                TextArea_Power.Text = pb.Power;
                TextArea_Response.Text = pb.Response;
                TextBox_DirectLeader.Text = pb.DirectLeader;
                TextBox_Subordinate.Text = pb.Subordinate;
                TextBox_Colleague.Text = pb.Colleague;
                TextBox_Services.Text = pb.Services;
                TextBox_Relations.Text = pb.Relations;
                TextArea_WorkEnter.Text = pb.WorkEnter;
                TextArea_PostAssess.Text = pb.PostAssess;
                TextArea_Others.Text = pb.Others;

                addWorkContentRequest(pb.WorkContentRequest);
            }
        }

        /// <summary>
        /// 想页面中增加工作内容与要求的simpleform
        /// </summary>
        /// <param name="workContentRequest"></param>
        private void addWorkContentRequest(List<string[]> workContentRequest)
        {
            for (int i = 0; i < workContentRequest.Count; i++)
            {
                SimpleForm sf = Panel6.Items[i] as SimpleForm;
                sf.Collapsed = false;
                TextArea title = sf.Items[0] as TextArea;
                TextArea content = sf.Items[1] as TextArea;
                TextArea request = sf.Items[2] as TextArea;
                TextArea point = sf.Items[3] as TextArea;
                title.Text = workContentRequest[i][0];
                content.Text = workContentRequest[i][1];
                request.Text = workContentRequest[i][2];
                point.Text = workContentRequest[i][3];
            }
        }

        /// <summary>
        /// 保存岗位责任书并将其状态设置成指定状态
        /// </summary>
        /// <param name="status">指定的状态</param>
        /// <returns></returns>
        private PostBook getPostBook()
        {
            PostBook pb = new PostBook();
            pb.EvaluatedID = Request.QueryString["id"];
            pb.Employer = Radio_Employer.SelectedValue;
            pb.LaborUnit = TextBox_LaborUnit.Text;
            pb.LaborDepart = TextBox_LaborDepart.Text;
            pb.PostName = TextBox_PostName.Text;
            pb.PostType = Radio_PostType.SelectedValue;
            pb.EduBg = TextArea_EduBg.Text;
            pb.Certificate = TextArea_Certificate.Text;
            pb.Experience = TextArea_Experience.Text;
            pb.Skill = TextArea_Skill.Text;
            pb.Personality = TextArea_Personality.Text;
            pb.PhyCond = TextArea_PhyCond.Text;
            pb.WorkOutline = TextArea_WorkOutline.Text;
            pb.Power = TextArea_Power.Text;
            pb.Response = TextArea_Response.Text;
            pb.DirectLeader = TextBox_DirectLeader.Text;
            pb.Subordinate = TextBox_Subordinate.Text;
            pb.Colleague = TextBox_Colleague.Text;
            pb.Services = TextBox_Services.Text;
            pb.Relations = TextBox_Relations.Text;
            pb.WorkEnter = TextArea_WorkEnter.Text;
            pb.PostAssess = TextArea_PostAssess.Text;
            pb.Others = TextArea_Others.Text;

            pb.Comment = Label_Comment.Text;

            List<string[]> wcr = new List<string[]>();
            foreach (ControlBase item in Panel6.Items)
            {
                try
                {
                    SimpleForm sf = item as SimpleForm;
                    TextArea ta0 = sf.Items[0] as TextArea;
                    if (ta0.Text != "")             //填写了标题即认为填写了这一项
                    {
                        TextArea ta1 = sf.Items[1] as TextArea;
                        TextArea ta2 = sf.Items[2] as TextArea;
                        TextArea ta3 = sf.Items[3] as TextArea;
                        string[] content = new string[] { ta0.Text, ta1.Text, ta2.Text, ta3.Text };
                        wcr.Add(content);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            pb.WorkContentRequest = wcr;

            return pb;
        }

        private bool checkNull()
        {
            if (TextBox_LaborUnit.Text != "" &&
                TextBox_LaborDepart.Text != "" &&
                TextBox_PostName.Text != "" &&
                TextArea_EduBg.Text != "" &&
                TextArea_Certificate.Text != "" &&
                TextArea_Experience.Text != "" &&
                TextArea_Skill.Text != "" &&
                TextArea_Personality.Text != "" &&
                TextArea_PhyCond.Text != "" &&
                TextArea_WorkOutline.Text != "" &&
                TextArea_Power.Text != "" &&
                TextArea_Response.Text != "" &&
                TextBox_DirectLeader.Text != "" &&
                TextBox_Subordinate.Text != "" &&
                TextBox_Colleague.Text != "" &&
                TextBox_Services.Text != "" &&
                TextBox_Relations.Text != "" &&
                TextArea_WorkEnter.Text != "" &&
                TextArea_PostAssess.Text != "" &&
                TextArea_Others.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户身份设置工具栏中按钮的可见性
        /// </summary>
        private void setToolbarVisible()
        {
            AccessLevel accessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), Session["AccessLevel"].ToString());
            if (accessLevel == AccessLevel.firstManager)
            {
                Button_Save.Visible = false;
                Button_Submit.Visible = false;
                Button_Clear.Visible = false;
                Button_Save_Shadow.Visible = false;
                Button_Submit_Shadow.Visible = false;
                Button_Clear_Shadow.Visible = false;

                ToolbarSeparator1.Visible = false;
                ToolbarSeparator2.Visible = false;
                ToolbarSeparator3.Visible = false;
                ToolbarSeparator6.Visible = false;
                ToolbarSeparator7.Visible = false;
                ToolbarSeparator8.Visible = false;
            }
            else if (accessLevel == AccessLevel.secondManager)
            {
                Button_Reject.Visible = false;
                Button_Pass.Visible = false;
                Button_Export.Visible = false;
                Button_Reject_Shadow.Visible = false;
                Button_Pass_Shadow.Visible = false;
                Button_Export_Shadow.Visible = false;

                ToolbarSeparator4.Visible = false;
                ToolbarSeparator5.Visible = false;
                ToolbarSeparator9.Visible = false;
                ToolbarSeparator10.Visible = false;
                ToolbarSeparator11.Visible = false;
                ToolbarSeparator12.Visible = false;
            }
        }

        /// <summary>
        /// 根据岗位责任书的当前状态设置按钮的可用性
        /// </summary>
        private void setEnabled()
        {
            DocStatus curStatus = (DocStatus)Enum.Parse(typeof(DocStatus), Request.QueryString["status"]);
            if (curStatus == DocStatus.unmake || curStatus == DocStatus.saved || curStatus == DocStatus.passed)
            {
                Button_Pass.Enabled = false;
                Button_Pass_Shadow.Enabled = false;
            }
            if (curStatus == DocStatus.unmake || curStatus == DocStatus.saved || curStatus == DocStatus.rejected)
            {
                Button_Reject.Enabled = false;
                Button_Reject_Shadow.Enabled = false;
            }
            if (curStatus == DocStatus.submitted || curStatus == DocStatus.modified || curStatus == DocStatus.passed)
            {
                Button_Save.Enabled = false;
                Button_Save_Shadow.Enabled = false;
                Button_Submit.Enabled = false;
                Button_Submit_Shadow.Enabled = false;
            }
        }

        //private void setEnabled()
        //{
        //    DocStatus status = (DocStatus)Enum.Parse(typeof(DocStatus), Request.QueryString["status"]);
        //    if (status == DocStatus.submitted || status == DocStatus.passed)
        //    {
        //        Button_Submit.Enabled = false;
        //        Button_Clear.Enabled = false;
        //        Button_Save.Enabled = false;
        //        Button_Submit_Shadow.Enabled = false;
        //        Button_Clear_Shadow.Enabled = false;
        //        Button_Save_Shadow.Enabled = false;


        //        TextBox_LaborUnit.Enabled = false;
        //        TextBox_LaborDepart.Enabled = false;
        //        TextBox_PostName.Enabled = false;
        //        TextArea_EduBg.Enabled = false;
        //        TextArea_Certificate.Enabled = false;
        //        TextArea_Experience.Enabled = false;
        //        TextArea_Skill.Enabled = false;
        //        TextArea_Personality.Enabled = false;
        //        TextArea_PhyCond.Enabled = false;
        //        TextArea_WorkOutline.Enabled = false;
        //        TextArea_Power.Enabled = false;
        //        TextArea_Response.Enabled = false;
        //        TextBox_DirectLeader.Enabled = false;
        //        TextBox_Subordinate.Enabled = false;
        //        TextBox_Colleague.Enabled = false;
        //        TextBox_Services.Enabled = false;
        //        TextBox_Relations.Enabled = false;
        //        TextArea_WorkEnter.Enabled = false;
        //        TextArea_PostAssess.Enabled = false;
        //        TextArea_Others.Enabled = false;

        //        Radio_Employer.Enabled = false;
        //        Radio_PostType.Enabled = false;

        //        foreach (ControlBase item in Panel6.Items)
        //        {
        //            try
        //            {
        //                SimpleForm sf = item as SimpleForm;
        //                item.Enabled = false;
        //            }
        //            catch (Exception)
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}