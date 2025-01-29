using System.IO;

namespace StudentPortal.web
{
    public static class LogEvents
    {
        public static void LogToFile(string Title, string LogMessages)
        {
            StreamWriter swlog;
            string Filename= "Logfile.txt";

            if(!File.Exists(Filename))
            {
                swlog = new StreamWriter(Filename);
            }
            else
            {
                swlog = File.AppendText(Filename);
            }

            swlog.WriteLine("Log Entry");
            swlog.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            swlog.Close();


        }
    }
}
