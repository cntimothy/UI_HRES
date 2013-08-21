<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="HRES.Pages.AccountManagement.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel">
        <Items>
            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                ShowBorder="false" ShowHeader="false" CssStyle="width:60%">
                <Items>
                    <x:Label ID="Label1" runat="server" Label="" Text="注意：密码必须为6位！">
                    </x:Label>
                    <x:TextBox ID="TextBox1" runat="server" Label="旧密码" Text="" ShowRedStar="true" Required="true"
                        TextMode="Password">
                    </x:TextBox>
                    <x:TextBox ID="TextBox2" runat="server" Label="新密码" Text="" ShowRedStar="true" Required="true"
                        TextMode="Password">
                    </x:TextBox>
                    <x:TextBox ID="TextBox3" runat="server" Label="确认新密码" Text="" ShowRedStar="true"
                        Required="true" TextMode="Password" CompareControl="TextBox2" CompareOperator="Equal"
                        CompareMessage="请输入相同密码">
                    </x:TextBox>
                    <x:Button ID="Button_ChangePassword" runat="server" Text="修改密码" OnClick="Button_ChangePassword_Click"
                        ValidateForms="SimpleForm1" ConfirmTitle="提示！" ConfirmText="确定修改密码？">
                    </x:Button>
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
