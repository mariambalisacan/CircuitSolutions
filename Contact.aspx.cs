using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CircuitSolutions
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            email.Attributes.Add("type", "email");
            fname.Attributes.Add("required", "required");
            lname.Attributes.Add("required", "required");
            email.Attributes.Add("required", "required");
            message.Attributes.Add("required", "required");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
            new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["ELASTICEMAIL"], "Circuit Solutions Website"),
            new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["RECEIVEREMAIL"]));//circuit solution's employee email
            m.Subject = "Email confirmation";
            m.Body = string.Format("This message is an inquiry from Circuit Solutions Website:<BR/>First Name: {0}<br>Last Name: {1}<br>Mobile: {2}<br>Email: {3}<br>Message: {4}",
            fname.Text,lname.Text,mobile.Text, email.Text, message.Text);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.elasticemail.com");
            smtp.Port = 2525;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["ELASTICUSERNAME"], ConfigurationManager.AppSettings["ELASTICPASSWORD"]);
            smtp.EnableSsl = true;
            smtp.Send(m);

        }


    }
}