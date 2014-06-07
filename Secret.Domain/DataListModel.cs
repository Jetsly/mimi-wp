
namespace Secret.Domain
{
    public class DataListModel : Cnljli.WPViewModel.SuperViewModel
    {
        private System.Net.WebHeaderCollection Headers = new System.Net.WebHeaderCollection();

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

        private Cnljli.ViewModel.UIElement.VirtualizingCollection<Data> virtuaData;

        private string title;

        private string currentUrl;

        private int currentPageIndex = 0;

        private object lockObj = new object();

        public DataListModel(ListEnum _listEnum)
        {
            Headers["Secret-Lang"] = "zh-hans";
            switch (_listEnum)
            {
                case ListEnum.News:
                    this.title = "秘密网-民间版(最新)";
                    currentUrl = Const.New;
                    break;
                case ListEnum.Find:
                    this.title = "秘密网-民间版(发现)";
                    currentUrl = Const.Find;
                    break;
                case ListEnum.Hot_24:
                    this.title = "秘密网-民间版(24小时内)";
                    currentUrl = Const.Hot_24;
                    break;
                case ListEnum.Hot_7:
                    this.title = "秘密网-民间版(7天内)";
                    currentUrl = Const.Hot_7;
                    break;
                case ListEnum.Hot_30:
                    this.title = "秘密网-民间版(30天内)";
                    currentUrl = Const.Hot_30;
                    break;
            }

            virtuaData = new Cnljli.ViewModel.UIElement.VirtualizingCollection<Data>(Invoke, currentPageIndex, 30);
        }

        private void Invoke(System.Action callback)
        {
            if (!IsLoad)
            {
                IsIndeterminate = true;
                IsLoad = true;
                LoadText = "数据加载中";
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
                    Model<Data> deserializedProduct = new Newtonsoft.Json.JsonSerializer().Deserialize<Model<Data>>(reader);
                    deserializedProduct.list.ForEach(x =>
                    {
                        x.neg = x.neg.HasValue ? 0 - x.neg.Value : 0;
                        this.BeginInvoke(() =>
                        {
                            virtuaData.Add(x);
                        });
                    });
                    currentPageIndex++;
                    (callback == null ? () => { } : callback)();
                    this.BeginInvoke(() =>
                    {
                        virtuaData.NotifyCollectionChanged();
                        IsLoad = false ;
                    });
                }, string.Format(currentUrl, currentPageIndex), Headers);
            }
        }

        public string Title
        {
            get { return title; }
        }

        public Cnljli.ViewModel.UIElement.VirtualizingCollection<Data> VirtuaData
        {
            get { return virtuaData; }
        }

    }
}
