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

		// Show Tooltips
		Interface.Tooltip(Settings.lang.connect, Settings.oButton, 0.35f);
		Interface.Tooltip(Settings.lang.back, Settings.aButton, 0.55f);
	}
}
