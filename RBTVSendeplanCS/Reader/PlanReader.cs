using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Globalization;

namespace RBTVSendeplanCS.Reader
{
    class PlanReader
    {
        //Membervars
        string Path;
        string Doc;

        //Path getter/setter
        public string getPath()
        {
            return Path;
        }
        public void setPath(string path)
        {
            Path = path;
        }

        //download Sendeplan as string
        public bool loadPlan()
        {
            try
            {

                WebClient client = new WebClient();
                //UTF8 for Schröckert
                client.Encoding = System.Text.Encoding.UTF8;
                //Link to the calendar .ics file (XML date format sucks)
                Doc = client.DownloadString(Path);//"
            }
            catch (Exception e)//Could not download file. Assuming no internet connection
            {
                return false;
            }
            //File was download without any problems
            return true;
        }

        //read and interpret downloaded plan
        public List<RbtvEvent> readPlan()
        {

            List<RbtvEvent> Events = new List<RbtvEvent>();
            
            StringReader strReader = new StringReader(Doc);

            //current line in strReader
            string line;
            while((line = strReader.ReadLine()) != null)//Loop through whole doc
            {
                if(line == "BEGIN:VEVENT")//Every event starts with this line
                {
                    string start = strReader.ReadLine();//start time is next line
                    string end = strReader.ReadLine();//end time is next line again
                    string ls = line.Substring(0,8);
                    while (ls != "SUMMARY:")//Read till the first letters are "SUMMARY:"
                    {
                        line = strReader.ReadLine();
                        ls = line.Substring(0,8);
                    }
                    string summary = line;


                    DateTime Start = DateTime.ParseExact(start.Substring(8), "yyyyMMddTHHmmssssZ", CultureInfo.InvariantCulture);
                    DateTime End = DateTime.ParseExact(end.Substring(6), "yyyyMMddTHHmmssssZ", CultureInfo.InvariantCulture);
                    if(End >= DateTime.Now)
                        Events.Add(new RbtvEvent(Start, End, summary));//Ad new Event 
                }

            }
            return Events;
        }
    }
}
