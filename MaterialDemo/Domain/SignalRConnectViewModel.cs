using MaterialDemo.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;

namespace MaterialDemo.Domain
{
    public class SignalRConnectViewModel : ViewModelBase
    {
        private HubConnection? hubConnection;
        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
        public SignalRConnectViewModel()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string userId = configuration.GetSection("user:userId").Value is null ? "0" : configuration.GetSection("user:userId").Value;
            string name = configuration.GetSection("user:name").Value;

            //hubConnection = new HubConnectionBuilder()
            //    .WithUrl("https://localhost:7223/chathub", options =>
            //    {
            //        // 设置用户ID
            //        options.Headers.Add(userId, name);
            //    }) // 设置服务器地址
            //    .WithAutomaticReconnect() // 自动重连
            //    .Build();

            //// 注册接收消息的回调
            //hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    var encodedMsg = $"{user}: {message}";
            //    MessagesList.Add(new MessageItem()
            //    {
            //        SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
            //        MessageContent = encodedMsg,
            //        IsFromMe = false
            //    });
            //    OnPropertyChanged(nameof(MessagesList));
            //    OnPropertyChanged(nameof(MessageContent));
            //});

            //// 启动连接
            //hubConnection.StartAsync().ContinueWith(task =>
            //{
            //    if (task.IsFaulted)
            //    {
            //        MessageBox.Show("连接失败: " + task.Exception.GetBaseException().Message);
            //    }
            //});


            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://81.68.127.231:8081/chathub")
            .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                Application.Current.Dispatcher.InvokeAsync(() => { MessagesList.Add(new MessageItem() { IsFromMe = false, MessageContent = encodedMsg, SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4" }); });
                
            });

            hubConnection.StartAsync();

            SendMessage = new AsyncCommand(SendMessageMethod);
            //SendMessage = new RelayCommand(SendMessageMethod);

            MessagesList = new ObservableCollection<MessageItem>()
            {
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Hello, how are you?",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "I'm fine, thank you!",
                    IsFromMe = false
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "What about you?",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "I'm doing great, thanks for asking!",
                    IsFromMe = false
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.",
                    IsFromMe = true
                },
                new MessageItem(){
                    SenderAvatar = "https://avatars.githubusercontent.com/u/75834079?v=4",
                    MessageContent = "Let's catch up sometime.\nLet's catch up sometime.\nLet's catch up sometime.\nLet's catch up sometime.\nLet's catch up sometime.\nLet's catch up sometime.\n",
                    IsFromMe = true
                },
            };
        }

        private void SendMessageMethod(object obj)
        {
            if (!string.IsNullOrWhiteSpace(MessageContent))
            {
                try
                {
                    hubConnection.SendAsync("SendMessage", "0", MessageContent);
                    MessageContent = string.Empty; // 清空输入框
                    OnPropertyChanged(nameof(MessagesList));
                    OnPropertyChanged(nameof(MessageContent));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送失败: " + ex.Message);
                }
            }
        }

        private async Task SendMessageMethod()
        {
            if (!string.IsNullOrWhiteSpace(MessageContent))
            {
                try
                {
                    if (hubConnection is not null)
                    {
                        await hubConnection.SendAsync("SendMessage", "0", MessageContent);

                        MessageContent = string.Empty; // 清空输入框

                        OnPropertyChanged(nameof(MessageContent));
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送失败: " + ex.Message);
                }
            }
        }

        private string _messageContent;
        public string MessageContent
        {
            get { return _messageContent; }
            set
            {
                _messageContent = value;
                SetProperty(ref _messageContent, value);
            }
        }

        private ObservableCollection<MessageItem> _messagesList;
        public ObservableCollection<MessageItem> MessagesList
        {
            get { return _messagesList; }
            set
            {
                _messagesList = value;
                SetProperty(ref _messagesList, value);
            }
        }
        public string _currentChatObjectName = "当前聊天对象";
        public string CurrentChatObjectName
        {
            get { return _currentChatObjectName; }
            set
            {
                _currentChatObjectName = value;
                SetProperty(ref _currentChatObjectName, value);
            }
        }

        public ICommand SendMessage { get; }
    }
}
