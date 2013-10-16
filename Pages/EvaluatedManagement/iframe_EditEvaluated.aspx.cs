using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using DataStructure;
using FineUI;

namespace HRES.Pages.EvaluatedManagement
{
    public partial class iframe_EditEvaluated : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定关闭按钮事件
                Button_Close.OnClientClick = ActiveWindow.GetConfirmHideReference();
                ViewState["id"] = Request.QueryString["id"];
                bindDepartToDropDownList();
                loadEvaluated();
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            loadEvaluated();
        }

        /// <summary>
        /// 更新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string id = ViewState["id"].ToString();
            //构造被考评人信息
            Evaluated evaluated = new Evaluated();
            evaluated.Id = id;
            evaluated.Name = TextBox_Name.Text.Trim();
            evaluated.Sex = DropDownList_Sex.SelectedValue;
            evaluated.Company = DropDownList_Company.SelectedValue;
            evaluated.Depart = DropDownList_Depart.SelectedValue;
            evaluated.LaborDepart = TextBox_LaborDepart.Text.Trim();
            evaluated.PostName = TextBox_PostName.Text.Trim();
            evaluated.PostType = DropDownList_PostType.SelectedValue;
            evaluated.Fund = TextBox_Fund.Text.Trim();
            evaluated.Character = TextBox_Character.Text.Trim();
            evaluated.StartTime = TextBox_StartTime.Text.Trim();
            evaluated.StopTime = TextBox_StopTime.Text.Trim();

            string exception = "";
            if (EvaluatedManagementCtrl.UpdateEvaluatedById(evaluated, id, ref exception))
            {
                Alert.ShowInTop("更新成功！\n窗口即将关闭", MessageBoxIcon.Information);
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.ShowInTop("更新失败！\n原因：" + exception, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定部门到下拉列表
        /// </summary>
        private void bindDepartToDropDownList()
        {
            string exception = "";
            List<string> departs = new List<string>();
            DropDownList_Depart.Items.Clear();
            if(CommonCtrl.GetDeparts(ref departs, ref exception))
            {
                foreach (string depart in departs)
                {
                    DropDownList_Depart.Items.Add(depart, depart);
                }
            }
        }

        /// <summary>
        /// 载入被考评人信息
        /// </summary>
        private void loadEvaluated()
        {
            string id = ViewState["id"].ToString();
            string exception = "";
            Evaluated evaluated = new Evaluated();
            if (EvaluatedManagementCtrl.GetEvaluatedById(ref evaluated, id, ref exception))
            {
                Label_ID.Text = evaluated.Id;
                TextBox_Name.Text = evaluated.Name;
                DropDownList_Sex.SelectedValue = evaluated.Sex;
                DropDownList_Company.SelectedValue = evaluated.Company;
                DropDownList_Depart.SelectedValue = evaluated.Depart;
                TextBox_LaborDepart.Text = evaluated.LaborDepart;
                TextBox_PostName.Text = evaluated.PostName;
                DropDownList_PostType.SelectedValue = evaluated.PostType;
                TextBox_Fund.Text = evaluated.Fund;
                TextBox_Character.Text = evaluated.Character;
                TextBox_StartTime.Text = evaluated.StartTime;
                TextBox_StopTime.Text = evaluated.StopTime;
            }
        }
        #endregion
    }
}