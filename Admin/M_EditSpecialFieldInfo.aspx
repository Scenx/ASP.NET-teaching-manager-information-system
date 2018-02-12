<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditSpecialFieldInfo.aspx.cs" Inherits="shuangyulin.Admin.M_EditSpecialFieldInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="JavaScript/date.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var specialFieldNumber = document.getElementById("specialFieldNumber").value;
            if (specialFieldNumber == "") {
                alert("请输入专业编号...");
                document.getElementById("specialFieldNumber").focus();
                return false;
            }

            var specialFieldName = document.getElementById("specialFieldName").value;
            if (specialFieldName == "") {
                alert("请输入专业名称...");
                document.getElementById("specialFieldName").focus();
                return false;
            }

            var specialBirthDate = document.getElementById("specialBirthDate").value;
            if (specialBirthDate == "") {
                alert("请输入成立日期...");
                document.getElementById("specialBirthDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">专业信息管理 》》编辑专业信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   专业编号：</td>
                    <td width="650px;">
                         <input id="specialFieldNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入专业编号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   专业名称：</td>
                    <td width="650px;">
                         <input id="specialFieldName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入专业名称！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    所在学院：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="specialCollegeNumber" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  成立日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="specialBirthDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系人：</td>
                    <td width="650px;">
                         <input id="specialMan" type="text"   style="width:100px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="specialTelephone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   附加信息：</td>
                    <td width="650px;">
                         <input id="specialMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnSpecialFieldInfoSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnSpecialFieldInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

