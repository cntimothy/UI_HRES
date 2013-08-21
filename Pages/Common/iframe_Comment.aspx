<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_Comment.aspx.cs"
    Inherits="HRES.Pages.Common.iframe_Comment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
            Title="Panel" AutoHeight="true">
            <Items>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="Button_Reject" runat="server" Text="退回" OnClick="Button_Reject_Click">
                        </x:Button>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:Button ID="Button_Cancel" runat="server" Text="取消">
                        </x:Button>
                    </Items>
                </x:Toolbar>
                <x:TextArea ID="TextArea_Comment" runat="server" Height="50px" Text="" EmptyText="请输入审核意见（最多50字）" CssStyle="width:97.8%">
                </x:TextArea>
            </Items>
        </x:Panel>
    </div>
    </form>
</body>
</html>
