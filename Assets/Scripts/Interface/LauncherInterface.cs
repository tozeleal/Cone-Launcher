using UnityEngine;
using System.Collections;

public class LauncherInterface : Interface {

	public static string selection = "MenuItem";
	public static bool zoomSelectedItem;
	public float maxDistance = 5;
	public float lerpSpeed = 0.1f;

	private float curX;

	public void Update() {
		if (zoomSelectedItem)
			return;

		curX = TilesInterface.cursor.transform.position.x;
		if (transform.position.x < 0)
			curX = Mathf.Max (curX, 9);

		if (Mathf.Abs(curX - transform.position.x) > maxDistance) {
			transform.position += new Vector3((curX - transform.position.x) * lerpSpeed * Time.deltaTime,0,0);
		}

		float maxPos = TilesInterface.columns [TilesInterface.columns.Count - 1] [0].transform.position.x - 29;

		if (transform.position.x > maxPos) {
			transform.position = new Vector3 (maxPos,
			                                  transform.position.y,
			                                  transform.position.z);
		}
	}

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
		// GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.885f, Screen.width * 0.35f, Screen.width * 0.05f),
		//         "FPS = " + FramerateCounter.Fps);
		
		GUI.Box (new Rect (Screen.width * 0.275f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.325f, Screen.height * 0.875f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.425f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.475f, Screen.height * 0.875f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.rate.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.575f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.625f, Screen.height * 0.875f, Screen.width * 0.2f, Screen.width * 0.05f),
		         Settings.lang.unstall.ToUpper());
	}

	void OnMenuItemSelected() {
		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		GUI.Box (new Rect (Screen.width * 0.425f, Screen.height * 0.875f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.475f, Screen.height * 0.875f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
	}

	public static IEnumerator Zoom() {
		zoomSelectedItem = true;

		while (Camera.main.transform.position.x > -90) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position,
															new Vector3(-125, 0, Camera.main.transform.position.z),
															3 * Time.deltaTime);

			yield return null;
		}

		zoomSelectedItem = false;
	}
}
