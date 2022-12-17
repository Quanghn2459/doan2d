using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignIn : MonoBehaviour
{
    string filename = "";
    public TMP_InputField username_in;
    public TMP_InputField password_in;
    [System.Serializable]
    public class User
    {
        public string username;
        public string password;
    }

    [System.Serializable]
    public class Userlist
    {
        public User[] user;
    }
    public Userlist userlist = new Userlist();
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "listofuser.csv";
        ReadCSV();
        GetComponent<TMP_InputField>();
    }

    public void CheckRight()
    {
        bool isAccount = false;
        bool isPassword = false;
        ReadCSV();
        int a = -1;
        for (int i = 0; i < userlist.user.Length; i++)
        {
            if (username_in.text == userlist.user[i].username)
            {
                isAccount = true;
                a = i;
                break;
            }
        }

        if (isAccount == false)
        {
            EditorUtility.DisplayDialog("Error", "Your username is not existed", "OK");
        }
        else
        {
            if (password_in.text + '\r' == userlist.user[a].password && a != -1)
            {
                isPassword = true;
            }
            else
                EditorUtility.DisplayDialog("Error", "Your password is wrong", "OK");

            if (isPassword == true && isAccount == true)
            {
                SceneManager.LoadScene("SignIn");
            }
        }
    }

    public void ReadCSV()
    {
        TextReader tr = new StreamReader(filename, true);
        string[] data = tr.ReadToEnd().Split(',', '\n');
        int tablesize = (data.Length - 1) / 2;
        userlist.user = new User[tablesize];
        for (int i = 0; i < tablesize; i++)
        {
            userlist.user[i] = new User();
            userlist.user[i].username = data[2 * i];
            userlist.user[i].password = data[2 * i + 1];
        }
        tr.Close();
    }

    public void TogglePass()
    {
        if (password_in.contentType == TMP_InputField.ContentType.Password)
        {
            password_in.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            password_in.contentType = TMP_InputField.ContentType.Password;
        }
        password_in.ForceLabelUpdate();
    }
}
