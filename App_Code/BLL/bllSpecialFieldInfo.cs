using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*רҵ��Ϣҵ���߼���*/
    public class bllSpecialFieldInfo{
        /*���רҵ��Ϣ*/
        public static bool AddSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            return DAL.dalSpecialFieldInfo.AddSpecialFieldInfo(specialFieldInfo);
        }

        /*����specialFieldNumber��ȡĳ��רҵ��Ϣ��¼*/
        public static ENTITY.SpecialFieldInfo getSomeSpecialFieldInfo(string specialFieldNumber)
        {
            return DAL.dalSpecialFieldInfo.getSomeSpecialFieldInfo(specialFieldNumber);
        }

        /*����רҵ��Ϣ*/
        public static bool EditSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            return DAL.dalSpecialFieldInfo.EditSpecialFieldInfo(specialFieldInfo);
        }

        /*ɾ��רҵ��Ϣ*/
        public static bool DelSpecialFieldInfo(string p)
        {
            return DAL.dalSpecialFieldInfo.DelSpecialFieldInfo(p);
        }

        /*����������ҳ��ѯרҵ��Ϣ*/
        public static System.Data.DataTable GetSpecialFieldInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSpecialFieldInfo.GetSpecialFieldInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�רҵ��Ϣ*/
        public static System.Data.DataSet getAllSpecialFieldInfo()
        {
            return DAL.dalSpecialFieldInfo.getAllSpecialFieldInfo();
        }
    }
}
