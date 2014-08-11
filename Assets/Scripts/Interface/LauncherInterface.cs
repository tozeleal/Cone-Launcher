using UnityEngine;
using System.Collections;

public class LauncherInterface : Interface {

	public static string selection = "MenuItem";

	// Update is called once per frame
	public override void OnGUI () {
		base.OnGUI ();

		switch (selection.ToLower()) {
			case "app":
				OnAppSelected();
			break;
			case "menuitem":
				OnMenuItemSelected();
			break;
		}
	}

	void OnAppSelected() {
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;
		// GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.885f, Screen.width * 0.35f, Screen.width * 0.05f),
		//         "FPS = " + FramerateCounter.Fps);
		
		GUI.Box (new Rect (Screen.width * 0.275f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.325f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.425f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.475f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.rate.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.575f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.625f, Screen.height * 0.885f, Screen.width * 0.2f, Screen.width * 0.05f),
		         Settings.lang.unstall.ToUpper());
	}

	void OnMenuItemSelected() {
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		GUI.Box (new Rect (Screen.width * 0.425f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.475f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
	}
}
