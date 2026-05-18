using System.Diagnostics;

namespace DVLD.Common
{
    public class Logger
    {
        public static void LogError(string message)
        {
            string sourceName = "DVLD_Project";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(
                sourceName,
                message,
                EventLogEntryType.Error);
        }
    }
}