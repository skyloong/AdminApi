using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        public static void Info(string info)
        {
            loginfo.Info(info);
        }

        public static void Error(string info, Exception ex)
        {
            logerror.Error(WriteLog(info, ex));
        }

        private static string WriteLog(string throwMsg, Exception ex)
        {
            return string.Format("\r\n【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
        }
    }
}
