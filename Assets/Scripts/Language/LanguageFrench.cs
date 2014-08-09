using UnityEngine;
using System.Collections;

public class LanguageFrench : Language {
	
	public override string hello
	{
		get {
			return "salut, ";
		}
	}

	public override string settings
	{
		get {
			return "paramètres";
		}
	}

	public override string wifi
	{
		get {
			return "wifi";
		}
	}
	
	public override string bluetooth
	{
		get {
			return "bluetooth";
		}
	}
	
	public override string screen
	{
		get {
			return "ecran";
		}
	}
	
	public override string wallpaper
	{
		get {
			return "papier peint";
		}
	}
	
	public override string account
	{
		get {
			return "compte";
		}
	}
	
	public override string language
	{
		get {
			return "language";
		}
	}
	
	public override string developer
	{
		get {
			return "développeur";
		}
	}
	
	public override string updates
	{
		get {
			return "des mises à jour";
		}
	}
}
