using UnityEngine;
using System.Collections;

public class SettingsInterface : Interface {
	private int selectedMenuItem = 0;
	private bool axisDown = false;
	private float timer;

	void Update() {
		if (!axisDown) {
			if (InputManager.GetAxis ("Vertical", 0) > 0.5f) {
				if (selectedMenuItem > 0) {
					selectedMenuItem -= 1;
					StartCoroutine(DelayButtonPress());
				}
			} else if (InputManager.GetAxis ("Vertical", 0) < -0.5f) {
				if (selectedMenuItem < Settings.settings.Count - 1) {
					selectedMenuItem += 1;
					StartCoroutine(DelayButtonPress());
				}
			}
		}

		if (InputManager.GetButtonDown("a", 0)) {
			Application.LoadLevel("Launcher");
		}
	}

	void OnGUI() {
		base.OnGUI ();
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.875f, Screen.width * 0.15f, Screen.width * 0.05f),
		         Settings.lang.select.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.55f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.aButton);
		GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.875f, Screen.width * 0.06f, Screen.width * 0.05f),
		         Settings.lang.back.ToUpper());

		/*
		GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.55f, Screen.height * 0.885f, Screen.width * 0.25f, Screen.width * 0.05f),
		         Settings.lang.options.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.7f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.75f, Screen.height * 0.885f, Screen.width * 0.25f, Screen.width * 0.05f),
		         Settings.lang.rescan.ToUpper());
		*/

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.045f);
		
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.15f, Screen.width * 0.3f, Screen.width * 0.05f),
		         Settings.lang.settings.ToUpper());
		
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);



		foreach(string s in Settings.settings) {
			if (s == Settings.settings[selectedMenuItem]) {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1);
			} else {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.5f);
			}

			GUI.Box (new Rect (Screen.width * 0.06f, Screen.height * 0.25f + Screen.height * 0.075f * Settings.settings.IndexOf(s), Screen.width * 0.25f, Screen.width * 0.05f),
			         s.ToUpper());
		}

		Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.75f);
		
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Settings.guiSkin.box.fontSize / 4 * 3);
	}

	IEnumerator DelayButtonPress() {
		timer = 0.25f;
		axisDown = true;
		
		while (timer > 0) {
			timer -= Time.deltaTime;
			
			if (!axisDown)
				yield break;
			
			yield return null;
		}

		axisDown = false;
	}
}
