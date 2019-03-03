using CommentConvert.Ui.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public static (bool IsError, string Result) GenerateXmlComment(FbComment fbComment)
        {
            if (fbComment?.OgObject?.Comment == null)
            {
                return (true, "Nothing to import");
            }

            try
            {
                // 1. Read XML item
                string itemFile = File.ReadAllText(@"Templates\Item.xml");

                var sbItem = new StringBuilder();

                // 2. Loop through FB comments
                foreach (var comment in fbComment.OgObject.Comment.CommentList ?? Enumerable.Empty<CommentData>())
                {
                    string url = fbComment.Id.Replace("/en/", "/blog/")
                                             .Replace("/pt/", "/blog/");

                    sbItem.AppendLine(itemFile);
                    sbItem.Replace("{{TITLE}}", fbComment.OgObject.Title);
                    sbItem.Replace("{{URL}}", url);
                    sbItem.Replace("{{COMMENT_ID}}", comment.Id);
                    sbItem.Replace("{{AUTHOR_NAME}}", comment.From.Name);
                    sbItem.Replace("{{COMMENT_DATE}}", DateTime.Parse(comment.CreatedTime).ToString("yyyy-MM-dd HH:MM:ss"));
                    sbItem.Replace("{{COMMENT_BODY}}", comment.Message);
                }

                // 4. Read XML container
                string mainFile = File.ReadAllText(@"Templates\Main.xml");
                var sbMain = new StringBuilder(mainFile);

                // 5. Add XML with replaced placeholders into XML container
                sbMain.Replace("{{ITEMS}}", sbItem.ToString());

                // 6. Save generated XML content
                File.WriteAllText($@"Export\{fbComment.OgObject.Title.Replace(":", "")}.xml", sbMain.ToString());

                return (false, "XmlComment generated successfully");
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
