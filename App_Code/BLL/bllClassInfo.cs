using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�༶��Ϣҵ���߼���*/
    public class bllClassInfo{
        /*��Ӱ༶��Ϣ*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.AddClassInfo(classInfo);
        }

        /*����classNumber��ȡĳ���༶��Ϣ��¼*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNumber)
        {
            return DAL.dalClassInfo.getSomeClassInfo(classNumber);
        }

        /*���°༶��Ϣ*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.EditClassInfo(classInfo);
        }

        /*ɾ���༶��Ϣ*/
        public static bool DelClassInfo(string p)
        {
            return DAL.dalClassInfo.DelClassInfo(p);
        }

        /*����������ҳ��ѯ�༶��Ϣ*/
        public static System.Data.DataTable GetClassInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еİ༶��Ϣ*/
        public static System.Data.DataSet getAllClassInfo()
        {
            return DAL.dalClassInfo.getAllClassInfo();
        }
    }
}
