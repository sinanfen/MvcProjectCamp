using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList();
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListUnread();
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
