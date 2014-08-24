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
			switch (inputName.ToLower()) {
				case "o":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_O);
				case "u":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_U);
				case "y":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_Y);
				case "a":
					return OuyaSDK.OuyaInput.GetButton(player, OuyaController.BUTTON_A);
				default:
					return false;
			}
		#endif

		return Input.GetButton (inputName);
	}

	public static bool GetButtonDown(string inputName, int player)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
			switch (inputName.ToLower()) {
			case "o":
				return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_O);
			case "u":
				return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_U);
			case "y":
				return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_Y);
			case "a":
				return OuyaSDK.OuyaInput.GetButtonDown(player, OuyaController.BUTTON_A);
			default:
				return false;
			}
		#endif
		
		return Input.GetButtonDown (inputName);
	}
}