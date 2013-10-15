<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_MakeEvaluator.aspx.cs"
    Inherits="HRES.Pages.EvaluatorManagement.iframe_MakeEvaluator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .columnpanel
        {
            margin-right: 5px;
        }
        .rowpanel
        {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true"
            Title="考评人名单" AutoScroll="true" Layout="Anchor">
            <Items>
                <x:Toolbar ID="Toolbar1" runat="server" CssStyle="width:99.7%">
                    <Items>
                        <x:Label ID="Label1" runat="server" Label="Label" Text="审核意见：">
                        </x:Label>
                        <x:Label ID="Label_Comment" runat="server" Label="Label" Text="">
                        </x:Label>
                        <x:ToolbarFill ID="ToolbarFill1" runat="server">
                        </x:ToolbarFill>
                        <x:Button ID="Button_Submit" runat="server" Text="提交" OnClick="Button_Submit_Click"
                            ConfirmTitle="提示" ConfirmText="确定提交？">
                        </x:Button>
                        <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </x:ToolbarSeparator>
                        <x:Button ID="Button_Clear" runat="server" Text="清空" OnClick="Button_Clear_Click"
                            ConfirmTitle="提示" ConfirmText="确定清空？">
                        </x:Button>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:Button ID="Button_Close" runat="server" Text="关闭">
                        </x:Button>
                    </Items>
                </x:Toolbar>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                    Title="Panel2" AutoScroll="true" AnchorValue="100%" Layout="Column">
                    <Items>
                        <x:Grid ID="Grid2" runat="server" Title="已提交名单" ShowHeader="true"
                             Height="500px" EnableRowNumber="true" CssClass="columnpanel"
                            AutoPostBack="false" DataKeyNames="ID, Name, Relation" ColumnWidth="30%">
                            <Columns>
                                <x:BoundField Width="80px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                                <x:BoundField Width="80px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                                <x:TemplateField Width="80px" HeaderText="关系">
                                <ItemTemplate>
                                    <asp:Label ID="LabelRelation" runat="server" Text='<%# GetRelation(Eval("Relation")) %>'></asp:Label>
                                </ItemTemplate>
                            </x:TemplateField>
                            </Columns>
                        </x:Grid>
                        <x:Grid ID="Grid1" runat="server" Title="备选考评人名单" ShowHeader="true" AllowPaging="true"
                            PageSize="20" Height="500px" OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="true"
                            AutoPostBack="false" DataKeyNames="ID, Name, Sex, Company, Telephone, Relation"
                            EnableMultiSelect="true" ClearSelectedRowsAfterPaging="false" EnableCheckBoxSelect="true"
                            CheckBoxSelectOnly="true" ColumnWidth="70%">
                            <Columns>
                                <x:BoundField Width="80px" DataField="ID" DataFormatString="{0}" HeaderText="用户名" />
                                <x:BoundField Width="80px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                                <x:BoundField Width="40px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                                <x:BoundField Width="100px" DataField="Company" DataFormatString="{0}" HeaderText="用工单位" />
                                <x:BoundField Width="100px" DataField="Telephone" DataFormatString="{0}" HeaderText="联系电话" />
                                <x:TemplateField Width="185px" HeaderText="关系">
                                    <ItemTemplate>
                                        <asp:RadioButtonList runat="server" RepeatLayout="Flow" CssClass="gender" RepeatDirection="Horizontal"
                                            ID="RadioButtonList_Relation">
                                            <asp:ListItem Text="领导" Value="领导"></asp:ListItem>
                                            <asp:ListItem Text="同事" Value="同事"></asp:ListItem>
                                            <asp:ListItem Text="下属" Value="下属"></asp:ListItem>
                                            <asp:ListItem Text="服务对象" Value="服务对象" Selected="true"></asp:ListItem>
                                        </asp:RadioButtonList>
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
    </form>
</body>
</html>
