<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditTeacher.aspx.cs" Inherits="shuangyulin.Admin.M_EditTeacher" %>
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
            var teacherNumber = document.getElementById("teacherNumber").value;
            if (teacherNumber == "") {
                alert("�������ʦ���...");
                document.getElementById("teacherNumber").focus();
                return false;
            }

            var teacherName = document.getElementById("teacherName").value;
            if (teacherName == "") {
                alert("�������ʦ����...");
                document.getElementById("teacherName").focus();
                return false;
            }

            var teacherSex = document.getElementById("teacherSex").value;
            if (teacherSex == "") {
                alert("�������Ա�...");
                document.getElementById("teacherSex").focus();
                return false;
            }

            var teacherBirthday = document.getElementById("teacherBirthday").value;
            if (teacherBirthday == "") {
                alert("�������������...");
                document.getElementById("teacherBirthday").focus();
                return false;
            }

            var teacherArriveDate = document.getElementById("teacherArriveDate").value;
            if (teacherArriveDate == "") {
                alert("��������ְ����...");
                document.getElementById("teacherArriveDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">��ʦ��Ϣ���� �����༭��ʦ��Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ��ţ�</td>
                    <td width="650px;">
                         <input id="teacherNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦ��ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ������</td>
                    <td width="650px;">
                         <input id="teacherName" type="text"   style="width:120px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦ������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��¼���룺</td>
                    <td width="650px;">
                         <input id="teacherPassword" type="text"   style="width:300px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ա�</td>
                    <td width="650px;">
                         <input id="teacherSex" type="text"   style="width:20px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������Ա�</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="teacherBirthday"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ��ְ���ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="teacherArriveDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���֤�ţ�</td>
                    <td width="650px;">
                         <input id="teacherCardNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="teacherPhone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ��Ƭ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="teacherPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="TeacherPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_TeacherPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_TeacherPhotoUpload_Click" /></td><td>
                         <asp:Image ID="TeacherPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ͥ��ַ��</td>
                    <td width="650px;">
                         <input id="teacherAddress" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������Ϣ��</td>
                    <td width="650px;">
                         <input id="teacherMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnTeacherSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnTeacherSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

