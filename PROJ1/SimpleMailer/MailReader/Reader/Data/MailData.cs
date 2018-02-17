namespace MailReader.Data
{
    public class MailData
    {
        public string Address { get; set; }
        public string Head { get; set; }
        public string Content { get; set; }


        public override string ToString()
        {
            return Address + ", " + Head + ", " + Content;
        }
    }
}