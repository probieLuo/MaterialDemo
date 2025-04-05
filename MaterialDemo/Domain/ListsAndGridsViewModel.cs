using MaterialDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MaterialDemo.Domain
{
    public class ListsAndGridsViewModel : ViewModelBase
    {
        private int _pageSize;
        public int pageSize
        {
            get => _pageSize;
            set => SetProperty(ref _pageSize, value);
        }
        private string _PageNumber = "0";
        public string PageNumber
        {
            get => _PageNumber;
            set => SetProperty(ref _PageNumber, value);
        }
        private string _TotalPage = "0";
        public string TotalPage
        {
            get => _TotalPage;
            set => SetProperty(ref _TotalPage, value);
        }
        public ICommand FirstPageCmd { get; }
        public ICommand PreviousPageCmd { get; }
        public ICommand NextPageCmd { get; }
        public ICommand LastPageCmd { get; }

        public ListsAndGridsViewModel()
        {
            Items1 = CreateData();
            //Articles = GetArticleAll().GetAwaiter().GetResult();
            comboCount.AddRange(new int[] { 100, 200, 500, 1000, 2000, 5000 });
            pageSize = comboCount[0];
            _textContent = "<UserControl x:Class=\"MaterialDemo.Views.Palette\"\r\n             xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n             xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\r\n             xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" \r\n             xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\" \r\n             xmlns:local=\"clr-namespace:MaterialDemo.Views\"\r\n             xmlns:domain=\"clr-namespace:MaterialDemo.Domain\"\r\n             d:DataContext=\"{d:DesignInstance Type=domain:ListsAndGridsViewModel}\"\r\n             xmlns:materialDesign=\"http://materialdesigninxaml.net/winfx/xaml/themes\"\r\n             mc:Ignorable=\"d\" \r\n             d:DesignHeight=\"450\" d:DesignWidth=\"800\">\r\n\r\n    <UserControl.Resources>\r\n        <Style TargetType=\"TextBlock\">\r\n            <Setter Property=\"FontSize\" Value=\"14\" />\r\n            <Setter Property=\"FontWeight\" Value=\"DemiBold\" />\r\n            <Setter Property=\"Margin\" Value=\"4\" />\r\n        </Style>\r\n    </UserControl.Resources>\r\n    <Grid>\r\n        <Grid.RowDefinitions>\r\n            <RowDefinition Height=\"200\" />\r\n            <RowDefinition Height=\"*\" />\r\n        </Grid.RowDefinitions>\r\n        <Grid.ColumnDefinitions>\r\n            <ColumnDefinition Width=\"200\" />\r\n            <ColumnDefinition Width=\"*\" />\r\n        </Grid.ColumnDefinitions>\r\n        <Grid>\r\n            <Grid.RowDefinitions>\r\n                <RowDefinition Height=\"1*\" />\r\n                <RowDefinition Height=\"1*\" />\r\n                <RowDefinition Height=\"1*\" />\r\n            </Grid.RowDefinitions>\r\n\r\n            <Grid.ColumnDefinitions>\r\n                <ColumnDefinition Width=\"1*\" />\r\n                <ColumnDefinition Width=\"1*\" />\r\n                <ColumnDefinition Width=\"1*\" />\r\n            </Grid.ColumnDefinitions>\r\n\r\n            <Border Grid.ColumnSpan=\"3\"\r\n                    Background=\"{DynamicResource PrimaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueMidForegroundBrush}\"\r\n                           Text=\"Primary - Mid\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"0\"\r\n                    Background=\"{DynamicResource PrimaryHueLightBrush}\">\r\n                <TextBlock FontWeight=\"Bold\"\r\n                           Foreground=\"{DynamicResource PrimaryHueLightForegroundBrush}\"\r\n                           Text=\"Light\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"1\"\r\n                    Background=\"{DynamicResource PrimaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueMidForegroundBrush}\"\r\n                           Text=\"Mid\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"1\"\r\n                    Grid.Column=\"2\"\r\n                    Background=\"{DynamicResource PrimaryHueDarkBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource PrimaryHueDarkForegroundBrush}\"\r\n                           Text=\"Dark\" />\r\n            </Border>\r\n\r\n            <Border Grid.Row=\"2\"\r\n                    Grid.Column=\"0\"\r\n                    Grid.ColumnSpan=\"3\"\r\n                    Background=\"{DynamicResource SecondaryHueMidBrush}\">\r\n                <TextBlock Foreground=\"{DynamicResource SecondaryHueMidForegroundBrush}\"\r\n                           Text=\"Secondary\" />\r\n            </Border>\r\n        </Grid>\r\n        <StackPanel Grid.Row=\"0\" Grid.Column=\"1\">\r\n            <CheckBox x:Name=\"MaterialDesignOutlinedTextBoxEnabledComboBox\"\r\n                      Content=\"IsReadOnly\" />\r\n            <TextBox Height=\"180\"\r\n                     FontFamily=\"Consolas\"\r\n                     VerticalAlignment=\"Top\"\r\n                     materialDesign:HintAssist.Hint=\"This is a text area\"\r\n                     AcceptsReturn=\"True\"\r\n                     IsReadOnly=\"{Binding Path=IsChecked, ElementName=MaterialDesignOutlinedTextBoxEnabledComboBox}\"\r\n                     Style=\"{StaticResource MaterialDesignOutlinedTextBox}\"\r\n                     TextWrapping=\"Wrap\"\r\n                     VerticalScrollBarVisibility=\"Auto\" />\r\n        </StackPanel>\r\n        <DataGrid Grid.Row=\"1\" Grid.ColumnSpan=\"2\" CanUserAddRows=\"False\"\r\n                  ItemsSource=\"{Binding Items1}\"\r\n                  SelectionMode=\"Extended\"\r\n                  SelectionUnit=\"Cell\" />\r\n    </Grid>\r\n    \r\n</UserControl>\r\n";
            FirstPageCmd = new RelayCommand(FirstPage);
            PreviousPageCmd = new RelayCommand(PreviousPage);
            NextPageCmd = new RelayCommand(NextPage);
            LastPageCmd = new RelayCommand(LastPage);

        }
        bool _canNextPage = true;
        public bool CanNext
        {
            get => _canNextPage;
            set => SetProperty(ref _canNextPage, value);
        }

        bool _canPreviousPage = true;
        public bool CanPrevious
        {
            get => _canPreviousPage;
            set => SetProperty(ref _canPreviousPage, value);
        }
        Visibility _progVisibility = Visibility.Visible;
        public Visibility progVisibility
        {
            get => _progVisibility;
            set
            {
                _progVisibility = value;
                OnPropertyChanged(nameof(progVisibility));
            }
        }
        private void NextPage(object obj)
        {
            progVisibility = Visibility.Visible;
            CanNext = false;
            Task.Run(() =>
            {
                if (int.Parse(TotalPage) > int.Parse(PageNumber))
                {
                    using (Models.TestContext ctx = new TestContext())
                    {
                        ObservableCollection<Article> articles = new ObservableCollection<Article>();
                        var dbSet = ctx.Articles.OrderBy(x => x.Id).Skip((int.Parse(PageNumber) - 0) * pageSize).Take(pageSize).ToList();
                        foreach (var article in dbSet)
                        {
                            articles.Add(article);
                        }
                        int count = ctx.Articles.Count();
                        TotalPage = (count / pageSize).ToString();
                        if (count % pageSize > 0)
                        {
                            TotalPage = (count / pageSize + 1).ToString();
                        }
                        PageNumber = (int.Parse(PageNumber) + 1).ToString();
                        Articles = articles;
                        OnPropertyChanged(nameof(Articles));
                    }
                }
                CanNext = true;
            });

        }

        private void LastPage(object obj)
        {

            Task.Run(() =>
            {
                if (PageNumber != TotalPage)
                {
                    using (Models.TestContext ctx = new TestContext())
                    {
                        ObservableCollection<Article> articles = new ObservableCollection<Article>();
                        var dbSet = ctx.Articles.OrderBy(x => x.Id).Skip((int.Parse(TotalPage) - 1) * pageSize).Take(pageSize).ToList();
                        foreach (var article in dbSet)
                        {
                            articles.Add(article);
                        }
                        int count = ctx.Articles.Count();
                        TotalPage = (count / pageSize).ToString();
                        if (count % pageSize > 0)
                        {
                            TotalPage = (count / pageSize + 1).ToString();
                        }
                        PageNumber = TotalPage;
                        Articles = articles;
                        OnPropertyChanged(nameof(Articles));
                    }
                }

            });
        }

        private void PreviousPage(object obj)
        {
            CanPrevious = false;
            Task.Run(() =>
            {
                if (int.Parse(PageNumber) > 1)
                {
                    using (Models.TestContext ctx = new TestContext())
                    {
                        ObservableCollection<Article> articles = new ObservableCollection<Article>();
                        var dbSet = ctx.Articles.OrderBy(x => x.Id).Skip((int.Parse(PageNumber) - 2) * pageSize).Take(pageSize).ToList();
                        foreach (var article in dbSet)
                        {
                            articles.Add(article);
                        }
                        int count = ctx.Articles.Count();
                        TotalPage = (count / pageSize).ToString();
                        if (count % pageSize > 0)
                        {
                            TotalPage = (count / pageSize + 1).ToString();
                        }
                        PageNumber = (int.Parse(PageNumber) - 1).ToString();
                        Articles = articles;
                        OnPropertyChanged(nameof(Articles));
                    }
                }
                CanPrevious = true;
            });
        }

        private void FirstPage(object obj)
        {
            Task.Run(() =>
            {
                if (PageNumber != "1")
                {
                    using (Models.TestContext ctx = new TestContext())
                    {
                        ObservableCollection<Article> articles = new ObservableCollection<Article>();
                        var dbSet = ctx.Articles.OrderBy(x => x.Id).Skip(0).Take(pageSize).ToList();
                        foreach (var article in dbSet)
                        {
                            articles.Add(article);
                        }
                        int count = ctx.Articles.Count();
                        TotalPage = (count / pageSize).ToString();
                        if (count % pageSize > 0)
                        {
                            TotalPage = (count / pageSize + 1).ToString();
                        }
                        PageNumber = "1";
                        Articles = articles;
                        OnPropertyChanged(nameof(Articles));
                    }
                }

            });

        }

        public async Task InitializeAsync()
        {
            Articles = await GetArticleAll();
            OnPropertyChanged(nameof(Articles));
        }
        public void Initializesync()
        {
            Articles = GetArticleAllsync();
            OnPropertyChanged(nameof(Articles));

        }
        private async Task<ObservableCollection<Article>> GetArticleAll()
        {
            ObservableCollection<Article> articles = new ObservableCollection<Article>();
            using (Models.TestContext ctx = new TestContext())
            {
                DbSet<Article> dbSet = ctx.Articles;

                foreach (var article in await dbSet.ToListAsync())
                {
                    articles.Add(article);
                }
            }
            return articles;
        }
        private ObservableCollection<Article> GetArticleAllsync()
        {
            ObservableCollection<Article> articles = new ObservableCollection<Article>();
            using (Models.TestContext ctx = new TestContext())
            {
                var dbSet = ctx.Articles.OrderBy(x => x.Id).Skip(0).Take(pageSize).ToList();

                foreach (var article in dbSet)
                {
                    articles.Add(article);
                }
                int count = ctx.Articles.Count();
                TotalPage = (count / pageSize).ToString();
                if (count % pageSize > 0)
                {
                    TotalPage = (count / pageSize + 1).ToString();
                }
                PageNumber = "1";
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

        public event EventHandler? CanExecuteChanged;

        public string TextContent
        {
            get => _textContent;
            set => SetProperty(ref _textContent, value);
        }
        public ObservableCollection<Models.Article> Articles { get; set; }

        public List<int> comboCount { get; set; } = new List<int>();
    }
}
