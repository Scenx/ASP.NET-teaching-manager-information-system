<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditCollegeInfo.aspx.cs" Inherits="shuangyulin.Admin.M_EditCollegeInfo" %>
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
            var collegeNumber = document.getElementById("collegeNumber").value;
            if (collegeNumber == "") {
                alert("������ѧԺ���...");
                document.getElementById("collegeNumber").focus();
                return false;
            }

            var collegeName = document.getElementById("collegeName").value;
            if (collegeName == "") {
                alert("������ѧԺ����...");
                document.getElementById("collegeName").focus();
                return false;
            }

            var collegeBirthDate = document.getElementById("collegeBirthDate").value;
            if (collegeBirthDate == "") {
                alert("�������������...");
                document.getElementById("collegeBirthDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">ѧԺ��Ϣ���� �����༭ѧԺ��Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧԺ��ţ�</td>
                    <td width="650px;">
                         <input id="collegeNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧԺ��ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧԺ���ƣ�</td>
                    <td width="650px;">
                         <input id="collegeName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧԺ���ƣ�</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="collegeBirthDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   Ժ��������</td>
                    <td width="650px;">
                         <input id="collegeMan" type="text"   style="width:100px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="collegeTelephone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������Ϣ��</td>
                    <td width="650px;">
                         <input id="collegeMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCollegeInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnCollegeInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

