using Cnljli.Utility;
using System;
using System.Collections.Generic;

namespace Secret.Domain
{
    public class Model<T>
    {
        public int total { get; set; }
        public int num { get; set; }
        public int err { get; set; }
        public List<T> list { get; set; }
    }

    public class BaseData
    {
        public int? attention_num { get; set; }
        public int? attention_status { get; set; }
        public string comment_status { get; set; }
        private string _content;
        public string content { get { return Base64.decode(_content); } set { _content = value; } }
        public int? hug_num { get; set; }
        public int? hug_status { get; set; }
        public int? id { get; set; }
        public string login { get; set; }
        public int? neg { get; set; }
        public int? pos { get; set; }
        public long? post_at { get; set; }
        public DateTime? Post_at
        {
            get
            {
                if (post_at.HasValue)
                {
                    return new DateTime(1970, 1, 1).AddSeconds(post_at.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        public int? public_comments_count { get; set; }
        public int? score { get; set; }
        private string _title;
        public string title { get { return Base64.decode(_title); } set { _title = value; } }
        public int? uid { get; set; }
    }

    public class Data : BaseData
    {
        public int? rank { get; set; }
        public string status { get; set; }
    }

    public class CommentModel<T> : Model<T>
    {
        public List<Appending> appending { get; set; }
        public Article article { get; set; }
        public List<Appending> lz_comments { get; set; }
    }

    public class Article : BaseData
    {
        public int? anonymous { get; set; }
        public int? appended { get; set; }
        public int? com_permission { get; set; }
        public int? commented { get; set; }
        public long? scored_at { get; set; }
        public DateTime? Scored_at
        {
            get
            {
                if (scored_at.HasValue)
                {
                    return new DateTime(1970, 1, 1).AddSeconds(scored_at.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        private string _scored_content;
        public string scored_content { get { return Base64.decode(_scored_content); } set { _scored_content = value; } }
        public int? voted { get; set; }
    }

    public class Appending
    {
        public int? anonymous { get; set; }
        public int? article_id { get; set; }
        private string _content;
        public string content { get { return Base64.decode(_content); } set { _content = value; } }
        public long? created_at { get; set; }
        public DateTime? Created_at
        {
            get
            {
                if (created_at.HasValue)
                {
                    return new DateTime(1970, 1, 1).AddSeconds(created_at.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        public object floor { get; set; }
        public int? id { get; set; }
        public int? ip { get; set; }
        public string login { get; set; }
        public int? lz_replied { get; set; }
        public int? neg { get; set; }
        public int? parent_id { get; set; }
        public int? pos { get; set; }
        public int? score { get; set; }
        public string status { get; set; }
        public int? user_id { get; set; }
        public int? voted { get; set; }
    }

    public class Comment 
    {
        public int? anonymous { get; set; }
        public Object appending { get; set; }
        public int? article_id { get; set; }
        private string _content;
        public string content { get { return Base64.decode(_content); } set { _content = value; } }
        public long? created_at { get; set; }
        public DateTime? Created_at
        {
            get
            {
                if (created_at.HasValue)
                {
                    return new DateTime(1970, 1, 1).AddSeconds(created_at.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        public object floor { get; set; }
        public int? id { get; set; }
        public int? ip { get; set; }
        public string login { get; set; }
        public int? lz_replied { get; set; }
        public int? neg { get; set; }
        public int? parent_id { get; set; }
        public int? pos { get; set; }
        public int? score { get; set; }
        public string status { get; set; }
        public int? user_id { get; set; }
        public int? voted { get; set; }
    }
}
