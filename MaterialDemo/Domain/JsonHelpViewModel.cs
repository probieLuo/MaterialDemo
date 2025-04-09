using MaterialDemo.Extentions;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace MaterialDemo.Domain
{
    public class JsonHelpViewModel : ViewModelBase
    {
        public ICommand ConverterCSharp { get; }
        public ICommand SaveSingleFile { get; }
        public ICommand SaveMutiFlie { get; }
        public ICommand CopyToCSharpStr { get; }
        private string _jsonStr;
        public string JsonTextContent
        {
            get => _jsonStr;
            set => SetProperty(ref _jsonStr, value);
        }
        private bool _isOpen = false;
        public bool DialogHostIsOpen
        {
            get => _isOpen;
            set => SetProperty(ref _isOpen, value);
        }
        private string _dialogHostMessage;
        public string DialogHostMessage
        {
            get => _dialogHostMessage;
            set => SetProperty(ref _dialogHostMessage, value);
        }
        private string _nameSpace;
        public string NameSpaceTextContent
        {
            get => _nameSpace;
            set => SetProperty(ref _nameSpace, value);
        }
        private string _toCSharpTextContent;
        public string ToCSharpTextContent
        {
            get => _toCSharpTextContent;
            set => SetProperty(ref _toCSharpTextContent, value);
        }
        private string _className;
        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }
        private Dictionary<string, string> classStrs = new Dictionary<string, string>();
        public JsonHelpViewModel()
        {
            ConverterCSharp = new RelayCommand(ConverterCSharpMethod);
            SaveSingleFile = new RelayCommand(SaveSingleFileMethod);
            SaveMutiFlie = new RelayCommand(SaveMutiFlieMethod);
            CopyToCSharpStr = new RelayCommand(CopyToCSharpStrMethod);
        }

        private void CopyToCSharpStrMethod(object obj)
        {
            if (string.IsNullOrEmpty(ToCSharpTextContent))
            {
                // 将文本复制到剪贴板
                Clipboard.SetText(ToCSharpTextContent);
                Clipboard.Flush(); // 确保数据被写入剪贴板
            }
        }

        private void SaveMutiFlieMethod(object obj)
        {
            if (!string.IsNullOrEmpty(ToCSharpTextContent))
            {
                string thisClassPath = FileExtention.GetThisFilePath();
                string thisClassDirectory = Path.GetDirectoryName(thisClassPath);
                // 获取上一级目录
                DirectoryInfo parentDirInfo = Directory.GetParent(thisClassDirectory);
                if (parentDirInfo == null)
                {
                    DialogHostIsOpen = true;
                    DialogHostMessage = "无法获取上一级目录";
                }
                string directoryPath = parentDirInfo + @"\Models\ClashOfClans\";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                foreach (var item in classStrs)
                {
                    string filePath = directoryPath + $"{item.Key}.cs";
                    string namespaceStr = string.Empty;
                    if (NameSpaceTextContent.StartsWith("namespace") && NameSpaceTextContent.EndsWith(";"))
                    {
                        namespaceStr = NameSpaceTextContent;
                    }
                    else
                    {
                        namespaceStr = "namespace " + NameSpaceTextContent + ";";
                    }
                    if (!File.Exists(filePath))
                    {
                        File.WriteAllText(filePath, namespaceStr + "\n\n" + item.Value);
                    }
                }
            }
        }

        private void SaveSingleFileMethod(object obj)
        {
            if (!string.IsNullOrEmpty(ToCSharpTextContent))
            {
                string thisClassPath = FileExtention.GetThisFilePath();
                string thisClassDirectory = Path.GetDirectoryName(thisClassPath);
                // 获取上一级目录
                DirectoryInfo parentDirInfo = Directory.GetParent(thisClassDirectory);
                if (parentDirInfo == null)
                {
                    DialogHostIsOpen = true;
                    DialogHostMessage = "无法获取上一级目录";
                }
                string flieName = string.IsNullOrEmpty(ClassName) ? "Root" : ClassName;
                string directoryPath = parentDirInfo + @"\Models\ClashOfClans\";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = directoryPath + $"{flieName}.cs";

                File.WriteAllText(filePath, ToCSharpTextContent);
            }
        }

        private void ConverterCSharpMethod(object obj)
        {
            try
            {
                if (string.IsNullOrEmpty(JsonTextContent))
                {
                    DialogHostIsOpen = true;
                    DialogHostMessage = "Json字符串不能为空";
                    return;
                }
                else
                {
                    string message = "";
                    classStrs = JsonToClassGenerator.GenerateClass(JsonTextContent, string.IsNullOrEmpty(ClassName) ? "Root" : ClassName, out message);
                    if (message != string.Empty)
                    {
                        DialogHostMessage = message + "\n" + message + "\n" + message;
                        DialogHostIsOpen = true;
                        return;
                    }
                    string classStr = string.Empty;
                    foreach (var item in classStrs)
                    {
                        classStr += item.Value + "\n";
                    }
                    if (!string.IsNullOrEmpty(NameSpaceTextContent))
                    {
                        string namespaceStr = string.Empty;
                        if (NameSpaceTextContent.StartsWith("namespace") && NameSpaceTextContent.EndsWith(";"))
                        {
                            namespaceStr = NameSpaceTextContent;
                        }
                        else
                        {
                            namespaceStr = "namespace " + NameSpaceTextContent + ";";
                        }
                        ToCSharpTextContent = namespaceStr + "\n\n" + classStr;
                    }
                    else
                    {
                        ToCSharpTextContent = classStr;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogHostIsOpen = true;
                DialogHostMessage = ex.Message;
            }
        }

    }
}
