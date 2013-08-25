<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartManagement.aspx.cs"
    Inherits="HRES.Pages.DataBaseManagement.DepartManagement" %>

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
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="VBox" BoxConfigChildMargin="0 0 5 0" AutoScroll="true">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="Form" Width="800px" ShowHeader="false"
                        ShowBorder="false" LabelWidth="110px">
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="TextBox_NewDepart" runat="server" Label="请输入新部门名称" Text="">
                                    </x:TextBox>
                                    <x:Button ID="Button_Add" runat="server" Text="新增" OnClick="Button_Add_Click">
                                    </x:Button>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                    <x:Grid ID="Grid1" Title="部门表" PageSize="20" ShowBorder="true" ShowHeader="true"
                        Height="500px" AllowPaging="true" runat="server" EnableCheckBoxSelect="false"
                        Width="730px" DataKeyNames="ID, Name" OnPageIndexChange="Grid1_PageIndexChange"
                        EnableRowNumber="True" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="ID" Hidden="true" />
                            <x:BoundField Width="200px" DataField="Name" DataFormatString="{0}" HeaderText="部门名称" />
                            <x:LinkButtonField HeaderText="操作" Width="150px" ConfirmText="确定删除？" ConfirmTarget="Top"
                                CommandName="Delete" Text="删除" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
