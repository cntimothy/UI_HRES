﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using FineUI;
using System.Xml;
using DataStructure;

namespace HRES.Pages
{
    public partial class HomePage : PageBase
    {
        #region Page_Init

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserName"] == null || Session["AccessLevel"] == null || Session["Depart"] == null)
            {
                Session["UserID"] = null;
                Session["UserName"] = null;
                Session["AccessLevel"] = null;
                Session["Depart"] = null;
                //PageContext.Redirect(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Login.aspx", "_top");
                Response.Redirect("../Login.aspx");
            }
            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(mainTabStrip);

            Accordion accordionMenu = InitAccordionMenu();
            ids.Add("mainMenu", accordionMenu.ClientID);
            ids.Add("menuType", "accordion");


            // 只在页面第一次加载时注册客户端用到的脚本
            if (!Page.IsPostBack)
            {
                string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                PageContext.RegisterStartupScript(idsScriptStr);
            }
        }

        private Accordion InitAccordionMenu()
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            Region2.Items.Add(accordionMenu);

            AccessLevel accessLevel = (AccessLevel)Session["AccessLevel"];
            XmlDocument xmlDoc;
            switch (accessLevel)
            { 
                case AccessLevel.superManager:
                    xmlDoc = XmlDataSource_Super.GetXmlDocument();
                    break;
                case AccessLevel.firstManager:
                    xmlDoc = XmlDataSource_FirstManager.GetXmlDocument();
                    break;
                case AccessLevel.secondManager:
                    xmlDoc = XmlDataSource_SecondManager.GetXmlDocument();
                    break;
                case AccessLevel.evaluator:
                    xmlDoc = XmlDataSource_Evaluator.GetXmlDocument();
                    break;
                default:
                    return null;
            }
                
            
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = xmlNode.Attributes["Text"].Value;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.EnableArrows = true;
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = false;
                    innerTree.AutoScroll = true;
                    accordionPane.Items.Add(innerTree);

                    XmlDocument innerXmlDoc = new XmlDocument();
                    innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));

                    // 绑定AccordionPane内部的树控件
                    innerTree.DataSource = innerXmlDoc;
                    innerTree.DataBind();

                    // 重新设置每个节点的图标
                    ResolveTreeNode(innerTree.Nodes);
                }
            }

            return accordionMenu;
        }

        //private Tree InitTreeMenu()
        //{
        //    Tree treeMenu = new Tree();
        //    treeMenu.ID = "treeMenu";
        //    treeMenu.EnableArrows = true;
        //    treeMenu.ShowBorder = false;
        //    treeMenu.ShowHeader = false;
        //    treeMenu.EnableIcons = false;
        //    treeMenu.AutoScroll = true;
        //    Region2.Items.Add(treeMenu);

        //    // 绑定 XML 数据源到树控件
        //    treeMenu.DataSource = XmlDataSource1;
        //    treeMenu.DataBind();

        //    // 重新设置每个节点的图标
        //    ResolveTreeNode(treeMenu.Nodes);

        //    return treeMenu;
        //}


        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserName.Text += (string)Session["UserName"];
            }
        }
        #endregion

        #region Event
        public void LoginOut_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["AccessLevel"] = null;
            Session["Depart"] = null;
            Response.Redirect("../Login.aspx");
        }

        private string GetSelectedMenuID(MenuButton menuButton)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                if (item is MenuCheckBox && (item as MenuCheckBox).Checked)
                {
                    return item.ID;
                }
            }
            return null;
        }

        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox menu = (item as MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }


        private void SaveToCookieAndRefresh(string cookieName, string cookieValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            PageContext.Refresh();
        }


        #endregion

        #region Tree

        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(FineUI.TreeNodeCollection nodes)
        {
            foreach (FineUI.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "~/images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "~/images/filetype/vs_txt.png";
            }
            else if (fileType == "aspx")
            {
                iconUrl = "~/images/filetype/vs_aspx.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "~/images/filetype/vs_htm.png";
            }

            return iconUrl;
        }

        #endregion
    }
}