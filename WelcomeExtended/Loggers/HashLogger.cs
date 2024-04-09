using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> m_LogMessages;
        private readonly string m_Name;

        public HashLogger(string name)
        {
            m_Name = name;
            m_LogMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in m_LogMessages)
            {
                sb.Append(item.Value + '\n');
            }
            //calls to console are slow
            Console.WriteLine(sb.ToString());
        }

        public void PrintByID(int ID)
        {
            if (m_LogMessages.ContainsKey(ID))
                Console.WriteLine(m_LogMessages[ID]);
            else
                Console.WriteLine("No message contains ID {0}", ID);
        }

        public void RemoveByID(int ID)
        {
            if (!m_LogMessages.ContainsKey(ID))
                m_LogMessages.Remove(ID, out var _);
        }
        
        public void LoadLogs(in string filePath)
        {
            if (File.Exists(filePath))
            {
                string readJson = File.ReadAllText(filePath, Encoding.UTF8);
                if (readJson != string.Empty)
                {
                    ConcurrentDictionary<int, string> fileData = JsonConvert.DeserializeObject<ConcurrentDictionary<int, string>>(readJson);
                    foreach (var item in fileData)
                    {
                        m_LogMessages[item.Key]= item.Value;
                    }
                }
            }
            else
                return;
        }
        
        public static void CopyLogsTo(out ConcurrentDictionary<int, string> temp)
        {
            temp = new ConcurrentDictionary<int, string>();
        }
        public static void GetDicFromFile(in string filePath, out ConcurrentDictionary<int, string> dic)
        {
            if (File.Exists(filePath))
            {
                string readJson = File.ReadAllText(filePath, Encoding.UTF8);
                if (readJson != string.Empty)
                {
                    ConcurrentDictionary<int, string> fileData = JsonConvert.DeserializeObject<ConcurrentDictionary<int, string>>(readJson);
                    foreach (var item in fileData)
                    {
                        fileData[item.Key] = item.Value;
                    }
                    dic = fileData;
                }
                dic = new ConcurrentDictionary<int, string>();
            }
            else
            {
                dic = new ConcurrentDictionary<int, string>();
                return;
            }
        }

        public void SaveLogs(in string filePath, in bool isAppending)
        {
            if(isAppending)
            {
                if(File.Exists(filePath))
                {
                    string readJson = File.ReadAllText(filePath, Encoding.UTF8);

                    if(readJson == string.Empty)
                    {
                        string json = JsonConvert.SerializeObject(m_LogMessages);
                        File.WriteAllText(filePath, json);
                    }
                    else
                    {
                        ConcurrentDictionary<int, string> fileData = JsonConvert.DeserializeObject<ConcurrentDictionary<int, string>>(readJson);
                        foreach (var item in m_LogMessages)
                        {
                            fileData[item.Key] = item.Value;
                        }
                        string outJson = JsonConvert.SerializeObject(fileData);
                        File.WriteAllText(filePath, outJson);
                    }
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(m_LogMessages);
                File.WriteAllText(filePath, json);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch(logLevel) 
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine( "- LOGGER - ");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", m_Name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state,exception)}");
            Console.ResetColor();
            m_LogMessages[eventId.Id] = message;
        }
    }
}
