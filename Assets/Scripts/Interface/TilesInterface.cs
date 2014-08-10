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

	public static List<GameObject> rowA = new List<GameObject>();
	public static List<GameObject> rowB = new List<GameObject>();
	public static List<GameObject> rowC = new List<GameObject>();

	public static List<GameObject> currentRow;
	public static int currentRowNumber;
	public static int currentColumn;

	private bool horizontalAxisDown;
	private bool verticalAxisDown;

	public static GameObject cursor;

	private int i;

	void Awake() {
		// Standard Apps
		rowA.Add(store.gameObject);
		rowA.Add(featured.gameObject);
		rowA.Add(files.gameObject);

		rowB.Add(favorites.gameObject);
		rowB.Add(develop.gameObject);
		rowB.Add(youtube.gameObject);

		rowC.Add(settings.gameObject);
		rowC.Add(browser.gameObject);
		rowC.Add(videos.gameObject);

		// TODO Other Apps

		// Set Cursor Position
		currentRowNumber = 0;
		currentRow = rowA;
		cursor = currentRow[currentColumn];
		StartCoroutine( ZoomAnimation.Zoom (cursor));
	}

	void Update () {
		if (InputManager.GetAxis("Vertical",0) > 0.5f && !verticalAxisDown) {
			if (currentRowNumber == 0) {
				currentRow = rowC;
				currentRowNumber = 2;
			}
			if (currentRowNumber == 1) {
				currentRow = rowA;
				currentRowNumber = 0;
			}
			if (currentRowNumber == 2) {
				currentRow = rowB;
				currentRowNumber = 1;
			}

			verticalAxisDown = true;

			ChangeCursor();
		}

		if (InputManager.GetAxis("Vertical",0) < -0.5f && !verticalAxisDown) {
			if (currentRowNumber == 0) {
				currentRow = rowB;
				currentRowNumber = 1;
			}
			if (currentRowNumber == 1) {
				currentRow = rowC;
				currentRowNumber = 2;
			}
			if (currentRowNumber == 2) {
				currentRow = rowA;
				currentRowNumber = 0;
			}
			
			verticalAxisDown = true;
			
			ChangeCursor();
		}

		if (InputManager.GetAxis("Vertical",0) < 0.25f &&
		    InputManager.GetAxis("Vertical",0) > -0.25f) {
			verticalAxisDown = false;
		}

		if (InputManager.GetAxis("Horizontal",0) > 0.5f && !horizontalAxisDown) {
			if (currentColumn < currentRow.Count - 1) {
				currentColumn ++;
				ChangeCursor();
			}

			horizontalAxisDown = true;
		}
		
		if (InputManager.GetAxis("Horizontal",0) < -0.5f && !horizontalAxisDown) {
			if (currentColumn > 0) {
				currentColumn --;
				ChangeCursor();
			}
			
			horizontalAxisDown = true;
		}
		
		if (InputManager.GetAxis("Horizontal",0) < 0.25f &&
		    InputManager.GetAxis("Horizontal",0) > -0.25f) {
			horizontalAxisDown = false;
		}

		Debug.Log ("Row: " + currentRowNumber + "  Column" + currentColumn);
	}

	void ChangeCursor() {
		StartCoroutine( ZoomAnimation.ZoomOut (cursor));
		cursor = currentRow[currentColumn];
		StartCoroutine( ZoomAnimation.Zoom (cursor));
	}
}
