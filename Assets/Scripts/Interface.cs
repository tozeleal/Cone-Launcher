using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour, OuyaSDK.IFetchGamerInfoListener {

	public static string userName = "'_'";

	public GameObject init;

	IEnumerator Start () {
		if (Settings.aButton == null)
			Instantiate (init);

		OuyaSDK.registerFetchGamerInfoListener(this);

		Application.targetFrameRate = 60;

		yield return new WaitForSeconds (0.5f);

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
		Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, .75f);
		
		OuyaSDK.fetchGamerInfo();

		yield return null;
	}

	void OnDestroy()
	{
		OuyaSDK.unregisterFetchGamerInfoListener(this);
	}

	void OnGUI() {
		GUI.skin = Settings.guiSkin;

		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.width* 0.035f, Screen.width * 0.35f, Screen.width * 0.045f),
		         Settings.lang.hello.ToUpper() + userName.ToUpper() + "!");

		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.885f, Screen.width * 0.35f, Screen.width * 0.05f),
		         "FPS = " + FramerateCounter.Fps);

		GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.oButton);
		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.open.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.45f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.uButton);
		GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         Settings.lang.rate.ToUpper());
		
		GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         Settings.yButton);
		GUI.Box (new Rect (Screen.width * 0.65f, Screen.height * 0.885f, Screen.width * 0.2f, Screen.width * 0.05f),
		         Settings.lang.unstall.ToUpper());

		Settings.guiSkin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.width* 0.035f, Screen.width * 0.2f, Screen.width * 0.045f),
		         System.DateTime.Now.ToString("HH:mm"));

		GUI.Box (new Rect (Screen.width * 0.8f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         Settings.ouyaLogo);
	}

	// OUYA Stuff
	public void OuyaFetchGamerInfoOnSuccess(string gamerUUID, string gamerUserName)
	{
		userName = gamerUserName;
	}
	
	public void OuyaFetchGamerInfoOnFailure(int errorCode, string errorMessage)
	{
		userName = System.Reflection.MethodBase.GetCurrentMethod().ToString();
	}
	
	public void OuyaFetchGamerInfoOnCancel()
	{
		userName = System.Reflection.MethodBase.GetCurrentMethod().ToString();
	}
}
