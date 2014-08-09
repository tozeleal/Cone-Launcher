using UnityEngine;
using System.Collections;

public class LanguageDutch : Language {
	
	public override string hello
	{
		get {
			return "hey, ";
		}
	}

	public override string settings
	{
		get {
			return "instellingen";
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
			return "scherm";
		}
	}
	
	public override string wallpaper
	{
		get {
			return "achtergrond";
		}
	}
	
	public override string account
	{
		get {
			return "account";
		}
	}
	
	public override string language
	{
		get {
			return "taal";
		}
	}
	
	public override string developer
	{
		get {
			return "ontwikkelaar";
		}
	}
	
	public override string updates
	{
		get {
			return "updates";
		}
	}
}
