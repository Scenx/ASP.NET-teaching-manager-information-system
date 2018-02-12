using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ʦ��Ϣҵ���߼���*/
    public class bllTeacher{
        /*��ӽ�ʦ��Ϣ*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.AddTeacher(teacher);
        }

        /*����teacherNumber��ȡĳ����ʦ��Ϣ��¼*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNumber)
        {
            return DAL.dalTeacher.getSomeTeacher(teacherNumber);
        }

        /*���½�ʦ��Ϣ*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.EditTeacher(teacher);
        }

        /*ɾ����ʦ��Ϣ*/
        public static bool DelTeacher(string p)
        {
            return DAL.dalTeacher.DelTeacher(p);
        }

        /*����������ҳ��ѯ��ʦ��Ϣ*/
        public static System.Data.DataTable GetTeacher(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĽ�ʦ��Ϣ*/
        public static System.Data.DataSet getAllTeacher()
        {
            return DAL.dalTeacher.getAllTeacher();
        }
    }
}
