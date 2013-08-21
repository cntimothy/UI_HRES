<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetFirst.aspx.cs" Inherits="HRES.Pages.FirstManagement.ResetFirst" %>

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
                    <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:Grid ID="Grid1" runat="server" Title="Grid" AllowPaging="true" PageSize="20" Width="380px" AutoHeight="true"
                OnRowCommand="Grid1_RowCommand" DataKeyNames="ID" OnPageIndexChange="Grid1_PageIndexChange"
                EnableRowNumber="true">
                <Columns>
                    <x:BoundField Width="200px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                    <x:LinkButtonField HeaderText="操作" Width="150px" ConfirmText="确定重置？" ConfirmTarget="Top"
                        CommandName="Reset" Text="重置" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
