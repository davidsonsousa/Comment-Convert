using System.Net;

namespace CommentConvert.Ui.Core
{
    public static class Utilities
    {
        public static string LoadFacebookComments(string articleUrl, string token)
        {
            string url = string.Format(Constants.GraphUrl, articleUrl, token);

            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
