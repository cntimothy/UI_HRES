<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_NewQuota.aspx.cs"
    Inherits="HRES.Pages.QuotaManagement.iframe_NewQuota" %>

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
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" Title="SimpleForm" ShowHeader="false"
                AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Save" runat="server" Text="保存" OnClick="Button_Save_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                        ShowBorder="false" ShowHeader="false">
                        <Items>
                            <x:TextBox ID="TextBox_Level1" runat="server" Label="一级标题" Text="" ShowRedStar="true" Required="true">
                            </x:TextBox>
                            <x:TextBox ID="TextBox_Level2" runat="server" Label="二级标题" Text="" ShowRedStar="true" Required="true">
                            </x:TextBox>
                            <x:TextArea ID="TextArea_Quota1" runat="server" Height="50px" Label="优" Text="" ShowRedStar="true" Required="true">
                            </x:TextArea>
                            <x:TextArea ID="TextArea_Quota2" runat="server" Height="50px" Label="良" Text="" ShowRedStar="true" Required="true"> 
                            </x:TextArea>
                            <x:TextArea ID="TextArea_Quota3" runat="server" Height="50px" Label="中" Text="" ShowRedStar="true" Required="true">
                            </x:TextArea>
                            <x:TextArea ID="TextArea_Quota4" runat="server" Height="50px" Label="差" Text="" ShowRedStar="true" Required="true">
                            </x:TextArea>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
