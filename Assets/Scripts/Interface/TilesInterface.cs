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

	// public static List<GameObject> rowA = new List<GameObject>();
	// public static List<GameObject> rowB = new List<GameObject>();
	// public static List<GameObject> rowC = new List<GameObject>();

	public static List<List<GameObject>> columns = new List<List<GameObject>>();
	
	public static int currentRow;
	public static int currentColumn;

	private bool axisDown;

	public static GameObject cursor;

	private int i;

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
		cursor.transform.localScale = ZoomAnimation.selectedSize;
	}

	void Update () {
		if (InputManager.GetAxis("Vertical",0) > 0.5f && !axisDown) {
			currentRow --;

			if (currentRow < 0) {
				currentRow = columns[currentColumn].Count - 1;
			}

			ChangeCursor();

			axisDown = true;
		} else if (InputManager.GetAxis("Vertical",0) < -0.5f && !axisDown) {
			currentRow ++;

			if (currentRow > columns[currentColumn].Count - 1) {
				currentRow = 0;
			}

			ChangeCursor();

			axisDown = true;
		} else if (InputManager.GetAxis("Horizontal",0) > 0.5f && !axisDown) {
			if (currentColumn < columns.Count - 1) {
				currentColumn ++;
				ChangeCursor();
			}

			axisDown = true;
		} else if (InputManager.GetAxis("Horizontal",0) < -0.5f && !axisDown) {
			if (currentColumn > 0) {
				currentColumn --;
				ChangeCursor();
			}
			
			axisDown = true;
		}
		
		if (InputManager.GetAxis("Vertical",0) < 0.25f &&
		    InputManager.GetAxis("Vertical",0) > -0.25f &&
		    InputManager.GetAxis("Horizontal",0) < 0.25f &&
		    InputManager.GetAxis("Horizontal",0) > -0.25f) {
			axisDown = false;
		}


	}

	void ChangeCursor() {
		StartCoroutine( ZoomAnimation.ZoomOut (cursor));
		cursor = columns[currentColumn][currentRow];
		StartCoroutine( ZoomAnimation.Zoom (cursor));

		LauncherInterface.selection = cursor.GetComponent<LauncherAction>().action;
	}
}
