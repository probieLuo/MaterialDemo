using MaterialDemo.Domain;
using MaterialDemo.Extentions;
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
            this.DataContext = new JsonHelpViewModel();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = "";
                List<string> list = JsonToClassGenerator.GenerateClass(JsonStr.Text, "Root", out message);
                if (message != string.Empty)
                {
                    DialogHostMessage.Text = message + "\n" + message + "\n" + message;
                    DialogHost.IsOpen = true;
                    return;
                }
                string str = string.Empty;
                string pattern = @"public\s+class\s+(\w+)\s*\{[^{}]*\}";
                foreach (var item in list)
                {

                    str += "\n" + item;
                }
                ToCSharpStr.Text = str;
            }
            catch (Exception ex)
            {
                DialogHost.IsOpen = true;
            }
        }
        */
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ToCSharpStr.Text))
            {
                string thisClassPath = FileExtention.GetThisFilePath();
                string thisClassDirectory = Path.GetDirectoryName(thisClassPath);
                // 获取上一级目录
                DirectoryInfo parentDirInfo = Directory.GetParent(thisClassDirectory);
                if (parentDirInfo == null)
                {
                    throw new InvalidOperationException("无法获取上一级目录");
                }

                string filePath = parentDirInfo + @"\Models\" + "HelloWorld.cs";
                /* 保存到可执行程序路径
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "HelloWorld.cs";
                string filePath = Path.Combine(projectPath, fileName);
                */

                File.WriteAllText(filePath, ToCSharpStr.Text);
            }
        }
    }
}
