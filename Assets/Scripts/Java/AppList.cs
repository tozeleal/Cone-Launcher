using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AppList : MonoBehaviour {
	public static List<string> GetAppList(){
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

		//	new Intent(Intent.ACTION_MAIN, null);
		//mainIntent.addCategory(Intent.CATEGORY_LAUNCHER);
		//mainIntent.addCategory("tv.ouya.intent.category.GAME");
		//List<ResolveInfo> infos = ca.Call("startActivity",launchIntent);

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
