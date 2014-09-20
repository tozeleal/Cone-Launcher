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

		// Draw Tooltips
		Tooltip(Settings.lang.open, Settings.oButton, 0.275f);
		Tooltip(Settings.lang.rate, Settings.uButton, 0.425f);
		Tooltip(Settings.lang.unstall, Settings.yButton, 0.575f);
	}

	void OnMenuItemSelected() {
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		Tooltip(Settings.lang.open, Settings.oButton, 0.425f);
	}
}
