<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadSelectableEvaluator.aspx.cs"
    Inherits="HRES.Pages.EvaluatorManagement.UploadSelectableEvaluator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
        Title="Panel" AutoScroll="true">
        <Items>
            <x:Toolbar ID="Toolbar1" Position="Top" CssClass="mytoolbar" runat="server" CssStyle="width:99.7%">
                <Items>
                    <x:FileUpload ID="ExcelFile" Label="Label" runat="server" ButtonText="选择Excel文件"
                        ButtonOnly="true" AutoPostBack="true" OnFileSelected="FileSelected">
                    </x:FileUpload>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Label ID="Label1" Text="您选择的文件：" Label="" runat="server">
                    </x:Label>
                    <x:Label ID="FilePath" Text="" Label="" runat="server">
                    </x:Label>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="开始上传" Enabled="false">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="DeleteSelected" runat="server" OnClick="DeleteSelected_Click" Text="删除所选" Enabled="true"
                        ConfirmTitle="提示" ConfirmText="确认删除所选考评人？">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:Button ID="Button_DownloadTemplate" runat="server" Text="下载模板" OnClick="Button_DownloadTemplate_Click" EnableAjax="false">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:Panel ID="Panel3" runat="server" ShowBorder="false" Layout="HBox" BoxConfigChildMargin="5"
                ShowHeader="false" Width="700px">
                <Items>
                    <x:Grid ID="Grid1" Title="名单" PageSize="20" ShowBorder="true" ShowHeader="true" Height="500px"
                        AllowPaging="true" runat="server" Width="680px" DataKeyNames="ID, Date, Name, Sex, Company, Telephone"
                        EnableMultiSelect="true" CheckBoxSelectOnly="true" EnableCheckBoxSelect="true"
                        OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="True" OnRowCommand="Grid1_RowCommand" ClearSelectedRowsAfterPaging="false">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="80px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="工作单位" />
                            <x:BoundField Width="150px" DataField="Telephone" DataFormatString="{0}" HeaderText="联系电话" />
                            <x:LinkButtonField HeaderText="&nbsp;" Width="100px" ConfirmText="确定删除？" ConfirmTarget="Top"
                                CommandName="Delete" Text="删除" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hfSelectedIDS" runat="server"></x:HiddenField>
    </form>
</body>
</html>
