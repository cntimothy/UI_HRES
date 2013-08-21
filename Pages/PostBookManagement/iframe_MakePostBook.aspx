<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_MakePostBook.aspx.cs"
    Inherits="HRES.Pages.PostBookManagement.iframe_MakePostBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="true"
        Layout="Fit" Title="岗位责任书" AutoScroll="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server" Position="top" CssStyle="width:100%">
                        <Items>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Save" runat="server" Text="保存" OnClick="Button_Save_Click" ConfirmText="确定保存？"
                                ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Submit" runat="server" Text="提交" OnClick="Button_Submit_Click"
                                ConfirmText="确定提交？" ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Clear" runat="server" Text="清空" OnClick="Button_Clear_Click"
                                ConfirmText="确定清空？" ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Pass" runat="server" Text="通过" OnClick="Button_Pass_Click" ConfirmText="确定通过？"
                                ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Reject" runat="server" Text="退回" >
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator11" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Export" runat="server" Text="导出" OnClick="Button_Export_Click" EnableAjax="false">
                            </x:Button>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Label ID="Label1" runat="server" Label="" Text="审核意见：">
                            </x:Label>
                            <x:Label ID="Label_Comment" runat="server" Label="审核意见" Text="">
                            </x:Label>
                        </Items>
                    </x:Toolbar>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="一、岗位概述" ShowBorder="false"
                        CssStyle="width:100%">
                        <Items>
                            <x:RadioButtonList ID="Radio_Employer" runat="server" ColumnNumber="1" Label="1.用人单位"
                                ColumnVertical="true">
                                <x:RadioItem Text="上海市东凌国际人才有限公司" Value="上海市东凌国际人才有限公司" Selected="true" />
                                <x:RadioItem Text="上海黄渡同济人力资源有限公司" Value="上海黄渡同济人力资源有限公司" />
                            </x:RadioButtonList>
                            <x:TextBox ID="TextBox_LaborUnit" runat="server" Label="2.用工单位" Text="" Width="300px">
                            </x:TextBox>
                            <x:TextBox ID="TextBox_LaborDepart" runat="server" Label="3.用工部门" Text="" Width="300px">
                            </x:TextBox>
                            <x:TextBox ID="TextBox_PostName" runat="server" Label="4.岗位名称" Text="" Width="300px">
                            </x:TextBox>
                            <x:RadioButtonList ID="Radio_PostType" runat="server" ColumnVertical="false" Label="5.岗位类别"
                                Width="300px">
                                <x:RadioItem Text="管理" Value="管理" Selected="true" />
                                <x:RadioItem Text="教辅" Value="教辅" />
                                <x:RadioItem Text="思政" Value="思政" />
                                <x:RadioItem Text="教师" Value="教师" />
                                <x:RadioItem Text="工勤" Value="工勤" />
                            </x:RadioButtonList>
                        </Items>
                    </x:SimpleForm>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                        CssStyle="width:100%" Title="二、岗位职责" BoxConfigChildMargin="5">
                        <Items>
                            <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="（一）任职条件" CssStyle="width:100%"
                                ShowBorder="true">
                                <Items>
                                    <x:TextArea ID="TextArea_EduBg" runat="server" Label="1.学历背景" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Certificate" runat="server" Label="2.培训及资历" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Experience" runat="server" Label="3.工作经验" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Skill" runat="server" Label="4.基本技能和素质" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Personality" runat="server" Label="5.个性特征" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_PhyCond" runat="server" Label="6.体质条件" Text="" CssStyle="width:100%"
                                        AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:Panel ID="Panel4" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                Title="（二）工作内容、工作要求">
                                <Items>
                                    <x:Panel ID="Panel5" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                        CssStyle="width:100%" Title="1.岗位概述">
                                        <Items>
                                            <x:TextArea ID="TextArea_WorkOutline" runat="server" Label="" Text="" CssStyle="width:97%"
                                                AutoGrowHeight="true">
                                            </x:TextArea>
                                        </Items>
                                    </x:Panel>
                                    <x:Panel ID="Panel6" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true"
                                        CssStyle="width:100%" Title="2.工作内容及工作要求(至少6项！！)">
                                        <Items>
                                            <x:SimpleForm ID="SimpleForm_WCR1" runat="server" BodyPadding="5px" Title="1)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR1_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR1_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR1_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR1_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR2" runat="server" BodyPadding="5px" Title="2)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR2_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR2_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR2_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR2_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR3" runat="server" BodyPadding="5px" Title="3)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR3_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR3_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR3_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR3_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR4" runat="server" BodyPadding="5px" Title="4)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR4_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR4_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR4_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR4_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR5" runat="server" BodyPadding="5px" Title="5)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR5_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR5_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR5_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR5_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR6" runat="server" BodyPadding="5px" Title="6)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR6_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR6_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR6_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR6_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR7" runat="server" BodyPadding="5px" Title="7)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR7_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR7_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR7_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR7_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR8" runat="server" BodyPadding="5px" Title="8)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR8_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR8_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR8_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR8_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR9" runat="server" BodyPadding="5px" Title="9)" ShowBorder="true"
                                                ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR9_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR9_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR9_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR9_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                            <x:SimpleForm ID="SimpleForm_WCR10" runat="server" BodyPadding="5px" Title="10)"
                                                ShowBorder="true" ShowHeader="true" EnableCollapse="true" Collapsed="true">
                                                <Items>
                                                    <x:TextArea ID="TextArea_WCR10_Title" runat="server" Height="50px" Label="标题" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR10_Content" runat="server" Height="50px" Label="具体内容"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR10_Request" runat="server" Height="50px" Label="具体要求"
                                                        Text="" AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                    <x:TextArea ID="TextArea_WCR10_Point" runat="server" Height="50px" Label="考核要点" Text=""
                                                        AutoGrowHeight="true" CssStyle="width:97%">
                                                    </x:TextArea>
                                                </Items>
                                            </x:SimpleForm>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Panel>
                            <x:Panel ID="Panel7" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                Title="（三）权责范围">
                                <Items>
                                    <x:Panel ID="Panel8" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                        CssStyle="width:100%" Title="1.权利">
                                        <Items>
                                            <x:TextArea ID="TextArea_Power" runat="server" Label="" Text="" CssStyle="width:97%"
                                                AutoGrowHeight="true">
                                            </x:TextArea>
                                        </Items>
                                    </x:Panel>
                                    <x:Panel ID="Panel9" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                        CssStyle="width:100%" Title="2.责任">
                                        <Items>
                                            <x:TextArea ID="TextArea_Response" runat="server" Label="" Text="" CssStyle="width:97%"
                                                AutoGrowHeight="true">
                                            </x:TextArea>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Panel>
                            <x:SimpleForm ID="SimpleForm3" runat="server" BodyPadding="5px" Title="（四）工作关系">
                                <Items>
                                    <x:TextBox ID="TextBox_DirectLeader" runat="server" Label="1.直接领导" Text="">
                                    </x:TextBox>
                                    <x:TextBox ID="TextBox_Subordinate" runat="server" Label="2.下属" Text="">
                                    </x:TextBox>
                                    <x:TextBox ID="TextBox_Colleague" runat="server" Label="3.同事" Text="">
                                    </x:TextBox>
                                    <x:TextBox ID="TextBox_Services" runat="server" Label="4.服务对象" Text="">
                                    </x:TextBox>
                                    <x:TextBox ID="TextBox_Relations" runat="server" Label="5.外部关系" Text="">
                                    </x:TextBox>
                                </Items>
                            </x:SimpleForm>
                            <x:Panel ID="Panel10" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                                Title="（五）工作环境">
                                <Items>
                                    <x:TextArea ID="TextArea_WorkEnter" runat="server" Height="50px" Label="Label" Text=""
                                        CssStyle="width:97%" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel11" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                        Title="三、岗位考核">
                        <Items>
                            <x:TextArea ID="TextArea_PostAssess" runat="server" Height="50px" Label="Label" Text=""
                                CssStyle="width:97%" AutoGrowHeight="true">
                            </x:TextArea>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel12" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                        Title="四、其他约定">
                        <Items>
                            <x:TextArea ID="TextArea_Others" runat="server" Height="50px" Label="Label" Text=""
                                CssStyle="width:97%" AutoGrowHeight="true">
                            </x:TextArea>
                        </Items>
                    </x:Panel>
                    <x:Toolbar ID="Toolbar3" runat="server" Position="top" CssStyle="width:100%">
                        <Items>
                            <x:Button ID="Button_Close_Shadow" runat="server" Text="关闭">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Save_Shadow" runat="server" Text="保存" OnClick="Button_Save_Click" ConfirmText="确定保存？"
                                ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Submit_Shadow" runat="server" Text="提交" OnClick="Button_Submit_Click"
                                ConfirmText="确定提交？" ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Clear_Shadow" runat="server" Text="清空" OnClick="Button_Clear_Click"
                                ConfirmText="确定清空？" ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator9" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Pass_Shadow" runat="server" Text="通过" OnClick="Button_Pass_Click" ConfirmText="确定通过？"
                                ConfirmTitle="提示">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator10" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Reject_Shadow" runat="server" Text="退回">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator12" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Export_Shadow" runat="server" Text="导出" OnClick="Button_Export_Click" EnableAjax="false">
                            </x:Button>
                            <x:ToolbarFill ID="ToolbarFill2" runat="server">
                            </x:ToolbarFill>
                            <x:Label ID="Label2" runat="server" Label="" Text="审核意见：">
                            </x:Label>
                            <x:Label ID="Label3" runat="server" Label="审核意见" Text="">
                            </x:Label>
                        </Items>
                    </x:Toolbar>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" runat="server" BodyPadding="5px" Height="150px" IsModal="true"
        IFrameUrl="about:blank" EnableMaximize="false" EnableIFrame="true" Popup="false"
        Title="审核意见" Width="400px">
    </x:Window>
    </form>
</body>
</html>
