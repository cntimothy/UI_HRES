<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemInit.aspx.cs" Inherits="HRES.Pages.InitialManagement.SystemInit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel">
        <Items>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="Button_Init" runat="server" Text="系统初始化" ConfirmTitle="提示" ConfirmText="确定初始化系统？操作不可恢复！" OnClick="Button_Init_Click">
                    </x:Button>
                </Items>
            </x:Toolbar>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
