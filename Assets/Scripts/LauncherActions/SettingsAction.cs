using UnityEngine;
using System.Collections;

public class SettingsAction : Action {

	public override void OnO () {
		Application.LoadLevel("Settings");
	}
}
