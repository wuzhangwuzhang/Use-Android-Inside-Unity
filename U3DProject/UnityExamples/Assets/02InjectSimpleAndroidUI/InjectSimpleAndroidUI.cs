﻿using UnityEngine;
using System.Collections;

public class InjectSimpleAndroidUI : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Android function is to be called");

            var ajc = new AndroidJavaClass("com.example.xyz.uihelper.Utils");

            AndroidJavaObject activity = GetAndroidActivity();
            Debug.Log(activity==null? "Android Activity found": "NULL activity");
            var output = ajc.CallStatic<object>("AddImageView", activity,  0, 0); 
            Debug.Log(output);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static AndroidJavaObject GetAndroidActivity()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        return jo;
    }
}
