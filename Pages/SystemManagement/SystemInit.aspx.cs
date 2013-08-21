using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using FineUI;

namespace HRES.Pages.InitialManagement
{
    public partial class SystemInit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
        }

        protected void Button_Init_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.InitSystem(ref exception))
            {
                Alert.ShowInTop("初始化完毕！", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("初始化失败\n原因：！" + exception, MessageBoxIcon.Information);
                
            }
        }
    }
}