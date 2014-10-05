using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilesInterface : MonoBehaviour {

//	public List<string> apps = new List<string>();
	
	public static List<List<GameObject>> columns = new List<List<GameObject>>();
	
	public static int currentRow;
	public static int currentColumn;

	private bool axisDown;

	public static GameObject cursor;

	private float timer;
	
	public AudioClip switchSound;

	// Camera Scrolling
	public float maxDistance = 5;
	public float lerpSpeed = 0.1f;
	private float curX;
	public static bool zoomSelectedItem;

	// Standard Apps
	public List<GameObject> standardApps = new List<GameObject>();
	public GameObject developerTile;

	// TODO Real Apps
	private int stubApps = 17;
	public GameObject stubApp;
	
	private GameObject obj;

	IEnumerator Start() {
		// Recreate the appslist
		columns.Clear ();
		columns.Add (new List<GameObject> ());

		// Standard Apps
		foreach (GameObject g in standardApps) {
			if (columns[columns.Count - 1].Count == 3)
				columns.Add (new List<GameObject> ());
			
			Vector3 appPos = new Vector3((columns.Count - 1) * 17 - 29,
			                             -(columns[columns.Count - 1].Count - 1) * 10,
			                             0);

			obj = null;

			if (g != developerTile)
				obj = (GameObject) Instantiate(g, appPos, Quaternion.identity);
			else if (Settings.developer)
				obj = (GameObject) Instantiate(g, appPos, Quaternion.identity);

			if (obj != null)
				columns[columns.Count - 1].Add(obj);
		}

		// Add Stub Apps to list
		// TODO Real Apps
		for (int i=0; i<stubApps; i++) {
			if (columns[columns.Count - 1].Count == 3)
				columns.Add (new List<GameObject> ());

			Vector3 appPos = new Vector3((columns.Count - 1) * 17 - 29,
			                             -(columns[columns.Count - 1].Count - 1) * 10,
			                           	0);

			obj = (GameObject) Instantiate(stubApp, appPos, Quaternion.identity);
			columns[columns.Count - 1].Add(obj);
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
		CameraScroll ();

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

	public void CameraScroll() {
		if (zoomSelectedItem)
			return;
		
		curX = cursor.transform.position.x;
		if (transform.position.x < 0)
			curX = Mathf.Max (curX, 9);
		
		if (Mathf.Abs(curX - transform.position.x) > maxDistance) {
			transform.position += new Vector3((curX - transform.position.x) * lerpSpeed * Time.deltaTime,0,0);
		}
		
		float maxPos = columns [columns.Count - 1] [0].transform.position.x - 28;
		
		if (transform.position.x > maxPos) {
			transform.position = new Vector3 (maxPos,
			                                  transform.position.y,
			                                  transform.position.z);
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

	public static IEnumerator ScrollAway() {
		zoomSelectedItem = true;
		
		while (Camera.main.transform.position.x > -90) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position,
			                                               new Vector3(-125, 0, Camera.main.transform.position.z),
			                                               3 * Time.deltaTime);
			
			yield return null;
		}
		
		zoomSelectedItem = false;
	}
}
