<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotaManagement.aspx.cs"
    Inherits="HRES.Pages.QuotaManagement.QuotaManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .x-grid3-row .x-grid3-cell-inner
        {
            white-space: normal;
            padding: 10px 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" AutoScroll="true">
        <Items>
            <x:Grid ID="Grid1" Title="指标库" PageSize="20" ShowBorder="true" ShowHeader="true"
                AllowPaging="true" runat="server" Width="1100" DataKeyNames="Level1,Level2,Quota1,Quota2,Quota3,Quota4"
                OnPageIndexChange="Grid1_PageIndexChange" EnableRowNumber="True" OnRowCommand="Grid1_RowCommand">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_New" Text="新增数据" runat="server">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField Width="100px" DataField="Level1" HeaderText="一级标题" />
                    <x:BoundField Width="100px" DataField="Level2" HeaderText="二级标题" />
                    <x:BoundField Width="200px" DataField="Quota1" HeaderText="优" />
                    <x:BoundField Width="200px" DataField="Quota2" HeaderText="良" />
                    <x:BoundField Width="200px" DataField="Quota3" HeaderText="中" />
                    <x:BoundField Width="200px" DataField="Quota4" HeaderText="差" />
                    <x:LinkButtonField HeaderText="操作;" ExpandUnusedSpace="true" Width="100px" ConfirmText="确定删除？"
                        ConfirmTarget="Top" CommandName="Delete" Text="删除" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window_NewQuota" runat="server" BodyPadding="5px" IsModal="true" IFrameUrl="about:blank"
        EnableMaximize="false" EnableIFrame="true" Popup="false" Title="新指标" CssStyle="width:80%"
        Height="400px" OnClose="Window_NewQuota_Close">
    </x:Window>
    </form>
</body>
</html>
