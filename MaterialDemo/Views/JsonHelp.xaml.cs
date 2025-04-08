using MaterialDemo.Extentions;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MaterialDemo.Views
{
    /// <summary>
    /// JsonHelp.xaml 的交互逻辑
    /// </summary>
    public partial class JsonHelp : UserControl
    {
        public JsonHelp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = "";
                List<string> list = JsonToClassGenerator.GenerateClass(JsonStr.Text, "Root",out message);
                if (message != string.Empty)
                {
                    
                    DialogHostMessage.Text = message+"\n"+message+"\n"+message;
                    DialogHost.IsOpen = true;
                    return;
                }
                string str = string.Empty;
                foreach (var item in list)
                {
                    str += "\n" + item.ToString();
                }
                ToCSharpStr.Text = str;
            }
            catch (Exception ex)
            {
                DialogHost.IsOpen = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ToCSharpStr.Text))
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "HelloWorld.cs";
                string filePath = Path.Combine(projectPath, fileName);

                // 保存字符串到文件
                File.WriteAllText(filePath, ToCSharpStr.Text);
            }
        }
    }
}
