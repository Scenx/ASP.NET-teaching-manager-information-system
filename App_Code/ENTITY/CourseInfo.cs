using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///CourseInfo ��ժҪ˵�����γ���Ϣʵ��
    /// </summary>

    public class CourseInfo
    {
        /*�γ̱��*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        /*�γ�����*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*�Ͽ���ʦ*/
        private string _courseTeacher;
        public string courseTeacher
        {
            get { return _courseTeacher; }
            set { _courseTeacher = value; }
        }

        /*�Ͽ�ʱ��*/
        private string _courseTime;
        public string courseTime
        {
            get { return _courseTime; }
            set { _courseTime = value; }
        }

        /*�Ͽεص�*/
        private string _coursePlace;
        public string coursePlace
        {
            get { return _coursePlace; }
            set { _coursePlace = value; }
        }

        /*�γ�ѧ��*/
        private float _courseScore;
        public float courseScore
        {
            get { return _courseScore; }
            set { _courseScore = value; }
        }

        /*������Ϣ*/
        private string _courseMemo;
        public string courseMemo
        {
            get { return _courseMemo; }
            set { _courseMemo = value; }
        }

    }
}
