<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeSecond.aspx.cs" Inherits="HRES.Pages.SecondManagement.MakeSecond" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" AutoScroll="true">
        <Items>
            <x:Toolbar ID="Toolbar1" Position="Top" CssClass="mytoolbar" runat="server">
                <Items>
                    <x:FileUpload ID="ExcelFile" Label="Label" runat="server" ButtonText="选择Excel文件"
                        ButtonOnly="true" AutoPostBack="true" OnFileSelected="FileSelected">
                    </x:FileUpload>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Label ID="Label2" Text="您选择的文件：" Label="" runat="server">
                    </x:Label>
                    <x:Label ID="FilePath" Text="" Label="" runat="server">
                    </x:Label>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="开始上传" Enabled="false">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:Button ID="Button_DownloadTemplate" runat="server" Text="下载模板" OnClick="Button_DownloadTemplate_Click"
                        EnableAjax="false">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                Title="Pane2" Width="560px">
                <Items>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                        ShowHeader="false" ShowBorder="false" Width="520px">
                        <Items>
                            <x:DropDownList runat="server" ID="DropDownList_Depart" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Depart_SelectedChanged"
                                Label="请选择部门">
                            </x:DropDownList>
                        </Items>
                    </x:SimpleForm>
                    <x:Grid ID="Grid1" Title="名单" PageSize="20" ShowBorder="true" ShowHeader="true" Height="500px"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="false" Width="550" DataKeyNames="ID, Name, Depart"
                        OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="True" OnRowCommand="Grid1_RowCommand" BodyPadding="0px">
                        <Columns>
                            <x:BoundField Width="120px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="140px" DataField="Depart" DataFormatString="{0}" HeaderText="部门" />
                            <x:LinkButtonField HeaderText="&nbsp;" Width="100px" ConfirmText="确定删除？" ConfirmTarget="Top"
                                CommandName="Delete" Text="删除" />
                            <x:LinkButtonField HeaderText="&nbsp;" Width="100px" ConfirmText="确定重置密码？" ConfirmTarget="Top"
                                CommandName="Reset" Text="重置密码" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
