using System;
using UnityEngine;
#if UNITY_ANDROID && !UNITY_EDITOR
	using tv.ouya.console.api;
#endif

public static class InputManager
{
	public static float GetAxis(string inputName, int player) {
		#if UNITY_ANDROID && !UNITY_EDITOR
			switch (inputName) {
				case "Horizontal":
					return OuyaSDK.OuyaInput.GetAxis(player, OuyaController.AXIS_LS_X);
				case "Vertical":
					return -OuyaSDK.OuyaInput.GetAxis(player, OuyaController.AXIS_LS_Y);
				case "RHorizontal":
					return OuyaSDK.OuyaInput.GetAxis(player, OuyaController.AXIS_RS_X);
				case "RVertical":
					return -OuyaSDK.OuyaInput.GetAxis(player, OuyaController.AXIS_RS_Y);
				default:
					return 0;
			}
		#endif

		return Input.GetAxisRaw (inputName);
	}

	public static bool GetButton(string inputName, int player) {
		#if UNITY_ANDROID && !UNITY_EDITOR
			switch (inputName) {
				case "Jump":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_O);
				case "Run":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_U);
				case "Menu":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_Y);
				default:
					return false;
			}
		#endif

		return Input.GetButton (inputName);
	}

	public static bool GetButtonDown(string inputName, int player)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
			switch (inputName) {
				case "Jump":
					return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_O);
				case "Run":
					return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_U);
				case "Menu":
					return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_Y);
				default:
					return false;
			}
		#endif
		
		return Input.GetButtonDown (inputName);
	}
}