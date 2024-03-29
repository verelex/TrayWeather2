﻿using System.Reflection;

namespace TrayWeather2
{
    internal class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter()
        {
        }

        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //txtWriter.Write("\r\n> ");
                txtWriter.Write("> ");
                txtWriter.Write("{0} - {1}", DateTime.Now.ToLongDateString(),
                    DateTime.Now.ToLongTimeString());
                txtWriter.Write(" :{0}", logMessage);
                txtWriter.WriteLine(" ");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
