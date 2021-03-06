﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartEvaluation.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.StartEvaluation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel1" AutoScroll="true">
        <Items>
            <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                <Items>
                    <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </x:ToolbarSeparator>
                    <x:DropDownList ID="DropDownList_EvaluationStatus" runat="server" Label="Label" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_EvaluationStatus_SelectedChanged">
                        <x:ListItem EnableSelect="true" Text="所有状态" Value="-1" />
                        <x:ListItem EnableSelect="true" Text="未初始化" Value="0" />
                        <x:ListItem EnableSelect="true" Text="未开始" Value="1" />
                        <x:ListItem EnableSelect="true" Text="已开始" Value="2" />
                        <x:ListItem EnableSelect="true" Text="已结束" Value="3" />
                    </x:DropDownList>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="Button_Start" runat="server" Text="开始考评" OnClick="Button_Start_Click"
                        ConfirmTitle="提示" ConfirmText="确定开始考评？">
                    </x:Button>
                </Items>
            </x:Toolbar>
            <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="SimpleForm"
                ShowBorder="false" ShowHeader="false" CssStyle="width:60%">
                <Items>
                    <x:DropDownList ID="DropDownList1" runat="server" Label="请选择部门" OnSelectedIndexChanged="DropDownList1_SelectedChanged"
                        AutoPostBack="true">
                        <x:ListItem Text="所有部门" Value="所有部门" />
                    </x:DropDownList>
                </Items>
            </x:SimpleForm>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                Title="" Width="1050px" Layout="HBox" BoxConfigChildMargin="0, 5, 0, 0">
                <Items>
                    <x:Grid ID="Grid1" runat="server" Title="被考评人名单" Width="730px" PageSize="20" ShowBorder="true"
                        ShowHeader="true" Height="500px" AllowPaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                        EnableRowClickEvent="true" EnableRowClick="true" OnRowClick="Grid1_RowClick"
                        EnableRowNumber="True" AutoPostBack="true" DataKeyNames="ID, Date, Name, Sex, Depart, Job, IDNo, Birthday, Fund, Character, Company, StartTime, StopTime, Status, Comment, Status">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Date" DataFormatString="{0}" HeaderText="入职时间"
                                Hidden="true" />
                            <x:BoundField Width="50px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="40px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="80px" DataField="Depart" DataFormatString="{0}" HeaderText="用工单位" />
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
                            <x:BoundField Width="100px" DataField="Summary" DataFormatString="{0}" HeaderText="考评完成情况" />
                            <x:TemplateField Width="100px" HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="Status" runat="server" Text='<%# GetEvaluationStatusForEvaluated(Eval("Status")) %>'></asp:Label>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="详细信息" Width="300px">
                        <Items>
                            <x:Label runat="server" ID="LabID" Label="用户名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabDate" Label="入职时间" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabName" Label="姓名" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabSex" Label="性别" Text="">
                            </x:Label>
                            <x:Label runat="server" ID="LabDepart" Label="用工单位" Text="">
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
