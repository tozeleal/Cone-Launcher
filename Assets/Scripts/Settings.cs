using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settings : MonoBehaviour {
	public Texture oButtonPublic;
	public Texture uButtonPublic;
	public Texture yButtonPublic;
	public Texture aButtonPublic;
	public Texture ouyaLogoPublic;
	
	public GUISkin guiSkinPublic;

	public static Texture oButton;
	public static Texture uButton;
	public static Texture yButton;
	public static Texture aButton;
	public static Texture ouyaLogo;

	public static GUISkin guiSkin;

	public static List<string> settings = new List<string>();

	public static Language lang = new Language();

	void Start () {
		oButton = oButtonPublic;
		uButton = uButtonPublic;
		yButton = yButtonPublic;
		aButton = aButtonPublic;
		ouyaLogo = ouyaLogoPublic;
		guiSkin = guiSkinPublic;

		lang = SetLanguage("dutch");

		settings.Add (lang.wifi);
		settings.Add(lang.bluetooth);
		settings.Add(lang.screen);
		settings.Add(lang.wallpaper);
		settings.Add(lang.account);
		settings.Add(lang.language);
		settings.Add(lang.developer);
		settings.Add(lang.updates);

		guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
	}

	public Language SetLanguage(string language) {
		switch (language.ToLower()) {
			case "dutch":
				return new LanguageDutch();
			break;
			case "french":
				return new LanguageFrench();
			break;
			default:
				return new Language();
			break;
		}
	}
}
