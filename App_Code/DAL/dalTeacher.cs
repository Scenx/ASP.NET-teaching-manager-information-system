using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ʦ��Ϣҵ���߼���ʵ��*/
    public class dalTeacher
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӽ�ʦ��Ϣʵ��*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            string sql = "insert into Teacher(teacherNumber,teacherName,teacherPassword,teacherSex,teacherBirthday,teacherArriveDate,teacherCardNumber,teacherPhone,teacherPhoto,teacherAddress,teacherMemo) values(@teacherNumber,@teacherName,@teacherPassword,@teacherSex,@teacherBirthday,@teacherArriveDate,@teacherCardNumber,@teacherPhone,@teacherPhoto,@teacherAddress,@teacherMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherPassword",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherBirthday",SqlDbType.DateTime),
             new SqlParameter("@teacherArriveDate",SqlDbType.DateTime),
             new SqlParameter("@teacherCardNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherPhone",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherAddress",SqlDbType.VarChar),
             new SqlParameter("@teacherMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = teacher.teacherNumber; //��ʦ���
            parm[1].Value = teacher.teacherName; //��ʦ����
            parm[2].Value = teacher.teacherPassword; //��¼����
            parm[3].Value = teacher.teacherSex; //�Ա�
            parm[4].Value = teacher.teacherBirthday; //��������
            parm[5].Value = teacher.teacherArriveDate; //��ְ����
            parm[6].Value = teacher.teacherCardNumber; //���֤��
            parm[7].Value = teacher.teacherPhone; //��ϵ�绰
            parm[8].Value = teacher.teacherPhoto; //��ʦ��Ƭ
            parm[9].Value = teacher.teacherAddress; //��ͥ��ַ
            parm[10].Value = teacher.teacherMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����teacherNumber��ȡĳ����ʦ��Ϣ��¼*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNumber)
        {
            /*������ѯsql*/
            string sql = "select * from Teacher where teacherNumber='" + teacherNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teacher teacher = new ENTITY.Teacher();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                teacher.teacherNumber = DataRead["teacherNumber"].ToString();
                teacher.teacherName = DataRead["teacherName"].ToString();
                teacher.teacherPassword = DataRead["teacherPassword"].ToString();
                teacher.teacherSex = DataRead["teacherSex"].ToString();
                teacher.teacherBirthday = Convert.ToDateTime(DataRead["teacherBirthday"].ToString());
                teacher.teacherArriveDate = Convert.ToDateTime(DataRead["teacherArriveDate"].ToString());
                teacher.teacherCardNumber = DataRead["teacherCardNumber"].ToString();
                teacher.teacherPhone = DataRead["teacherPhone"].ToString();
                teacher.teacherPhoto = DataRead["teacherPhoto"].ToString();
                teacher.teacherAddress = DataRead["teacherAddress"].ToString();
                teacher.teacherMemo = DataRead["teacherMemo"].ToString();
            }
            return teacher;
        }

        /*���½�ʦ��Ϣʵ��*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            string sql = "update Teacher set teacherName=@teacherName,teacherPassword=@teacherPassword,teacherSex=@teacherSex,teacherBirthday=@teacherBirthday,teacherArriveDate=@teacherArriveDate,teacherCardNumber=@teacherCardNumber,teacherPhone=@teacherPhone,teacherPhoto=@teacherPhoto,teacherAddress=@teacherAddress,teacherMemo=@teacherMemo where teacherNumber=@teacherNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherPassword",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherBirthday",SqlDbType.DateTime),
             new SqlParameter("@teacherArriveDate",SqlDbType.DateTime),
             new SqlParameter("@teacherCardNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherPhone",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherAddress",SqlDbType.VarChar),
             new SqlParameter("@teacherMemo",SqlDbType.VarChar),
             new SqlParameter("@teacherNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = teacher.teacherName;
            parm[1].Value = teacher.teacherPassword;
            parm[2].Value = teacher.teacherSex;
            parm[3].Value = teacher.teacherBirthday;
            parm[4].Value = teacher.teacherArriveDate;
            parm[5].Value = teacher.teacherCardNumber;
            parm[6].Value = teacher.teacherPhone;
            parm[7].Value = teacher.teacherPhoto;
            parm[8].Value = teacher.teacherAddress;
            parm[9].Value = teacher.teacherMemo;
            parm[10].Value = teacher.teacherNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ʦ��Ϣ*/
        public static bool DelTeacher(string p)
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
            sql = "delete from Teacher where teacherNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��ʦ��Ϣ*/
        public static System.Data.DataTable GetTeacher(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teacher";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "teacherNumber", strShow, strSql, strWhere, " teacherNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeacher()
        {
            try
            {
                string strSql = "select * from Teacher";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
