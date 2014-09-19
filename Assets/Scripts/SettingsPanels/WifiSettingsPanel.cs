using UnityEngine;
using System.Collections;

public class WifiSettingsPanel : SettingsPanel {

	public override string Title
	{
		get {
			return Settings.lang.wifi;
		}
	}
	
	// Update is called once per frame
	public override void Draw () {
		base.Draw ();
	}
}
