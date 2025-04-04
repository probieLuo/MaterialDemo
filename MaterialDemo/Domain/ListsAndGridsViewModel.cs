
using MaterialDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;

namespace MaterialDemo.Domain
{
    public class ListsAndGridsViewModel: ViewModelBase
    {
        public ListsAndGridsViewModel()
        {
            Items1 = CreateData();
            Articles = GetArticleAll();
            comboCount.AddRange(new int[] { 100, 200, 500, 1000, 2000, 5000 });

            _textContent = "<UserControl x:Class=\"MaterialDemo.Views.Palette\"\r\n             xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n             xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\r\n             xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" \r\n             xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\" \r\n             xmlns:local=\"clr-namespace:MaterialDemo.Views\"\r\n             xmlns:domain=\"clr-namespace:MaterialDemo.Domain\"\r\n             d:DataContext=\"{d:DesignInstance Type=domain:ListsAndGridsViewModel}\"\r\n             xmlns:materialDesign=\"http://materialdesigninxaml.net/winfx/xaml/themes\"\r\n             mc:Ignorable=\"d\" \r\n             d:DesignHeight=\"450\" d:DesignWidth=\"800\">\r\n\r\n    <UserControl.Resources>\r\n        <Style TargetType=\"TextBlock\">\r\n            <Setter Property=\"FontSize\" Value=\"14\" />\r\n            <Setter Property=\"FontWeight\" Value=\"DemiBold\" />\r\n            <Setter Property=\"Margin\" Value=\"4\" />\r\n        </Style>\r\n    </UserControl.Resources>\r\n    <Grid>\r\n        <Grid.RowDefinitions>\r\n            <RowDefinition Height=\"200\" />\r\n            <RowDefinition Height=\"*\" />\r\n        </Grid.RowDefinitions>\r\n        <Grid.ColumnDefinitions>\r\n            <ColumnDefinition Width=\"200\" />\r\n            <ColumnDefinition Width=\"*\" />\r\n        </Grid.ColumnDefinitions>\r\n        <Grid>\r\n            <Grid.RowDefinitions>\r\n                <RowDefinition Height=\"1*\" />\r\n                <RowDefinition Height=\"1*\" />\r\n                <RowDefinition Height=\"1*\" />\r\n            </Grid.RowDefinitions>\r\n\r\n            <Grid.ColumnDefinitions>\r\n                <ColumnDefinition Width=\"1*\" />\r\n                <ColumnDefinition Width=\"1*\" />\r\n                <ColumnDefinition Width=\"1*\" />\r\n            </Grid.ColumnDefinitions>\r\n\r\n            <Border Grid.ColumnSpan=\"3\"\r\n                    Background=\"{DynamicResource PrimaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueMidForegroundBrush}\"\r\n                           Text=\"Primary - Mid\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"0\"\r\n                    Background=\"{DynamicResource PrimaryHueLightBrush}\">\r\n                <TextBlock FontWeight=\"Bold\"\r\n                           Foreground=\"{DynamicResource PrimaryHueLightForegroundBrush}\"\r\n                           Text=\"Light\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"1\"\r\n                    Background=\"{DynamicResource PrimaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueMidForegroundBrush}\"\r\n                           Text=\"Mid\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"2\"\r\n                    Background=\"{DynamicResource PrimaryHueDarkBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueDarkForegroundBrush}\"\r\n                           Text=\"Dark\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"2\"\r\n                    Grid.Column=\"0\"\r\n                    Grid.ColumnSpan=\"3\"\r\n                    Background=\"{DynamicResource SecondaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource SecondaryHueMidForegroundBrush}\"\r\n                           Text=\"Secondary\" />\r\n            </Border>\r\n        </Grid>\r\n        <StackPanel Grid.Row=\"0\" Grid.Column=\"1\">\r\n            <CheckBox x:Name=\"MaterialDesignOutlinedTextBoxEnabledComboBox\"\r\n                      Content=\"IsReadOnly\" />\r\n            <TextBox Height=\"180\"\r\n                     FontFamily=\"Consolas\"\r\n                     VerticalAlignment=\"Top\"\r\n                     materialDesign:HintAssist.Hint=\"This is a text area\"\r\n                     AcceptsReturn=\"True\"\r\n                     IsReadOnly=\"{Binding Path=IsChecked, ElementName=MaterialDesignOutlinedTextBoxEnabledComboBox}\"\r\n                     Style=\"{StaticResource MaterialDesignOutlinedTextBox}\"\r\n                     TextWrapping=\"Wrap\"\r\n                     VerticalScrollBarVisibility=\"Auto\" />\r\n        </StackPanel>\r\n        <DataGrid Grid.Row=\"1\" Grid.ColumnSpan=\"2\" CanUserAddRows=\"False\"\r\n                  ItemsSource=\"{Binding Items1}\"\r\n                  SelectionMode=\"Extended\"\r\n                  SelectionUnit=\"Cell\" />\r\n    </Grid>\r\n    \r\n</UserControl>\r\n";
        }

        private ObservableCollection<Article> GetArticleAll()
        {
            ObservableCollection< Article > articles= new ObservableCollection<Article>();
            using (Models.TestContext ctx=new TestContext())
            {
                DbSet<Article> dbSet = ctx.Articles;
                foreach (var article in dbSet)
                {
                    articles.Add(article);
                }
            }
            return articles;
        }

        public ObservableCollection<SelectableViewModel> Items1 { get; }
        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
        {
            new SelectableViewModel
            {
                Code = 'M',
                Name = "Material Design",
                Description = "Material Design in XAML Toolkit"
            },
            new SelectableViewModel
            {
                Code = 'D',
                Name = "Dragablz",
                Description = "Dragablz Tab Control",
                Food = "Fries"
            },
            new SelectableViewModel
            {
                Code = 'P',
                Name = "Predator",
                Description = "If it bleeds, we can kill it"
            }
        };
        }
        private string _textContent;
        public string TextContent {
            get => _textContent;
            set => SetProperty(ref _textContent, value);
        }
        public ObservableCollection<Models.Article> Articles { get; }
        
        public List<int> comboCount { get; set; }= new List<int>();
    }
}
