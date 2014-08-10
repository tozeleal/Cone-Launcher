using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {
	public GameObject settings;

	IEnumerator Start () {
		if (Settings.aButton == null) {
			Instantiate (settings);
			yield return new WaitForSeconds (0.5f);
		}

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
		Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, .75f);

		yield return null;
	}


	public virtual void OnGUI() {
		GUI.skin = Settings.guiSkin;

		TopBar ();
	}

	public static void TopBar() {
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.width* 0.035f, Screen.width * 0.35f, Screen.width * 0.045f),
		         Settings.lang.hello.ToUpper() + Settings.userName.ToUpper() + "!");

		Settings.guiSkin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.width* 0.035f, Screen.width * 0.2f, Screen.width * 0.045f),
		         System.DateTime.Now.ToString("HH:mm"));
		
		GUI.Box (new Rect (Screen.width * 0.8f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         Settings.ouyaLogo);
	}
}
