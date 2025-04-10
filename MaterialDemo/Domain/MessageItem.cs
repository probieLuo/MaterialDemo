using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDemo.Domain
{
    public class MessageItem
    {
        public string SenderAvatar { get; set; } // 发送者头像
        public string MessageContent { get; set; } // 消息内容
        public bool IsFromMe { get; set; } // 是否来自自己
    }
}
