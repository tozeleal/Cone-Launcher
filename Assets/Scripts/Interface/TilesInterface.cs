using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilesInterface : MonoBehaviour {

	public Transform store;
	public Transform favorites;
	public Transform settings;
	public Transform featured;
	public Transform develop;
	public Transform browser;
	public Transform files;
	public Transform youtube;
	public Transform videos;

	public List<string> apps = new List<string>();
	
	public static List<List<GameObject>> columns = new List<List<GameObject>>();
	
	public static int currentRow;
	public static int currentColumn;

	private bool axisDown;

	public static GameObject cursor;

	private float timer;

	void Awake() {
		// Standard Apps
		columns.Add (new List<GameObject> (){
			store.gameObject,
			favorites.gameObject,
			settings.gameObject
		});

		columns.Add (new List<GameObject> (){
			featured.gameObject,
			develop.gameObject,
			browser.gameObject
		});

		columns.Add (new List<GameObject> (){
			files.gameObject,
			youtube.gameObject,
			videos.gameObject
		});

		// TODO Other Apps


		// Set Cursor Position
		currentRow = 0;
		currentColumn = 0;
		cursor = columns[currentColumn][currentRow];
		StartCoroutine( ZoomAnimation.Zoom (cursor));
	}

	void Update () {
		if (!axisDown) {
			if (InputManager.GetAxis("Vertical",0) > 0.5f) {
				currentRow --;

				if (currentRow < 0) {
					currentRow = columns[currentColumn].Count - 1;
				}

				ChangeCursor();

				StartCoroutine(DelayButtonPress());

			} else if (InputManager.GetAxis("Vertical",0) < -0.5f) {
				currentRow ++;

				if (currentRow > columns[currentColumn].Count - 1) {
					currentRow = 0;
				}

				ChangeCursor();

				StartCoroutine(DelayButtonPress());

			} else if (InputManager.GetAxis("Horizontal",0) > 0.5f) {
				if (currentColumn < columns.Count - 1) {
					currentColumn ++;
					ChangeCursor();
				}

				StartCoroutine(DelayButtonPress());

			} else if (InputManager.GetAxis("Horizontal",0) < -0.5f) {
				if (currentColumn > 0) {
					currentColumn --;
					ChangeCursor();
				}

				StartCoroutine(DelayButtonPress());
			}

			if (InputManager.GetButtonDown("O",0)) {
				cursor.GetComponent<LauncherAction>().OnO();
			}

			/*
			if (InputManager.GetButtonDown("U",0)) {
				
			}

			if (InputManager.GetButtonDown("Y",0)) {
				
			} */
		}
		
		if (InputManager.GetAxis("Vertical",0) < 0.25f &&
		    InputManager.GetAxis("Vertical",0) > -0.25f &&
		    InputManager.GetAxis("Horizontal",0) < 0.25f &&
		    InputManager.GetAxis("Horizontal",0) > -0.25f) {
			axisDown = false;
		}
	}

	IEnumerator DelayButtonPress() {
		timer = 0.2f;
		axisDown = true;

		while (timer > 0) {
			timer -= Time.deltaTime;

			if (!axisDown)
				yield break;

			yield return null;
		}
		axisDown = false;
	}

	void ChangeCursor() {
		cursor = columns[currentColumn][currentRow];
		StartCoroutine( ZoomAnimation.Zoom (cursor));

		LauncherInterface.selection = cursor.GetComponent<LauncherAction>().action;
	}
}
