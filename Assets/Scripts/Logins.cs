using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logins : MonoBehaviour
{
    public string username = "username";
    public string password = "password";
    public string email = "email";
    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username,password,email));
    }
    IEnumerator CreateUser(string userName, string passWord, string eMail)
    {
        string createUserURL = "localhost/unicorns_dee/InsertUser.php";

        WWWForm userInfo = new WWWForm();
        userInfo.AddField("usernamePost", userName);
        userInfo.AddField("passwordPost", userName);
        userInfo.AddField("emailPost", userName);
        WWW www = new WWW(createUserURL, userInfo);

        yield return www;

        Debug.Log(www.text);
    }
}
