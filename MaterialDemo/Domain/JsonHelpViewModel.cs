using MaterialDemo.Extentions;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace MaterialDemo.Domain
{
    public class JsonHelpViewModel: ViewModelBase
    {
        public ICommand ConverterCSharp { get; }
        public string JsonTextContent { get; private set; }

        public JsonHelpViewModel()
        {
            ConverterCSharp = new RelayCommand(ConverterCSharpM);
        }

        private void ConverterCSharpM(object obj)
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
                JsonTextContent = str;
            }
            catch (Exception ex)
            {
                DialogHost.IsOpen = true;
            }
        }

    }
}
