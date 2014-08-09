using UnityEngine;
using System.Collections;

public class SettingsInterface : MonoBehaviour {
	void OnGUI() {
		GUI.skin = Settings.guiSkin;
		Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.75f);

		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		GUI.Box (new Rect (Screen.width * 0.05f, Screen.width* 0.035f, Screen.width * 0.25f, Screen.width * 0.045f),
		         Settings.lang.hello.ToUpper() + Interface.userName.ToUpper() + "!");
		
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
		
		Settings.guiSkin.box.alignment = TextAnchor.MiddleCenter;
		
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.width* 0.035f, Screen.width * 0.2f, Screen.width * 0.045f),
		         System.DateTime.Now.ToString("HH:mm"));
		
		GUI.Box (new Rect (Screen.width * 0.8f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         Settings.ouyaLogo);
	}
}
