using UnityEngine;
using System.Collections;

public class SettingsAction : Action {

	public override void OnO () {
		StartCoroutine( LauncherInterface.Zoom ());
		StartCoroutine (WaitTransitionO ());
	}

	IEnumerator WaitTransitionO() {
		while (LauncherInterface.zoomSelectedItem) {
			yield return null;	
		}

		Application.LoadLevel("Settings");
	}
}
