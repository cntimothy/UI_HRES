<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_CheckEvaluator.aspx.cs"
    Inherits="HRES.Pages.EvaluatorManagement.iframe_CheckEvaluator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true"
        Title="考评人名单" Layout="Fit" AutoScroll="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel2" AutoScroll="true" AutoHeight="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                        <Items>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Set" runat="server" Text="设置" OnClick="Button_Set_Click" ConfirmTitle="提示"
                                ConfirmText="确定设置？">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Reject" runat="server" Text="退回">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Clear" runat="server" Text="清空" OnClick="Button_Clear_Click"
                                ConfirmTitle="提示" ConfirmText="确定清空？">
                            </x:Button>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Label ID="Label1" runat="server" Label="Label" Text="审核意见：">
                            </x:Label>
                            <x:Label ID="Label2" runat="server" Label="Label" Text="">
                            </x:Label>
                        </Items>
                    </x:Toolbar>
                    <x:Grid ID="Grid1" runat="server" Title="Grid" ShowHeader="false" AllowPaging="true"
                        PageSize="20" Height="500px" OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="true"
                        AutoPostBack="false" DataKeyNames="ID, Name, Sex, Company, Telephone, Relation"
                        EnableMultiSelect="true" ClearSelectedRowsAfterPaging="false" EnableCheckBoxSelect="true"
                        CheckBoxSelectOnly="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                            <x:BoundField Width="100px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                            <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="工作单位" />
                            <x:BoundField Width="150px" DataField="Telephone" DataFormatString="{0}" HeaderText="联系电话" />
                            <x:TemplateField Width="150px" HeaderText="关系">
                                <ItemTemplate>
                                    <asp:Label ID="Relation" runat="server" Text='<%# GetRelation(Eval("Relation")) %>'></asp:Label>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hfSelectedIDS" runat="server">
    </x:HiddenField>
    <x:Window ID="Window1" runat="server" BodyPadding="5px" Height="150px" IsModal="true"
        IFrameUrl="about:blank" EnableMaximize="false" EnableIFrame="true" Popup="false"
        Title="审核意见" Width="400px">
    </x:Window>
    </form>
</body>
</html>
