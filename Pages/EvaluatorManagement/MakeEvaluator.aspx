﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeEvaluator.aspx.cs"
    Inherits="HRES.Pages.EvaluatorManagement.MakeEvaluator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .columnpanel
        {
            margin-right: 5px;
        }
        .rowpanel
        {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel1" AutoScroll="true" Layout="Anchor">
        <Items>
            <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                <Items>
                    <x:Button ID="Refresh" runat="server" Text="刷新" OnClick="Refresh_Click">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:DropDownList ID="DropDownList_DocStatus" runat="server" Label="" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_DocStatus_SelectedChanged">
                        <x:ListItem EnableSelect="true" Selected="true" Text="所有状态" Value="-1" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="未制作" Value="0" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="已保存" Value="1" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="已提交" Value="2" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="已退回" Value="3" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="已修改" Value="4" />
                        <x:ListItem EnableSelect="true" Selected="true" Text="已通过" Value="5" />
                    </x:DropDownList>
                </Items>
            </x:Toolbar>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                Title="" Width="100%" Layout="Column" AnchorValue="100%">
                <Items>
                    <x:Grid ID="Grid1" runat="server" Title="被考评人名单" Width="730px" PageSize="20" ShowBorder="true"
                        ShowHeader="true" Height="500px" AllowPaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                        EnableRowClickEvent="true" EnableRowClick="true" OnRowClick="Grid1_RowClick" 
                        EnableRowNumber="True" AutoPostBack="true" DataKeyNames="ID, Name, Sex, Company, Depart, LaborDepart, PostName, PostType, Fund, Character, StartTime, StopTime, Status, Comment"
                        AllowSorting="true" SortColumnIndex="12" SortDirection="DESC" OnSort="Grid1_Sort"  CssClass="columnpanel"  OnPreRowDataBound="Grid1_PreRowDataBound" >
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="40px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="用人单位"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Depart" DataFormatString="{0}" HeaderText="用工单位" />
                            <x:BoundField Width="100px" DataField="LaborDepart" DataFormatString="{0}" HeaderText="用工部门"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="PostName" DataFormatString="{0}" HeaderText="岗位名称"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="PostType" DataFormatString="{0}" HeaderText="岗位类别"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Fund" DataFormatString="{0}" HeaderText="经费来源"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="Character" DataFormatString="{0}" HeaderText="派遣性质"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StartTime" DataFormatString="{0}" HeaderText="考评开始时间"
                                Hidden="true" />
                            <x:BoundField Width="100px" DataField="StopTime" DataFormatString="{0}" HeaderText="考评结束时间"
                                Hidden="true" />
                            <x:TemplateField SortField="Status" Width="50px" HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="Status" runat="server" Text='<%# GetDocStatus(Eval("Status")) %>'></asp:Label>
                                </ItemTemplate>
                            </x:TemplateField>
                            <x:BoundField ExpandUnusedSpace="true" Width="200px" DataField="Comment" DataFormatString="{0}"
                                HeaderText="审核意见" />
                            <x:WindowField TextAlign="Center" Width="50px" WindowID="Window_MakeEvaluator" Text="制作"
                                ToolTip="制作考评人名单" Title="制作" IFrameUrl="iframe_MakeEvaluator.aspx" DataIFrameUrlFields="ID,Name,Status,Comment"
                                DataIFrameUrlFormatString="iframe_MakeEvaluator.aspx?id={0}&name={1}&status={2}&Comment={3}" />
                        </Columns>
                    </x:Grid>
                    <x:Panel ID="Panel4" Title="面板1" EnableBackgroundColor="false" ColumnWidth="100%" runat="server"
                        BodyPadding="0px" ShowBorder="false" ShowHeader="false" >
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="详细信息" Width="300px"
                                LabelWidth="100px" EnableCollapse="true">
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
        </Items>
    </x:Panel>
    <x:Window ID="Window_MakeEvaluator" Title="弹出窗体" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" EnableMaximize="true" Target="Top" EnableResize="true"
        runat="server" IsModal="true" CssStyle="width:80%" EnableConfirmOnClose="true"
        Height="610px" EnableClose="false" AutoHeight="true" OnClose="WIndow_MakeEvaluator_Close">
    </x:Window>
    </form>
</body>
</html>
