using System;

namespace Secret.Domain
{
    public class DetailModel : Cnljli.WPViewModel.SuperViewModel
    {
        private System.Net.WebHeaderCollection Headers = new System.Net.WebHeaderCollection();

        public System.Collections.ObjectModel.ObservableCollection<Appending> Appending { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<string> Content { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<Comment> Comment { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { NotifyPropertyChanged(ref  title, value); }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { NotifyPropertyChanged(ref  author, value); }
        }

        private DateTime? create;

        public DateTime? Create
        {
            get { return create; }
            set { NotifyPropertyChanged(ref  create, value); }
        }

        private System.Windows.Visibility havAppend;

        public System.Windows.Visibility HavAppend
        {
            get { return havAppend; }
            set { NotifyPropertyChanged(ref  havAppend, value); }
        }

        private bool isLoad;

        public bool IsLoad
        {
            get { return isLoad; }
            set { NotifyPropertyChanged(ref  isLoad, value); }
        }
        private string loadText;

        public string LoadText
        {
            get { return loadText; }
            set { NotifyPropertyChanged(ref  loadText, value); }
        }

        private bool isIndeterminate;

        public bool IsIndeterminate
        {
            get { return isIndeterminate; }
            set { NotifyPropertyChanged(ref  isIndeterminate, value); }
        }

        public DetailModel(int id)
        {
            //id = 3187494;      
            Content = new System.Collections.ObjectModel.ObservableCollection<string>();
            Appending = new System.Collections.ObjectModel.ObservableCollection<Appending>();
            Comment = new System.Collections.ObjectModel.ObservableCollection<Comment>();

            Headers["Secret-Lang"] = "zh-hans";
            HavAppend = System.Windows.Visibility.Visible;
            IsIndeterminate = true;
            IsLoad = true;
            LoadText = "数据加载中";
            Invoke(id);
        }

        private void Invoke(int id)
        {
            Cnljli.Utility.HttpUtility.Request((e) =>
           {
               this.BeginInvoke(() =>
               {
                   IsIndeterminate = false;
                   LoadText = "网络错误,请检查网络";
               });
           }, (str) =>
           {
               Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(new System.IO.StringReader(str));
               CommentModel<Comment> deserializedProduct = new Newtonsoft.Json.JsonSerializer().Deserialize<CommentModel<Comment>>(reader);
               this.BeginInvoke(() =>
               {
                   if (deserializedProduct.appending.Count > 0)
                   {
                       deserializedProduct.appending.ForEach(x =>
                       {
                           Appending.Add(x);
                       });
                   }
                   else
                   {
                       HavAppend = System.Windows.Visibility.Collapsed;
                   }
                   Const.ParstText(string.Format("\t\t{0}", deserializedProduct.article.content)).ForEach(x =>
                   {
                       Content.Add(x);
                   });
                   deserializedProduct.list.ForEach(x =>
                   {
                       Comment.Add(x);
                   });
                   Title = deserializedProduct.article.title;
                   Author = deserializedProduct.article.login;
                   Create = deserializedProduct.article.Post_at;
                   IsLoad = false;
               });
           }, string.Format(Const.Commit, id, 1), Headers);
        }
    }

}
