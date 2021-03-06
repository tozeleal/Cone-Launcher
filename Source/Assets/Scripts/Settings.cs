﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settings : MonoBehaviour, OuyaSDK.IFetchGamerInfoListener {
	public Texture oButtonPublic;
	public Texture uButtonPublic;
	public Texture yButtonPublic;
	public Texture aButtonPublic;
	public Texture ouyaLogoPublic;

	public Texture wallpaperPublic;

	public GUISkin guiSkinPublic;

	public static Texture oButton;
	public static Texture uButton;
	public static Texture yButton;
	public static Texture aButton;
	public static Texture ouyaLogo;

	public static GUISkin guiSkin;

	public static List<string> settings = new List<string>();

	// Settings (yes, the actual user settings)
	public static Language lang;
	public static string userName = "'_'";
	public static Texture wallpaper;
	public static bool developer;

	IEnumerator Start () {
		oButton = oButtonPublic;
		uButton = uButtonPublic;
		yButton = yButtonPublic;
		aButton = aButtonPublic;
		ouyaLogo = ouyaLogoPublic;
		guiSkin = guiSkinPublic;
		wallpaper = wallpaperPublic;

		lang = SetLanguage("");

		settings.Add (lang.wifi);
		settings.Add(lang.bluetooth);
		settings.Add(lang.screen);
		settings.Add(lang.wallpaper);
		settings.Add(lang.account);
		settings.Add(lang.language);
		settings.Add(lang.developer);
		settings.Add(lang.updates);

		guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);

		OuyaSDK.registerFetchGamerInfoListener(this);
		yield return new WaitForSeconds (0.5f);
		OuyaSDK.fetchGamerInfo();
	}

	public static Language SetLanguage(string language) {
		switch (language.ToLower()) {
			case "dutch":
				return new LanguageDutch();
			break;
			case "french":
				return new LanguageFrench();
			break;
			case "german":
				return new LanguageGerman();
			break;
			case "italian":
				return new LanguageItalian();
			break;
			case "portuguese":
				return new LanguagePortuguese();
			break;
			case "spanish":
				return new LanguageSpanish();
			break;
			default:
				return new Language();
			break;
		}
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
	
	void OnDestroy()
	{
		OuyaSDK.unregisterFetchGamerInfoListener(this);
	}
}
