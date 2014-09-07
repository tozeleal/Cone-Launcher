// #if UNITY_ANDROID && !UNITY_EDITOR

using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Android.Runtime;

public class AppList : MonoBehaviour {

	public static FileInfo[] apps;
	public static List<Texture> appIcons;

	public static List<string> GetAppList(){
		AndroidJavaClass apps = new AndroidJavaClass("");
		return apps.Call<List<string>>("getAppsList");

		return null;
	}

	public static void LaunchApp(string bundleID){
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

		//if the app is installed, no errors. Else, doesn't get past next line
		AndroidJavaObject launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",bundleID);
		
		ca.Call("startActivity",launchIntent);
	}
}
// #endif