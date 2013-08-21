<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_Evaluate.aspx.cs"
    Inherits="HRES.Pages.EvaluationManagement.iframe_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
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
        Title="Panel" Layout="Fit">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Submit" runat="server" Text="提交" OnClick="Button_Submit_Click"
                                ConfirmTitle="提示" ConfirmText="确认提交？提交后不可修改">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="Form" ShowBorder="false"
                        ShowHeader="false">
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:Label runat="server" ID="Label_EvaluatedName" Label="被考核人姓名" Text="">
                                    </x:Label>
                                    <x:Label runat="server" ID="Label_PostName" Label="岗位名称" Text="">
                                    </x:Label>
                                    <x:Label runat="server" ID="Label_LaborDep" Label="用工部门" Text="">
                                    </x:Label>
                                    <x:Label runat="server" ID="Label_LaborUnit" Label="用工单位" Text="">
                                    </x:Label>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:Label runat="server" ID="Label_Period" Label="考核时间段" Text="">
                                    </x:Label>
                                    <x:RadioButtonList runat="server" ID="RadioButtonList_Relation" Enabled="false" ColumnVertical="false"
                                        Label="关系">
                                        <x:RadioItem Text="领导" Value="0" />
                                        <x:RadioItem Text="同事" Value="1" />
                                        <x:RadioItem Text="下属" Value="2" />
                                        <x:RadioItem Text="服务对象" Value="3" />
                                    </x:RadioButtonList>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FirmRow3" runat="server">
                                <Items>
                                    <x:Label ID="Label_EvaluateDate" runat="server" Label="考核日期" Text="">
                                    </x:Label>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                    <x:Grid ID="Grid1" runat="server" Title="关键岗位职责指标（优：91～100良：71～90中：41～70差：0～40）"
                        ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="800px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score1" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid2" runat="server" Title="关键岗位胜任能力指标" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="200px" DataField="Quota1" DataFormatString="{0}" HeaderText="优(91~100)" />
                            <x:BoundField Width="200px" DataField="Quota2" DataFormatString="{0}" HeaderText="良(71~90)" />
                            <x:BoundField Width="200px" DataField="Quota3" DataFormatString="{0}" HeaderText="中(41~70)" />
                            <x:BoundField Width="200px" DataField="Quota4" DataFormatString="{0}" HeaderText="差(0~40)" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score2" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid3" runat="server" Title="关键工作态度指标" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="200px" DataField="Quota1" DataFormatString="{0}" HeaderText="优(91~100)" />
                            <x:BoundField Width="200px" DataField="Quota2" DataFormatString="{0}" HeaderText="良(71~90)" />
                            <x:BoundField Width="200px" DataField="Quota3" DataFormatString="{0}" HeaderText="中(41~70)" />
                            <x:BoundField Width="200px" DataField="Quota4" DataFormatString="{0}" HeaderText="差(0~40)" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score3" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid4" runat="server" Title="岗位职责指标（优：91～100良：71～90中：41～70差：0～40）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="800px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score4" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid5" runat="server" Title="岗位胜任能力指标" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="200px" DataField="Quota1" DataFormatString="{0}" HeaderText="优(91~100)" />
                            <x:BoundField Width="200px" DataField="Quota2" DataFormatString="{0}" HeaderText="良(71~90)" />
                            <x:BoundField Width="200px" DataField="Quota3" DataFormatString="{0}" HeaderText="中(41~70)" />
                            <x:BoundField Width="200px" DataField="Quota4" DataFormatString="{0}" HeaderText="差(0~40)" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score5" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid6" runat="server" Title="工作态度指标" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="200px" DataField="Quota1" DataFormatString="{0}" HeaderText="优(91~100)" />
                            <x:BoundField Width="200px" DataField="Quota2" DataFormatString="{0}" HeaderText="良(71~90)" />
                            <x:BoundField Width="200px" DataField="Quota3" DataFormatString="{0}" HeaderText="中(41~70)" />
                            <x:BoundField Width="200px" DataField="Quota4" DataFormatString="{0}" HeaderText="差(0~40)" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score6" runat="server" Width="80px" Text=""></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid7" runat="server" Title="否决指标" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Title" DataFormatString="{0}"
                                HeaderText="标题" />
                            <x:BoundField Width="800px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField Width="60px" HeaderText="得分">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" ID="DropDownList1">
                                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="-100" Value="-100"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
