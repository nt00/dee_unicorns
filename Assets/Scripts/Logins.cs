using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

public class Logins : MonoBehaviour
{
    public string username = "username";
    public string password = "password";
    public string email = "email";
    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username,password,email));
    }
    public void LoginButton()
    {
        StartCoroutine(LoginToDB(username, password));
    }
    IEnumerator CreateUser(string userName, string passWord, string eMail)
    {
        string createUserURL = "localhost/unicorns_dee/InsertUser.php";

        WWWForm userInfo = new WWWForm();
        userInfo.AddField("usernamePost", userName);
        userInfo.AddField("passwordPost", passWord);
        userInfo.AddField("emailPost", eMail);
        WWW www = new WWW(createUserURL, userInfo);

        yield return www;

        Debug.Log(www.text);
    }

    IEnumerator LoginToDB(string username, string password)
    {
        string loginURL = "localhost/unicorns_dee/Login.php";
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("usernamePost", username);
        loginForm.AddField("passwordPost", password);
        WWW www = new WWW(loginURL, loginForm);

        yield return www;

        Debug.Log(www.text);
        if(www.text == "Login Success")
        {
            //playerAccount = true;
        }

    }

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(email);
        mail.Subject = "Password Reset";
        mail.Body = "Hello User \n\nYou done did fucked \nReset password here... :)";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 25;
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors errors) { return true; };
        smtpServer.Send(mail);

        Debug.Log("Success");
    }
}
