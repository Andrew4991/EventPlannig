namespace EventPlannig.BLL.Interfaces
{
    public interface IEmailService
    {
        public void SendMail(string email, string title, string body);
    }
}
