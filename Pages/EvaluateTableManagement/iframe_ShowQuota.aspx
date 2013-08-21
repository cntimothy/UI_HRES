<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_ShowQuota.aspx.cs"
    Inherits="HRES.Pages.EvaluateTableManagement.iframe_ShowQuota" %>

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
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
                Title="Panel" AutoScroll="true" Layout="VBox" BoxConfigChildMargin="0 0 0 0">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.3%">
                        <Items>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Submit" runat="server" Text="确定" OnClick="Button_Submit_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" CssStyle="width:100%">
                        <Items>
                            <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                                Title="Panel" Layout="HBox" BoxConfigChildMargin="0 5 5 5" BoxConfigPosition="Center">
                                <Items>
                                    <x:DropDownList ID="DropDownList1" runat="server" Label="Label" CssStyle="width:40%"
                                        OnSelectedIndexChanged="DropDownList1_SelectedChange" AutoPostBack="true">
                                        <x:ListItem Text="请选择" Value="请选择" EnableSelect="false" Selected="true"/>
                                    </x:DropDownList>
                                    <x:DropDownList ID="DropDownList2" runat="server" Label="Label" CssStyle="width:40%"
                                        OnSelectedIndexChanged="DropDownList2_SelectedChange" AutoPostBack="true">
                                        <x:ListItem Text="请选择" Value="请选择" EnableSelect="false" Selected="true" />
                                    </x:DropDownList>
                                </Items>
                            </x:Panel>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm" ShowHeader="false">
                                <Items>
                                    <x:TextArea ID="TextArea1" runat="server" Height="50px" Label="优" Text="" Enabled="false">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea2" runat="server" Height="50px" Label="良" Text="" Enabled="false">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea3" runat="server" Height="50px" Label="中" Text="" Enabled="false">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea4" runat="server" Height="50px" Label="差" Text="" Enabled="false">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
