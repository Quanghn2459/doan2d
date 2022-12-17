using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;
using System.IO.Enumeration;
using UnityEditor;

public class imex : MonoBehaviour
{
    string filename = "";
    public TMP_InputField username_in;
    public TMP_InputField password_in;
    public TMP_InputField phone_in;
    public GameObject username_popup;
    public GameObject password_popup;
    public GameObject phone_popup;
    public GameObject button;

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

    void Start()
    {
        filename = Application.dataPath + "listofuser.csv";
        ReadCSV();
        GetComponent<TMP_InputField>();
    }

    public void WriteCSV()
    {
        if (username_popup.activeSelf || password_popup.activeSelf || phone_popup.activeSelf)
        {
            EditorUtility.DisplayDialog("ERROR", "Please check again the requirements for creating an account", "OK");
        }
        else
        {
            ReadCSV();
            TextWriter tw = new StreamWriter(filename, true);
            if (userlist.user.Length != 0 && CheckExisted() == true)
            {
                EditorUtility.DisplayDialog("ERROR", "Your username has existed!", "OK");
                tw.Close();
            }
            else
            {
                tw.WriteLine(username_in.text + "," + password_in.text);
                tw.Close();
                EditorUtility.DisplayDialog("Notification", "Your account has been created!", "OK");
                SceneManager.LoadScene("MainMenu");
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

    bool CheckExisted()
    {
        for (int i = 0; i < userlist.user.Length; i++)
        {
            if (username_in.text == userlist.user[i].username)
            {
                return true;
            }
        }
        return false;
    }

    public void CheckUsername()
    {
        if (username_in.text.Length > 8)
        {
            username_popup.SetActive(false);
        }
        else
        {
            username_popup.SetActive(true);
        }
    }

    public void CheckPhoneNumber()
    {
        if (phone_in.text.Length == 10)
        {
            phone_popup.SetActive(false);
        }
        else
        {
            phone_popup.SetActive(true);
        }
    }

    public void CheckPassword()
    {
        int valid = 0;
        char[] special = { '@', '$', '#', '%' };
        foreach (char c in password_in.text)
        {
            if (c >= 'a' && c <= 'z')
            {
                valid++;
                break;
            }
        }
        foreach (char c in password_in.text)
        {
            if (c >= 'A' && c <= 'Z')
            {
                valid++;
                break;
            }
        }
        foreach (char c in password_in.text)
        {
            if (c >= '0' && c <= '9')
            {
                valid++;
                break;
            }
        }
        foreach (char c in password_in.text)
        {
            for (int i = 0; i < special.Length; i++)
            {
                if (c == special[i])
                {
                    valid++;
                    break;
                }
            }
        }
        if (valid == 4)
        {
            password_popup.SetActive(false);
        }
        else
        {
            password_popup.SetActive(true);
        }
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
