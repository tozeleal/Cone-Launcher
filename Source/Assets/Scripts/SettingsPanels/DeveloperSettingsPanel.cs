using UnityEngine;
using System.Collections;

public class DeveloperSettingsPanel : SettingsPanel {

	public override string Title
	{
		get {
			return Settings.lang.developer;
		}
	}

	public override void Do () {
		if (InputManager.GetButtonDown("o", 0)) {
			if (Settings.developer)
				Settings.developer = false;
			else
				Settings.developer = true;
		}
	}

	// Update is called once per frame
	public override void Draw () {
		base.Draw ();

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);
		Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1);

		GUI.Box (new Rect (Screen.width * 0.41f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.width * 0.05f),
		         (Settings.developer) ? "DEVELOPER OPTIONS: ON" : "DEVELOPER OPTIONS: OFF");

		// Show Tooltips
		Interface.Tooltip(Settings.lang.select, Settings.oButton, 0.35f);
		Interface.Tooltip(Settings.lang.back, Settings.aButton, 0.55f);
	}
}
