<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditCourseInfo.aspx.cs" Inherits="shuangyulin.Admin.M_EditCourseInfo" %>
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
            var courseNumber = document.getElementById("courseNumber").value;
            if (courseNumber == "") {
                alert("������γ̱��...");
                document.getElementById("courseNumber").focus();
                return false;
            }

            var courseName = document.getElementById("courseName").value;
            if (courseName == "") {
                alert("������γ�����...");
                document.getElementById("courseName").focus();
                return false;
            }

            var courseScore = document.getElementById("courseScore").value;
            if(courseScore == ""){
                alert("������γ�ѧ��...");
                document.getElementById("courseScore").focus();
                return false;
            }
            else if (!re.test(courseScore))
            {
                alert("�γ�ѧ������������");
                document.getElementById("courseScore").focus();
                //input.rate.focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�γ���Ϣ���� �����༭�γ���Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ̱�ţ�</td>
                    <td width="650px;">
                         <input id="courseNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������γ̱�ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ����ƣ�</td>
                    <td width="650px;">
                         <input id="courseName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������γ����ƣ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �Ͽ���ʦ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="courseTeacher" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ͽ�ʱ�䣺</td>
                    <td width="650px;">
                         <input id="courseTime" type="text"   style="width:400px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ͽεص㣺</td>
                    <td width="650px;">
                         <input id="coursePlace" type="text"   style="width:400px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ�ѧ�֣�</td>
                    <td width="650px;">
                         <input id="courseScore" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>������γ�ѧ�֣�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������Ϣ��</td>
                    <td width="650px;">
                         <input id="courseMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCourseInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnCourseInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

