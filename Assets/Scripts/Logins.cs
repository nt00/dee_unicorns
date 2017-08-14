using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public string code = "code";
    public string confirmPassword = "confirmpasword";

    public InputField usernameInput, passwordInput, emailInput, loginUsernameInput, loginPasswordInput, forgotEmailInput, pwResetInput, newPasswordInput, confirmPasswordInput;

    public bool showLogin, showCreateAcc, showForgotPw, showPwReset, showNewPassword;
    public GameObject login, createAcc, forgotPw, pwReset, newPasswordScreen;

    void Start()
    {
        login.SetActive(true);
    }

    void Update()
    {
        if(showLogin)
        {
            if (loginUsernameInput.text != username)
            {
                username = loginUsernameInput.text;
            }
            if (loginPasswordInput.text != password)
            {
                password = loginPasswordInput.text;
            }
          
        }
        if(showCreateAcc)
        {
            if (usernameInput.text != username)
            {
                username = usernameInput.text;
            }
            if (passwordInput.text != password)
            {
                password = passwordInput.text;
            }
            if (emailInput.text != email)
            {
                email = emailInput.text;
            }
        }
        if(showForgotPw)
        {
            if (forgotEmailInput.text != email)
            {
                email = forgotEmailInput.text;
            }
        }
        if(showPwReset)
        {
            if(pwResetInput.text != code)
            {
                code = pwResetInput.text;
            }
        }
       if(showNewPassword)
        {
            if(newPasswordInput.text != password)
            {
                password = newPasswordInput.text;
            }
            if(confirmPasswordInput.text != confirmPassword)
            {
                confirmPassword = confirmPasswordInput.text;
            }
        }
       
    }

    public void ShowCreateAcc()
    {
        showCreateAcc = true;
        showForgotPw = false;
        showLogin = false;
        showPwReset = false;
        showNewPassword = false;
        createAcc.SetActive(true);
        forgotPw.SetActive(false);
        login.SetActive(false);
        pwReset.SetActive(false);
        newPasswordScreen.SetActive(false);
    }

    public void ShowLogin()
    {
        showLogin = true;
        showCreateAcc = false;
        showForgotPw = false;
        showPwReset = false;
        showNewPassword = false;
        login.SetActive(true);
        forgotPw.SetActive(false);
        createAcc.SetActive(false);
        pwReset.SetActive(false);
        newPasswordScreen.SetActive(false);
    }

    public void ShowForgotPw()
    {
        showForgotPw = true;
        showLogin = false;
        showCreateAcc = false;
        showPwReset = false;
        showNewPassword = false;
        forgotPw.SetActive(true);
        pwReset.SetActive(false);
        newPasswordScreen.SetActive(false);
        login.SetActive(false);
        createAcc.SetActive(false);
    }

    public void ShowPwReset()
    {
        showPwReset = true;
        showForgotPw = false;
        showLogin = false;
        showCreateAcc = false;
        showNewPassword = false;
        pwReset.SetActive(true);
        newPasswordScreen.SetActive(false);
        forgotPw.SetActive(false);
        login.SetActive(false);
        createAcc.SetActive(false);
    }

    public void ShowNewPassword()
    {
        showNewPassword = true;
        showPwReset = false;
        showForgotPw = false;
        showLogin = false;
        showCreateAcc = false;
        newPasswordScreen.SetActive(true);
        pwReset.SetActive(false);
        forgotPw.SetActive(false);
        login.SetActive(false);
        createAcc.SetActive(false);

    }

    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username,password,email));
    }
    public void LoginButton()
    {
        StartCoroutine(LoginToDB(username, password));
    }

    public void GetUserButton()
    {
        StartCoroutine(GetUser(email));
    }

    public void ChangePasswordButton()
    {
        StartCoroutine(UpdatePassword(email, password));
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
    IEnumerator GetUser(string email)
    {
        string getUserName = "localhost/unicorns_dee/CheckUser.php";
        WWWForm getUserForm = new WWWForm();
        getUserForm.AddField("emailPost",email);
        WWW www = new WWW(getUserName, getUserForm);
        yield return www;
        Debug.Log(www.text);
        if(www.text != "No User")
        {
            username = www.text;
            SendEmail();
            //Invoke("SendEmail", 0);
        }
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
    public void SendEmail()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(email);
        mail.Subject = "Password Reset";
        mail.Body = "Hello " + username + "\n\nYou done did fucked \nReset password here... :)";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 25;
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors errors) { return true; };
        smtpServer.Send(mail);

        Debug.Log("Success");
    }

    IEnumerator UpdatePassword(string eMail, string passWord)
    {
        string PasswordURL = "localhost/unicorns_dee/UpdatePassword.php";
        WWWForm passwordForm = new WWWForm();
        passwordForm.AddField("emailPost", eMail);
        passwordForm.AddField("passwordPost", passWord);
        WWW www = new WWW(PasswordURL, passwordForm);

        yield return www;
        Debug.Log(www.text);
        if (www.text != "error")
        {
            showPwReset = false;
            showNewPassword = false;
            showForgotPw = false;
            showLogin = true;
        }
    }
}
