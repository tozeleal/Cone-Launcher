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
	
	public AudioClip switchSound;

	// TODO Real Apps
	private int stubApps = 17;
	public GameObject stubApp;

	IEnumerator Start() {
		// Delete All Apps
		columns.Clear ();

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

		// TODO Real Apps
		for (int i=0; i<stubApps; i++) {
			if (columns[columns.Count - 1].Count == 3)
				columns.Add (new List<GameObject> ());

			Vector3 appPos = new Vector3((columns.Count - 1) * 17 - 29,
			                             -(columns[columns.Count - 1].Count - 1) * 10,
			                           	0);

			GameObject o = (GameObject) Instantiate(stubApp, appPos, Quaternion.identity);
			columns[columns.Count - 1].Add(o);
		}

		// Set Cursor Position
		currentRow = 0;
		currentColumn = 0;
		cursor = columns[currentColumn][currentRow];
		StartCoroutine( ZoomAnimation.Zoom (cursor));

		// Wait For Wallpaper
		while (Settings.wallpaper == null) {
			yield return null;	
		}

		// Set Wallpaper
		for (int i = 0; i < columns.Count; i++) {
			foreach( GameObject g in columns[i]) {
				g.renderer.material.SetTexture("_Wallpaper", Settings.wallpaper);
			}
		}
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
					if (columns[currentColumn + 1].Count - 1 < currentRow) {
						foreach (GameObject l in columns[currentColumn + 1]) {
							currentRow = columns[currentColumn + 1].IndexOf(l);
						}
					}

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

			if (InputManager.GetButtonDown("o", 0)) {
				cursor.GetComponent<Action>().OnO();
			}

			/*
			if (InputManager.GetButtonDown("U",0)) {
				
			}

			if (InputManager.GetButtonDown("Y",0)) {
				
			} */
		}
	}

	IEnumerator DelayButtonPress() {
		timer = 0.15f;
		axisDown = true;

		while (timer > 0) {
			timer -= Time.deltaTime;

			if (InputManager.GetAxis("Vertical",0) < 0.25f &&
			    InputManager.GetAxis("Vertical",0) > -0.25f &&
			    InputManager.GetAxis("Horizontal",0) < 0.25f &&
			    InputManager.GetAxis("Horizontal",0) > -0.25f) {
				axisDown = false;
				yield break;
			}

			yield return null;
		}
		axisDown = false;
	}

	void ChangeCursor() {
		audio.PlayOneShot (switchSound);

		cursor = columns[currentColumn][currentRow];
		StartCoroutine( ZoomAnimation.Zoom (cursor));

		LauncherInterface.selection = cursor.GetComponent<Action>().action;
	}
}
