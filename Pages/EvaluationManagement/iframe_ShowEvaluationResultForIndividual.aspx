<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_ShowEvaluationResultForIndividual.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.iframe_ShowEvaluationResultForIndividual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Label ID="Label1" runat="server" Label="Label" Text="请选择年份：">
                            </x:Label>
                            <x:DropDownList ID="DropDownList_Year" runat="server" Label="Label" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownList_Year_SelectedChanged">
                            </x:DropDownList>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Search" runat="server" Text="查询">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Export" runat="server" Text="导出" OnClick="Button_Export_Click" EnableAjax="false">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="Form" ShowBorder="false"
                        ShowHeader="false">
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:Label ID="Label_EvaluatedName" runat="server" Label="被考核人姓名" Text="">
                                    </x:Label>
                                    <x:Label ID="Label_PostName" runat="server" Label="岗位名称" Text="">
                                    </x:Label>
                                    <x:Label ID="Label_LaborDep" runat="server" Label="用工部门" Text="">
                                    </x:Label>
                                    <x:Label ID="Label_LaborUnit" runat="server" Label="用工单位" Text="">
                                    </x:Label>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:Label ID="Label_Period" runat="server" Label="考核时间段" Text="">
                                    </x:Label>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                    <x:Grid ID="Grid1" runat="server" Title="考核汇总表">
                        <Columns>
                        </Columns>
                    </x:Grid>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                        ShowBorder="false" ShowHeader="false">
                        <Items>
                            <x:RadioButtonList ID="RadioButtonList_EvaluationLevel" runat="server" ColumnVertical="false" Enabled="false" Label="考评结果">
                                <x:RadioItem Text="优秀（9~10）" Value="0" />
                                <x:RadioItem Text="良好（7~8）" Value="1" />
                                <x:RadioItem Text="合格（4~6）" Value="2" />
                                <x:RadioItem Text="不合格（0~3）" Value="3" />
                            </x:RadioButtonList>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
