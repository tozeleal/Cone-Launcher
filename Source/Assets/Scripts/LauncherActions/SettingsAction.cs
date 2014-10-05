using UnityEngine;
using System.Collections;

public class SettingsAction : Action {

	public override void OnO () {
		StartCoroutine( TilesInterface.ScrollAway());
		StartCoroutine (WaitTransitionO ());
	}

	IEnumerator WaitTransitionO() {
		while (TilesInterface.zoomSelectedItem) {
			yield return null;	
		}

		Application.LoadLevel("Settings");
	}
}
