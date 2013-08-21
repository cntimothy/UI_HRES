<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluationResultForIndividual.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.EvaluationResultForIndividual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit" AutoScroll="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true" Layout="VBox" BoxConfigChildMargin="0 0 5 0">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                        <Items>
                            <x:Label ID="Label1" runat="server" Label="Label" Text="请选择查看范围">
                            </x:Label>
                            <x:DropDownList ID="DropDownList1" runat="server" Label="Label" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownList1_SelectedChanged">
                                <Items>
                                    <x:ListItem Selected="true" Text="本年度" Value="0" />
                                    <x:ListItem Selected="false" Text="所有年度" Value="1" />
                                </Items>
                            </x:DropDownList>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" ShowBorder="false" Layout="HBox" BoxConfigChildMargin="0 5 5 5"
                        ShowHeader="false" Width="1050px">
                        <Items>
                            <x:Grid ID="Grid1" Title="名单" PageSize="20" ShowBorder="true" ShowHeader="true" Height="500px"
                                AllowPaging="true" runat="server" EnableCheckBoxSelect="false" Width="730px"
                                DataKeyNames="ID, Date, Name, Sex, Depart, Job, IDNo, Birthday, Fund, Character, Company, Status"
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
                                    <x:BoundField Width="100px" DataField="Status" DataFormatString="{0}" HeaderText="考核状态" />
                                    <x:WindowField TextAlign="Center" Width="80px" WindowID="Window1" Text="查看" ToolTip="查看考评结果"
                                        Title="操作" IFrameUrl="iframe_ShowEvaluationResultForIndividual.aspx" DataIFrameUrlFields="ID,Name,Status"
                                        DataIFrameUrlFormatString="iframe_ShowEvaluationResultForIndividual.aspx?id={0}&name={1}&status={2}" />
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
                                    <x:Label runat="server" ID="LabStatus" Label="考核状态" Text="">
                                    </x:Label>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" Title="弹出窗体" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" IsModal="true"
        CssStyle="width:80%" Height="560px" EnableClose="true" AutoHeight="true">
    </x:Window>
    </form>
</body>
</html>
