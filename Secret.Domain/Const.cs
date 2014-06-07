
namespace Secret.Domain
{
    public class Const
    {
        public const string Find = "http://apprequest.secretmimi.com/article/hot/30/page/{0}?ver=new_version&jiankongbao=1";

        public const string Hot_24 = "http://apprequest.secretmimi.com/article/day/30/page/{0}?ver=new_version&jiankongbao=1";

        public const string Hot_7 = "http://apprequest.secretmimi.com/article/week/30/page/{0}?ver=new_version&jiankongbao=1";

        public const string Hot_30 = "http://apprequest.secretmimi.com/article/month/30/page/{0}?ver=new_version&jiankongbao=1";

        public const string New = "http://apprequest.secretmimi.com/article/late/30/page/{0}?ver=new_version&jiankongbao=1";

        public const string Commit = "http://apprequest.secretmimi.com/comments/{0}/list/30/page/{1}?ver=new_version&jiankongbao=1";

        public static System.Collections.Generic.List<string> ParstText(string text)
        {
            const int MAX = 300;
            var reader = new System.IO.StringReader(text);
            var tblist = new System.Collections.Generic.List<string>();

            string line;
            var builder = new System.Text.StringBuilder();
            while ((line = reader.ReadLine()) != null)
            {
                //如果总长度不超过MAX，则加入
                if (line.Length + builder.Length < MAX)
                {
                    builder.AppendLine(line);
                }
                else
                {
                    //先加入
                    tblist.Add(builder.ToString());

                    builder = new System.Text.StringBuilder();
                    //单行长度小于MAX，则Append
                    if (line.Length < MAX)
                    {
                        builder.AppendLine(line);
                    }
                    //单行长度大于MAX，则
                    else
                    {
                        int times = line.Length / MAX;
                        for (int j = 0; j < times; j++)
                        {
                            tblist.Add(line.Substring(j * MAX, MAX));
                        }
                        builder.AppendLine(line.Substring(times * MAX));
                    }
                }
            }
            if (builder.Length > 0)
                tblist.Add(builder.ToString());

            return tblist;
        }

    }
    public enum ListEnum
    {
        News = 0,
        Find,
        Hot_24,
        Hot_7,
        Hot_30
    }

}
