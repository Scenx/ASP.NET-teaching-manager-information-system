using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ����Ϣҵ���߼���*/
    public class bllStudent{
        /*���ѧ����Ϣ*/
        public static bool AddStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.AddStudent(student);
        }

        /*����studentNumber��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            return DAL.dalStudent.getSomeStudent(studentNumber);
        }

        /*����ѧ����Ϣ*/
        public static bool EditStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.EditStudent(student);
        }

        /*ɾ��ѧ����Ϣ*/
        public static bool DelStudent(string p)
        {
            return DAL.dalStudent.DelStudent(p);
        }

        /*����������ҳ��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetStudent(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudent.GetStudent(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ����Ϣ*/
        public static System.Data.DataSet getAllStudent()
        {
            return DAL.dalStudent.getAllStudent();
        }
    }
}
