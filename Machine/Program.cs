using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Machine
{
    class Program
    {
        private static LoggingUtility _log = new LoggingUtility("Log_Machine", Level.Error, 30);
        public static LoggingUtility Log { get { return _log; } }

        //시작 Log.
        //("프로젝트명_클래스명_메서드명 상태")
        //Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 시작");

        //종료 Log.
        //Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 정상종료");

        //로그 오류
        //Log.WriteError("DAC_Log4NetSampleCode_ErrorSample() 오류", err);


        static void Main(string[] args)
        {



        }
    }
}
