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
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                        ShowHeader="false" LabelWidth="120px">
                        <Items>
                            <x:TextBox ID="TextBox_NewDepart" runat="server" Label="请输入新部门名称" Text="" >
                            </x:TextBox>
                            <x:Button ID="Button_Add" runat="server" Text="新增" OnClick="Button_Add_Click">
                            </x:Button>
                            <x:Label ID="Label_Departs" runat="server" Label="现有部门" Text="" >
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
