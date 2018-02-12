<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_ClassInfoList.aspx.cs" Inherits="shuangyulin.Admin.M_ClassInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>班级信息列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="JavaScript/calendar.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">班级信息管理 》》班级信息列表</div>
     <div class="Body_Search">
        班级编号&nbsp;&nbsp;<asp:TextBox ID="classNumber" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        班级名称&nbsp;&nbsp;<asp:TextBox ID="className" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        所属专业&nbsp;&nbsp;<asp:DropDownList ID="classSpecialFieldNumber" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        成立日期&nbsp;&nbsp; <asp:TextBox ID="classBirthDate"  runat="server" Width="112px" onclick="setDay(this);"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
    <asp:Repeater ID="RpClassInfo" runat="server" onitemcommand="RpClassInfo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>班级编号</th>
                        <th>班级名称</th>
                        <th>所属专业</th>
                        <th>成立日期</th>
                        <th>班主任</th>
                        <th>联系电话</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("classNumber") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("classNumber")%> </td>
                <td align="center"><%#Eval("className")%> </td>
                  <td align="center"><%#GetSpecialFieldInfoclassSpecialFieldNumber(Eval("classSpecialFieldNumber").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("classBirthDate")).ToShortDateString() %></td>
                <td align="center"><%#Eval("classTeacherCharge")%> </td>
                <td align="center"><%#Eval("classTelephone")%> </td>
                <td align="center"><a href="M_EditClassInfo.aspx?classNumber=<%#Eval("classNumber") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("classNumber")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="3"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
