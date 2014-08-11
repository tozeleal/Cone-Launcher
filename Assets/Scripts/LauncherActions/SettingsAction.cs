using UnityEngine;
using System.Collections;

public class SettingsAction : LauncherAction {

	public override void OnO () {
		Application.LoadLevel("Settings");
	}
}
