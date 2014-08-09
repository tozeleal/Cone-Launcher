using UnityEngine;
using System.Collections;

public class Wifi : MonoBehaviour {

	public Texture oButton;
	public Texture uButton;
	public Texture yButton;
	public Texture aButton;

	public Texture ouyaLogo;

	public GUISkin guiSkin;

	void Start () {
		guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
	}

	void OnGUI() {
		GUI.skin = guiSkin;

		// Top Bar
		guiSkin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         "Hi, coen22!");

		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         oButton);
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.885f, Screen.width * 0.15f, Screen.width * 0.05f),
		         "CONNECT");
		
		GUI.Box (new Rect (Screen.width * 0.55f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         aButton);
		GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.885f, Screen.width * 0.06f, Screen.width * 0.05f),
		         "BACK");

		guiSkin.box.fontSize = guiSkin.box.fontSize * 2;
		
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.15f, Screen.width * 0.15f, Screen.width * 0.05f),
		         "WIFI");
		
		guiSkin.box.fontSize = Mathf.RoundToInt(guiSkin.box.fontSize / 1.5f);


		GUI.Box (new Rect (Screen.width * 0.06f, Screen.height * 0.25f, Screen.width * 0.45f, Screen.width * 0.05f),
		         "ZiggoD6O44				CONNECTED");


		GUI.color = new Color (1, 0.16470588f, 0);
		GUI.Box (new Rect (Screen.width * 0.06f, Screen.height * 0.325f, Screen.width * 0.45f, Screen.width * 0.05f),
		         "Ziggo");
		GUI.color = new Color (1, 1, 1);

		GUI.Box (new Rect (Screen.width * 0.06f, Screen.height * 0.4f, Screen.width * 0.45f, Screen.width * 0.05f),
		         "Default");

		guiSkin.box.fontSize = Mathf.RoundToInt(guiSkin.box.fontSize / 4 * 3);

		guiSkin.box.alignment = TextAnchor.MiddleCenter;

		GUI.Box (new Rect (Screen.width * 0.4f, Screen.width* 0.035f, Screen.width * 0.2f, Screen.width * 0.045f),
		         System.DateTime.UtcNow.ToString("HH:mm"));

		GUI.Box (new Rect (Screen.width * 0.8f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         ouyaLogo);
	}
}
