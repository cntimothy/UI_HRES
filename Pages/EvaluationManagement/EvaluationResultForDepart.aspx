<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluationResultForDepart.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.EvaluationResultForDepart" %>

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
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                        <Items>
                            <x:DropDownList ID="DropDownList_Depart" runat="server" Label="部门">
                                <x:ListItem EnableSelect="false" Text="请选择部门" Value="-1" />
                            </x:DropDownList>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:DropDownList ID="DropDownList_Year" runat="server" Label="年份">
                                <x:ListItem EnableSelect="false" Text="请选择年份" Value="-1" />
                            </x:DropDownList>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Search" runat="server" Text="查询" OnClick="Button_Search_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Export" runat="server" Text="导出" OnClick="Button_Export_Click" EnableAjax="false" Enabled="false">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="Form" ShowBorder="false"
                        ShowHeader="false">
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:Label ID="Label_Period" runat="server" Label="考核时间段" Text="">
                                    </x:Label>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                    <x:Grid ID="Grid1" runat="server" Title="Grid" EnableRowNumber="true" AutoHeight="true" Width="800px">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="150px" DataField="Score" DataFormatString="{0}" HeaderText="考核得分" />
                            <x:BoundField Width="100px" DataField="Result" DataFormatString="{0}" HeaderText="考核结果" />
                            <x:BoundField Width="100px" DataField="EvaluatorNum" DataFormatString="{0}" HeaderText="考核人数" />
                            <x:BoundField Width="250px" DataField="Comment" DataFormatString="{0}" HeaderText="备注" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
