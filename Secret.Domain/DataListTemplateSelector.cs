
namespace Secret.Domain
{
    public class DataListTemplateSelector : Cnljli.WPViewModel.UIElement.DataTemplateSelector
    {
        public System.Windows.DataTemplate WhiteSpaceTitle { get; set; }
        public System.Windows.DataTemplate Normal { get; set; }

        //根据newContent的属性，返回所需的DataTemplate
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            return Normal;
            return string.IsNullOrWhiteSpace((item as Data).title) ? WhiteSpaceTitle : Normal;
        }
    }
}
