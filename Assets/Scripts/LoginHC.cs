using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public string userName = "username";
    public string password = "password";

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        // Login Box
        GUI.Box(new Rect(4 * scrW, 3 * scrH, 8f * scrW, 2.5f * scrH), "Login");
        //username textfield
        userName = GUI.TextField(new Rect(8.5f * scrW, 4 * scrH, 3f * scrW, 0.3f * scrH), userName, 30);
        //password textfield
        password = GUI.PasswordField(new Rect(8.5f * scrW, 4.75f*scrH, 3f* scrW, 0.3f * scrH), password, "*"[0], 30);

    }


}
