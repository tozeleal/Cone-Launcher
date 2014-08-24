using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

public class AppList : MonoBehaviour {
	public static FileInfo[] apps;
	public static List<Texture> appIcons;

	public static List<string> GetAppList(){
		/* DirectoryInfo appDir = new DirectoryInfo ("/data/app/");

		apps = appDir.GetFiles();

		foreach (FileInfo app in apps) {
			if (app.Extension.ToLower().Equals(".apk")) {
				
			}
		} */

		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

		AndroidJavaObject mainIntent = new AndroidJavaObject ("Intent", "Intent.ACTION_MAIN", null);
		mainIntent.Call ("addCategory", "Intent.CATEGORY_LAUNCHER");
		mainIntent.Call ("addCategory", "tv.ouya.intent.category.GAME");
		List<AndroidJavaObject> resolvedInfos = packageManager.Call<List<AndroidJavaObject>>("queryIntentActivities",mainIntent, 0);

		AndroidJavaObject resources = new AndroidJavaObject ("Resources");

		foreach (AndroidJavaObject resolvedInfo in resolvedInfos) {
			// TODO Fix line 78 from BAXY Launcher's MakeImageCache.java
			// resources = packageManager.Call<AndroidJavaObject>("getResourcesForApplication", resolvedInfo);

			// TODO Get the real package name
			// AndroidJavaObject fileOutputStream = new AndroidJavaObject("FileOutputStream", "/sdcard/BAXY/thumbnails/" + packageName + ".png");
		}

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
