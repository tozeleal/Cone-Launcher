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

	private GameObject cursor;

	private int i;

	void Awake() {
		i++;
		Debug.Log (i);
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
		cursor = rowA[0];
		StartCoroutine( ZoomAnimation.Zoom (cursor));
	}

	void Update () {

	}
}
