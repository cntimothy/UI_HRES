<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClearData.aspx.cs" Inherits="HRES.Pages.DataBaseManagement.ClearDataBase" %>

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
            <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:100%">
                <Items>
                    <x:Button ID="Button_ClearAll" runat="server" Text="清空数据库（不包括指标库）" OnClick="Button_ClearAll_Click" ConfirmTitle="提示" ConfirmText="确定清空数据库（不包括指标库）？本操作不可恢复！">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Button_ClearQuotaLib" runat="server" Text="清空指标库" OnClick="Button_ClearQuotaLib_Click" ConfirmTitle="提示" ConfirmText="确定清空指标库？本操作不可恢复！">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Button_DeleteTempFiles" runat="server" Text="删除临时文件" OnClick="Button_DeleteTempFiles_Click" ConfirmTitle="提示" ConfirmText="确定删除临时文件？本操作不可恢复！">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:Label ID="Label1" runat="server" Label="Label" Text="警告：本页操作不可恢复，审用！">
            </x:Label>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
