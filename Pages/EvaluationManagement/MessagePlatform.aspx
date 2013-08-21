<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagePlatform.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.MessagePlatform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="考评人名单" Layout="Fit">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel2" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                        <Items>
                            <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Send" runat="server" Text="发送" OnClick="Button_Send_Click" ConfirmTitle="提示"
                                ConfirmText="确定发送？">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" Title="SimpleForm"
                        ShowBorder="false" ShowHeader="false" Width="600px">
                        <Items>
                            <x:DropDownList ID="DropDownList1" runat="server" Label="请选择部门" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownList1_SelectedChanged">
                                <x:ListItem Text="所有部门" Value="所有部门" />
                            </x:DropDownList>
                        </Items>
                    </x:SimpleForm>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                        Title="Panel3" Layout="HBox" BoxConfigPadding="5 5 5 0" Width="1100">
                        <Items>
                            <x:Grid ID="Grid1" runat="server" Title="Grid" ShowHeader="false" AllowPaging="true"
                                PageSize="20" Height="500px" OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="true"
                                AutoPostBack="false" DataKeyNames="ID, Name, Sex, Company, Telephone" EnableMultiSelect="true"
                                ClearSelectedRowsAfterPaging="false" EnableCheckBoxSelect="true" CheckBoxSelectOnly="true"
                                Width="680px">
                                <Columns>
                                    <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                                    <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                                    <x:BoundField Width="100px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                                    <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Company" DataFormatString="{0}"
                                        HeaderText="工作单位" />
                                    <x:BoundField Width="100px" DataField="Telephone" DataFormatString="{0}" HeaderText="联系电话" />
                                </Columns>
                            </x:Grid>
                            <x:Panel ID="Panel4" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                                Title="Panel3" >
                                <Items>
                                    <x:Label ID="Label2" runat="server" Label="Label" Text="请输入信息内容">
                                    </x:Label>
                                    <x:TextArea ID="TextArea_Message" runat="server" Height="100px" Label="Label" Text=""
                                        ShowRedStar="true" Required="true" Width="350px" EmptyText="最多70字">
                                    </x:TextArea>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hfSelectedIDS" runat="server">
    </x:HiddenField>
    </form>
</body>
</html>
