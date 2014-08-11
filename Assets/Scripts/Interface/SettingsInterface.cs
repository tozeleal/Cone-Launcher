using UnityEngine;
using System.Collections;

public class SettingsInterface : Interface {
	void OnGUI() {
		base.OnGUI ();
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		GUI.Box (new Rect (Screen.width * 0.15f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.2f, Screen.height * 0.885f, Screen.width * 0.15f, Screen.width * 0.05f),
		         Settings.lang.connect.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.aButton);
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.885f, Screen.width * 0.06f, Screen.width * 0.05f),
		         Settings.lang.back.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.55f, Screen.height * 0.885f, Screen.width * 0.25f, Screen.width * 0.05f),
		         Settings.lang.options.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.7f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.75f, Screen.height * 0.885f, Screen.width * 0.25f, Screen.width * 0.05f),
		         Settings.lang.rescan.ToUpper());
		
		Settings.guiSkin.box.fontSize = Settings.guiSkin.box.fontSize * 2;
		
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.15f, Screen.width * 0.3f, Screen.width * 0.05f),
		         Settings.lang.settings.ToUpper());
		
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);
		
		foreach(string s in Settings.settings) {
			GUI.Box (new Rect (Screen.width * 0.06f, Screen.height * 0.25f + Screen.height * 0.075f * Settings.settings.IndexOf(s), Screen.width * 0.25f, Screen.width * 0.05f),
			         s.ToUpper());
		}
		
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Settings.guiSkin.box.fontSize / 4 * 3);
	}
}
