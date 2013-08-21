<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluate.aspx.cs" Inherits="HRES.Pages.EvaluationManagement.Evaluate" %>

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
            <x:Panel ID="Panel2" runat="server" BodyPadding="00px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" CssStyle="99.7%">
                        <Items>
                            <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" Width="800px">
                        <Items>
                            <x:Grid ID="Grid1" runat="server" Title="被考评人名单" AllowPaging="true" PageSize="20"
                                DataKeyNames="ID,Relation,Status" EnableRowNumber="true" Width="760px">
                                <Columns>
                                    <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="用户名"
                                        Hidden="true" />
                                    <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                                    <x:BoundField Width="80px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                                    <x:BoundField Width="200px" ExpandUnusedSpace="true" DataField="Depart" DataFormatString="{0}"
                                        HeaderText="工作单位" />
                                    <x:TemplateField Width="80px" HeaderText="关系">
                                        <ItemTemplate>
                                            <asp:Label ID="Relation" runat="server" Text='<%# GetRelation(Eval("Relation")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </x:TemplateField>
                                    <x:TemplateField Width="80px" HeaderText="状态">
                                        <ItemTemplate>
                                            <asp:Label ID="Status" runat="server" Text='<%# GetEvaluationStatus(Eval("Status")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </x:TemplateField>
                                    <x:WindowField TextAlign="Center" Width="80px" WindowID="Window1" Text="开始考评"
                                Title="考评" IFrameUrl="iframe_Evaluate.aspx" DataIFrameUrlFields="ID,Relation"
                                DataIFrameUrlFormatString="iframe_Evaluate.aspx?id={0}&relation={1}" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" runat="server" BodyPadding="5px" Height="550px" CssStyle="width:95%" IsModal="true"
        Popup="false" Title="考评" EnableConfirmOnClose="true" EnableIFrame="true" >
    </x:Window>
    </form>
</body>
</html>
