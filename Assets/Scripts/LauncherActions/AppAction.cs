using UnityEngine;
using System.Collections;

public class AppAction : Action {

	public string bundleID = "com.cone.shadow"; // Example: ShadowLight

	public override void OnO () {
		#if UNITY_ANDROID && !UNITY_EDITOR
			AppList.LaunchApp (bundleID);
		#endif
	}
}