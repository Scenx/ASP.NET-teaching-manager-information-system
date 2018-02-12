using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ����Ϣҵ���߼���ʵ��*/
    public class dalStudent
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ����Ϣʵ��*/
        public static bool AddStudent(ENTITY.Student student)
        {
            string sql = "insert into Student(studentNumber,studentName,studentPassword,studentSex,studentClassNumber,studentBirthday,studentState,studentPhoto,studentTelephone,studentEmail,studentQQ,studentAddress,studentMemo) values(@studentNumber,@studentName,@studentPassword,@studentSex,@studentClassNumber,@studentBirthday,@studentState,@studentPhoto,@studentTelephone,@studentEmail,@studentQQ,@studentAddress,@studentMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@studentPassword",SqlDbType.VarChar),
             new SqlParameter("@studentSex",SqlDbType.VarChar),
             new SqlParameter("@studentClassNumber",SqlDbType.VarChar),
             new SqlParameter("@studentBirthday",SqlDbType.DateTime),
             new SqlParameter("@studentState",SqlDbType.VarChar),
             new SqlParameter("@studentPhoto",SqlDbType.VarChar),
             new SqlParameter("@studentTelephone",SqlDbType.VarChar),
             new SqlParameter("@studentEmail",SqlDbType.VarChar),
             new SqlParameter("@studentQQ",SqlDbType.VarChar),
             new SqlParameter("@studentAddress",SqlDbType.VarChar),
             new SqlParameter("@studentMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = student.studentNumber; //ѧ��
            parm[1].Value = student.studentName; //����
            parm[2].Value = student.studentPassword; //��¼����
            parm[3].Value = student.studentSex; //�Ա�
            parm[4].Value = student.studentClassNumber; //���ڰ༶
            parm[5].Value = student.studentBirthday; //��������
            parm[6].Value = student.studentState; //������ò
            parm[7].Value = student.studentPhoto; //ѧ����Ƭ
            parm[8].Value = student.studentTelephone; //��ϵ�绰
            parm[9].Value = student.studentEmail; //ѧ������
            parm[10].Value = student.studentQQ; //��ϵqq
            parm[11].Value = student.studentAddress; //��ͥ��ַ
            parm[12].Value = student.studentMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����studentNumber��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            /*������ѯsql*/
            string sql = "select * from Student where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student student = new ENTITY.Student();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                student.studentNumber = DataRead["studentNumber"].ToString();
                student.studentName = DataRead["studentName"].ToString();
                student.studentPassword = DataRead["studentPassword"].ToString();
                student.studentSex = DataRead["studentSex"].ToString();
                student.studentClassNumber = DataRead["studentClassNumber"].ToString();
                student.studentBirthday = Convert.ToDateTime(DataRead["studentBirthday"].ToString());
                student.studentState = DataRead["studentState"].ToString();
                student.studentPhoto = DataRead["studentPhoto"].ToString();
                student.studentTelephone = DataRead["studentTelephone"].ToString();
                student.studentEmail = DataRead["studentEmail"].ToString();
                student.studentQQ = DataRead["studentQQ"].ToString();
                student.studentAddress = DataRead["studentAddress"].ToString();
                student.studentMemo = DataRead["studentMemo"].ToString();
            }
            return student;
        }

        /*����ѧ����Ϣʵ��*/
        public static bool EditStudent(ENTITY.Student student)
        {
            string sql = "update Student set studentName=@studentName,studentPassword=@studentPassword,studentSex=@studentSex,studentClassNumber=@studentClassNumber,studentBirthday=@studentBirthday,studentState=@studentState,studentPhoto=@studentPhoto,studentTelephone=@studentTelephone,studentEmail=@studentEmail,studentQQ=@studentQQ,studentAddress=@studentAddress,studentMemo=@studentMemo where studentNumber=@studentNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@studentPassword",SqlDbType.VarChar),
             new SqlParameter("@studentSex",SqlDbType.VarChar),
             new SqlParameter("@studentClassNumber",SqlDbType.VarChar),
             new SqlParameter("@studentBirthday",SqlDbType.DateTime),
             new SqlParameter("@studentState",SqlDbType.VarChar),
             new SqlParameter("@studentPhoto",SqlDbType.VarChar),
             new SqlParameter("@studentTelephone",SqlDbType.VarChar),
             new SqlParameter("@studentEmail",SqlDbType.VarChar),
             new SqlParameter("@studentQQ",SqlDbType.VarChar),
             new SqlParameter("@studentAddress",SqlDbType.VarChar),
             new SqlParameter("@studentMemo",SqlDbType.VarChar),
             new SqlParameter("@studentNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = student.studentName;
            parm[1].Value = student.studentPassword;
            parm[2].Value = student.studentSex;
            parm[3].Value = student.studentClassNumber;
            parm[4].Value = student.studentBirthday;
            parm[5].Value = student.studentState;
            parm[6].Value = student.studentPhoto;
            parm[7].Value = student.studentTelephone;
            parm[8].Value = student.studentEmail;
            parm[9].Value = student.studentQQ;
            parm[10].Value = student.studentAddress;
            parm[11].Value = student.studentMemo;
            parm[12].Value = student.studentNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ����Ϣ*/
        public static bool DelStudent(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Student where studentNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetStudent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Student";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "studentNumber", strShow, strSql, strWhere, " studentNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudent()
        {
            try
            {
                string strSql = "select * from Student";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
