using UnityEngine;
using System.Collections;

public class LauncherInterface : Interface {
	
	// Update is called once per frame
	void OnGUI () {
		base.OnGUI ();

		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.885f, Screen.width * 0.35f, Screen.width * 0.05f),
		         "FPS = " + FramerateCounter.Fps);
		
		GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.45f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.rate.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.65f, Screen.height * 0.885f, Screen.width * 0.2f, Screen.width * 0.05f),
		         Settings.lang.unstall.ToUpper());
	}
}
