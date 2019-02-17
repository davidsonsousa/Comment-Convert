using System;
using System.Net;

namespace CommentConvert.Ui.Core
{
    public static class Utilities
    {
        public static (bool IsError, string Result) LoadFacebookComments(string articleUrl, string token)
        {
            string url = string.Format(Constants.GraphUrl, articleUrl, token);

            try
            {
                using (var client = new WebClient())
                {
                    return (false, client.DownloadString(url));
                }
            }
            //catch (WebException ex)
            //{
            //    return (true, ex.Message);
            //}
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
