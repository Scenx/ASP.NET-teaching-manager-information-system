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
    ///ScoreInfo ��ժҪ˵�����ɼ���Ϣʵ��
    /// </summary>

    public class ScoreInfo
    {
        /*��¼���*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        /*ѧ������*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*�γ̶���*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        /*�ɼ��÷�*/
        private float _scoreValue;
        public float scoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }

        /*ѧ������*/
        private string _studentEvaluate;
        public string studentEvaluate
        {
            get { return _studentEvaluate; }
            set { _studentEvaluate = value; }
        }

    }
}
