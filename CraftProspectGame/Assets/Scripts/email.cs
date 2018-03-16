using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using UnityEngine.SceneManagement;

/**
 * Email sends the responses to the customer's email
 */
public class email : MonoBehaviour {

	public void sendEmail (string scene){
		MailMessage mail = new MailMessage();

		mail.From = new MailAddress ("neuralnavigate@gmail.com");
		mail.To.Add("game@craftprospect.com");
		mail.Subject = "Test Mail";

		string path = @"MyTest.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);
		string body = reader.ReadToEnd();
		reader.Close();
		mail.Body = body;

		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("neuralnavigate@gmail.com", "andlong5") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback =
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{ return true; };
		smtpServer.Send(mail);
		SceneManager.LoadScene (scene);

	}
}
