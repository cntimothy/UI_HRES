<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_EditEvaluated.aspx.cs"
    Inherits="HRES.Pages.EvaluatedManagement.iframe_EditEvaluated" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" AutoScroll="true">
        <Items>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Button_Update" runat="server" Text="更新">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:Button ID="Button_Close" runat="server" Text="关闭">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:Label ID="Label_ID" runat="server" Label="ID" Text="Label">
                    </x:Label>
                    <x:TextBox ID="TextBox_Name" runat="server" Label="姓名" Text="">
                    </x:TextBox>
                    <x:DropDownList ID="DropDownList_Sex" runat="server" Label="性别">
                        <x:ListItem EnableSelect="true" Text="男" Value="男" />
                        <x:ListItem EnableSelect="true" Text="女" Value="女" />
                    </x:DropDownList>
                    <x:DropDownList ID="DropDownList_Company" runat="server" Label="用人单位">
                        <x:ListItem EnableSelect="true" Text="上海市东凌国际人才有限公司" Value="上海市东凌国际人才有限公司" />
                        <x:ListItem EnableSelect="true" Text="上海黄渡同济人力资源有限公司" Value="上海黄渡同济人力资源有限公司" />
                    </x:DropDownList>
                    <x:DropDownList ID="DropDownList_Depart" runat="server" Label="用工单位">
                    </x:DropDownList>
                    <x:TextBox ID="TextBox_LaborDepart" runat="server" Label="用工部门" Text="">
                    </x:TextBox>
                    <x:TextBox ID="TextBox_PostName" runat="server" Label="岗位名称" Text="">
                    </x:TextBox>
                    <x:DropDownList ID="DropDownList_PostType" runat="server" Label="岗位类型">
                        <x:ListItem EnableSelect="true" Text="管理" Value="管理" />
                        <x:ListItem EnableSelect="true" Text="教辅" Value="教辅" />
                        <x:ListItem EnableSelect="true" Text="思政" Value="思政" />
                        <x:ListItem EnableSelect="true" Text="教师" Value="教师" />
                        <x:ListItem EnableSelect="true" Text="工勤" Value="工勤" />
                    </x:DropDownList>
                    <x:TextBox ID="TextBox_Fund" runat="server" Label="资金来源" Text="">
                    </x:TextBox>
                    <x:TextBox ID="TextBox_Character" runat="server" Label="派遣性质" Text="">
                    </x:TextBox>
                    <x:TextBox ID="TextBox_StartTime" runat="server" Label="开始时间" Text="">
                    </x:TextBox>
                    <x:TextBox ID="TextBox_StopTime" runat="server" Label="结束时间" Text="">
                    </x:TextBox>
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
