using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour, OuyaSDK.IFetchGamerInfoListener {

	public Texture oButton;
	public Texture uButton;
	public Texture yButton;
	public Texture aButton;

	public Texture ouyaLogo;

	public GUISkin guiSkin;

	public static string userName = "Loading";

	private float xPos;

	void Awake () {
		OuyaSDK.registerFetchGamerInfoListener(this);

		StartCoroutine (Prepare ());

		guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
	}

	IEnumerator Prepare() {
		yield return new WaitForSeconds (1);
		OuyaSDK.fetchGamerInfo();

		Application.targetFrameRate = 60;
	}

	void OnDestroy()
	{
		OuyaSDK.unregisterFetchGamerInfoListener(this);
	}
	
	void OnGUI() {
		GUI.skin = guiSkin;

		guiSkin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.width* 0.035f, Screen.width * 0.35f, Screen.width * 0.045f),
		         "Hi, " + userName.ToUpper() + "!");

		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.885f, Screen.width * 0.35f, Screen.width * 0.05f),
		         "FPS = " + FramerateCounter.Fps);


		GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         oButton);
		GUI.Box (new Rect (Screen.width * 0.35f, Screen.height * 0.885f, Screen.width * 0.07f, Screen.width * 0.05f),
		         "OPEN");
		
		GUI.Box (new Rect (Screen.width * 0.45f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         uButton);
		GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.885f, Screen.width * 0.06f, Screen.width * 0.05f),
		         "RATE");
		
		GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.885f, Screen.width * 0.05f, Screen.width * 0.05f),
		         yButton);
		GUI.Box (new Rect (Screen.width * 0.65f, Screen.height * 0.885f, Screen.width * 0.1f, Screen.width * 0.05f),
		         "UNSTALL");

		guiSkin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Box (new Rect (Screen.width * 0.4f, Screen.width* 0.035f, Screen.width * 0.2f, Screen.width * 0.045f),
		         System.DateTime.Now.ToString("HH:mm"));

		GUI.Box (new Rect (Screen.width * 0.8f, Screen.width* 0.035f, Screen.width * 0.15f, Screen.width * 0.045f),
		         ouyaLogo);
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
