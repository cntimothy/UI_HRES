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
                    </x:DropDownList>
                </Items>
            </x:SimpleForm>
            <x:Panel ID="Panel3" runat="server" ShowBorder="false" Layout="HBox" BoxConfigChildMargin="0 5 5 5"
                ShowHeader="false" Width="1050px">
                <Items>
                    <x:Grid ID="Grid1" Title="名单" PageSize="20" ShowBorder="true" ShowHeader="true" Height="500px"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="false" Width="730px"
                        DataKeyNames="ID, Date, Name, Sex, Depart, Job, IDNo, Birthday, Fund, Character, Company, StartTime, StopTime"
                        OnPageIndexChange="Grid1_PageIndexChange" EnableRowSelect="true" OnRowSelect="GridRowSelect"
                        EnableRowNumber="True" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Date" DataFormatString="{0}" HeaderText="入职时间"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="100px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="100px" DataField="Depart" DataFormatString="{0}" HeaderText="工作单位" />
                            <x:BoundField Width="100px" DataField="Job" DataFormatString="{0}" HeaderText="岗位（职务）" />
                            <x:BoundField Width="100px" DataField="IDNo" DataFormatString="{0}" HeaderText="身份证号"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Birthday" DataFormatString="{0}" HeaderText="出生年月"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Fund" DataFormatString="{0}" HeaderText="经费来源"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Character" DataFormatString="{0}" HeaderText="派遣性质"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="派遣公司"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StartTime" DataFormatString="{0}" HeaderText="考评开始时间"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StopTime" DataFormatString="{0}" HeaderText="考评结束时间"
                                Hidden="true" />
                            <x:LinkButtonField HeaderText="&nbsp;" Width="100px" ConfirmText="确定删除？" ConfirmTarget="Top"
                                CommandName="Delete" Text="删除" />
                        </Columns>
                    </x:Grid>
                    <x:SimpleForm ID="SimpleForm1" runat="server" Width="300px" LabelAlign="Left" LabelWidth="60px"
                        Title="详细信息" BodyPadding="5px 10px" BoxMargin="0">
                        <Items>
                            <x:Label runat="server" ID="LabID" Label="用户名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabDate" Label="入职时间" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabName" Label="姓名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabSex" Label="性别" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabDepart" Label="工作单位" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabJob" Label="岗位（职务）" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabIDNo" Label="身份证号" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabBirthday" Label="出生年月" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabFund" Label="经费来源" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabCharacter" Label="派遣性质" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabCompany" Label="派遣公司" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabStartTime" Label="考评开始时间" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabStopTime" Label="考评结束时间" Text="">
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
