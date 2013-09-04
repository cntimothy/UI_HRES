<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeEvaluated.aspx.cs"
    Inherits="HRES.Pages.EvaluatedManagement.MakeEvaluated" %>

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
            <x:Toolbar ID="Toolbar1" Position="Top" CssClass="mytoolbar" runat="server" CssStyle="99.7%">
                <Items>
                    <x:FileUpload ID="FileUpload_ExcelFile" Label="Label" runat="server" ButtonText="选择Excel文件"
                        ButtonOnly="true" AutoPostBack="true" OnFileSelected="FileUpload_ExcelFile_FileSelected">
                    </x:FileUpload>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Label ID="Label1" Text="您选择的文件：" Label="" runat="server">
                    </x:Label>
                    <x:Label ID="Label_FileName" Text="" Label="" runat="server">
                    </x:Label>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Button_Submit" runat="server" OnClick="Button_Submit_Click" Text="开始上传"
                        Enabled="false">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="DeleteAll" runat="server" OnClick="DeleteAll_Click" Text="删除所有" Enabled="true"
                        ConfirmTitle="提示" ConfirmText="确认删除所有被考评人？">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:Button ID="Button_DownloadTemplate" runat="server" Text="下载模板" OnClick="Button_DownloadTemplate_Click"
                        EnableAjax="false">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="SimpleForm"
                ShowHeader="false" ShowBorder="false" Width="520px">
                <Items>
                    <x:DropDownList runat="server" ID="DropDownList_Depart" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Depart_SelectedChanged"
                        Label="请选择部门">
                        <x:ListItem Selected="true" EnableSelect="true" Text="所有部门" Value="0" />
                    </x:DropDownList>
                </Items>
            </x:SimpleForm>
            <x:Panel ID="Panel3" runat="server" ShowBorder="false" Layout="HBox" BoxConfigChildMargin="0 5 5 5"
                ShowHeader="false" Width="1050px">
                <Items>
                    <x:Grid ID="Grid1" Title="名单" PageSize="20" ShowBorder="true" ShowHeader="true" Height="500px"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="false" Width="730px"
                        DataKeyNames="ID, Name, Sex, Company, Depart, LaborDepart, PostName, PostType, Fund, Character, StartTime, StopTime"
                        OnPageIndexChange="Grid1_PageIndexChange" EnableRowSelect="true" OnRowSelect="GridRowSelect"
                        EnableRowNumber="True" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="100px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="用人单位" Hidden="true"/>
                            <x:BoundField Width="100px" DataField="Depart" DataFormatString="{0}" HeaderText="用工单位" />
                            <x:BoundField Width="100px" DataField="LaborDepart" DataFormatString="{0}" HeaderText="用工部门" Hidden="true"/>
                            <x:BoundField Width="100px" DataField="PostName" DataFormatString="{0}" HeaderText="岗位名称" Hidden="true"/>
                            <x:BoundField Width="100px" DataField="PostType" DataFormatString="{0}" HeaderText="岗位类别" Hidden="true"/>
                            <x:BoundField Width="100px" DataField="Fund" DataFormatString="{0}" HeaderText="经费来源"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Character" DataFormatString="{0}" HeaderText="派遣性质"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StartTime" DataFormatString="{0}" HeaderText="考评开始时间"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StopTime" DataFormatString="{0}" HeaderText="考评结束时间"
                                Hidden="true" />
                            <x:LinkButtonField HeaderText="&nbsp;" Width="100px" ConfirmText="确定删除？" ConfirmTarget="Top"
                                CommandName="Delete" Text="删除" />
                        </Columns>
                    </x:Grid>
                    <x:SimpleForm ID="SimpleForm1" runat="server" Width="300px" LabelAlign="Left" LabelWidth="100px"
                        Title="详细信息" BodyPadding="5px 10px" BoxMargin="0">
                        <Items>
                            <x:Label runat="server" ID="Label_ID" Label="用户名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Name" Label="姓名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Sex" Label="性别" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Company" Label="用人单位" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Depart" Label="用工单位" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_LaborDepart" Label="用工部门" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_PostName" Label="岗位名称" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_PostType" Label="岗位类别" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Fund" Label="经费来源" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_Character" Label="派遣性质" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_StartTime" Label="考评开始时间" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="Label_StopTime" Label="考评结束时间" Text="">
                            </x:Label>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
