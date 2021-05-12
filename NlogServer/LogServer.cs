using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NlogServer
{
    public class LogServer
    {
        // Fields
        private static readonly bool Isinit = false;
        private static bool _logComplementEnable = false;
        private static bool _logDubugEnable = false;
        private static bool _logErrorEnable = false;
        private static bool _logExceptionEnable = false;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static bool _logInfoEnable = false;

        // Methods
        static LogServer()
        {
            if (!Isinit)
            {
                Isinit = true;
                SetConfig();
            }
        }


        public static void SetConfig()
        {
            Logger enable = LogManager.GetLogger("con");//获取配置，设置是否允许输出
            _logInfoEnable = enable.IsInfoEnabled;
            _logErrorEnable = enable.IsErrorEnabled;
            _logExceptionEnable = enable.IsErrorEnabled;
            _logComplementEnable = enable.IsTraceEnabled;
            _logDubugEnable = enable.IsDebugEnabled;
        }

        public static void WriteComplement(string info)
        {
            if (_logComplementEnable)
            {
                Logger.Trace(info);
            }
        }

        public static void WriteComplement(string info, Exception ex)
        {
            if (_logComplementEnable)
            {
                Logger.Trace(ex,info);
            }
        }

        public static void WriteDebug(string info)
        {
            if (_logDubugEnable)
            {
                Logger.Debug(info);
            }
        }

        public static void WriteError(string info)
        {
            if (_logErrorEnable)
            {
                Logger.Error(info);
            }
        }

        public static void WriteException(string info, Exception ex)
        {
            if (_logExceptionEnable)
            {
                Logger.Error(ex,info);
            }
        }

        public static void WriteFatal(string info)
        {
            if (_logErrorEnable)
            {
                Logger.Fatal(info);
            }
        }

        public static void WriteInfo(string info)
        {
            if (_logInfoEnable)
            {
                Logger.Info(info);
            }
        }
    }
}
