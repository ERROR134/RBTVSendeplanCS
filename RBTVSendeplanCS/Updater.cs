using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Net;
using Google.Apis.Auth;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;


namespace RBTVSendeplanCS
{
    class Updater
    {
        public double CheckForNewestVersion()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("https://docs.google.com/uc?export=download&id=0B78J1jlGQohYN1BmUnZCWlVOVkk"));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    using(StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.UTF8))
                    {
                        string str_version = reader.ReadToEnd();
                        double f_version = Convert.ToDouble(str_version);
                        return f_version;
                    }
                }
                else
                {
                    MessageBox.Show("An error occured while trying to look for new version: " + response.StatusDescription);
                    return -1;
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("An error occured while trying to look for new version: " + e.Message);
                return -2;
            }
        }


        public string CheckForNewestVersion(double current_version)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("https://docs.google.com/uc?export=download&id=0B78J1jlGQohYN1BmUnZCWlVOVkk"));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string content = reader.ReadToEnd();
                        string str_version = content.Substring(0, content.IndexOf(';'));
                        string hyperlink = content.Substring(content.IndexOf(';')+1);
                        double f_version = Convert.ToDouble(str_version);
                        if (f_version > current_version)
                            return hyperlink;
                        else
                            return null;
                    }
                }
                else
                {
                    MessageBox.Show("An error occured while trying to look for new version: " + response.StatusDescription);
                    return null;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured while trying to look for new version: " + e.Message);
                return null;
            }
        }

        public bool DownloadLatestVersion()
        {
            return false;
        }
    }
}
