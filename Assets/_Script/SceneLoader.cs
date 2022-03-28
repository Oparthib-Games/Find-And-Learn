using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public InputField name;
    public Text fText;

    public void getset()
    {
        fText.text = "Hello, " + name.text;
    }

    public void doquit()
    {
        Application.Quit();
    }
    public void LoadScene(string scene_name)
    {
        Application.LoadLevel(scene_name);
        //if (subscriberApi.realTime.Second - DateTime.Now.Second <= 30)
        //{
        //    if(PlayerPrefs.GetInt("isSuccess") == 1)
        //    {
        //        Application.LoadLevel("Levels");
        //    }
        //    else
        //    {
        //        Application.LoadLevel("SubscriberSeen");
        //    }
        //}
        //else
        //{
        //    Application.LoadLevel("SubscriberSeen");
        //}
    }


}
