using System.Collections.Generic;
using MailReader.Data;

namespace MailReader.Reader.Interface
{
    public interface IMailReader
    {
        List<MailData> Read();
    }
}