using BusinessLogicDomain.Abstract;
using System;
using System.Text;
using BusinessLogicDomain.Entities;
using System.Net.Mail;
using System.Net;

namespace BusinessLogicDomain.Concrete.Processor
{
    /// <summary>
    /// Класс EmailSetting содержит все настройки, 
    /// предназначенные для конфигурирования классов .NET
    /// </summary>
    public class EmailSetting
    {
        public String MailToAddress = "order@example.com";
        public String MailFromAddress = "bookstore@example.com";
        public Boolean UseSsl = true;
        public String UserName = "MySmtpUsername";
        public String Password = "MySmtpPassword";
        public String ServerName = "smtp.example.com";
        public UInt16 ServerPort = 587;
        public Boolean WriteAsFile = true;
        public String FileLocation = @"c:\book_store_emails";
    }

    /// <summary>
    /// Класс EmailOrderProcessor производит обработку заказов
    /// </summary>
    public class EmailOrderProcessor : IOrderProcessor
    {
        /// <summary>
        /// Настройка отправки заказов
        /// </summary>
        private EmailSetting emailSetting;

        public EmailOrderProcessor(EmailSetting settings)
        {
            emailSetting = settings;
        }

        public void ProcessOrder(Cart cart, SnippingDetails shippingDetails)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSetting.UseSsl;
                smtpClient.Host = emailSetting.ServerName;
                smtpClient.Port = emailSetting.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSetting.UserName, emailSetting.Password);

                if(emailSetting.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSetting.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Book.Price * line.Quantity;
                    body.AppendFormat($"{line.Quantity} x {line.Book.Name} (итого: {subtotal:c}");
                }

                body.AppendFormat($"Общая стоимость: {cart.ComputeTotalValue():c}")
                    .AppendFormat("---")
                    .AppendLine("Доставка:")
                    .AppendLine(shippingDetails.FirstName)
                    .AppendLine(shippingDetails.LastName)
                    .AppendLine(shippingDetails.LineOne)
                    .AppendLine(shippingDetails.LineTwo ?? "")
                    .AppendLine(shippingDetails.LineThree ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.Country)
                    .AppendFormat("---")
                    .AppendFormat("Подарочная упаковка: {0}", shippingDetails.GiftWrap ? "Да" : "Нет");

                MailMessage mailMessage = new MailMessage(
                    emailSetting.MailFromAddress,
                    emailSetting.MailToAddress,
                    "Новый заказ отправлен!",
                    body.ToString());
                if(emailSetting.WriteAsFile) mailMessage.BodyEncoding = Encoding.UTF8;

                smtpClient.Send(mailMessage);
            }
        }
    }
}