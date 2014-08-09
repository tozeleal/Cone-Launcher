using UnityEngine;
using System.Collections;

public class ZoomAnimation : MonoBehaviour {

	Vector3 unslected = new Vector3 (2.2f, 2.2f, 1);
	Vector3 cursor = new Vector3 (2.4f, 2.4f, 1);

	float startTime;
	public float delay;

	Color selectedColor = new Color (1, 0.79117647f, 0.75f);

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds (delay);

		while (true) {
			yield return new WaitForSeconds (1);

			startTime = Time.time;

			while (Vector3.Distance(transform.localScale, cursor) > 0.001f) {
				transform.localScale = Vector3.Lerp(transform.localScale, cursor, Time.time - startTime);
				renderer.material.color = Color.Lerp(renderer.material.color, selectedColor, Time.time - startTime);
				yield return null;
			}

			yield return new WaitForSeconds (1);

			// Animation
			/*
			for (int i=0; i<5; i++) {
				startTime = Time.time;

				for (float f=0; f<0.5f; f+=Time.deltaTime) {
					yield return null;
				}

				startTime = Time.time;

				for (float f=0; f<0.5f; f+=Time.deltaTime) {
					yield return null;
				}

				renderer.material.color = Color.white;
			}
			
			renderer.material.color = Color.white;
			*/

			startTime = Time.time;

			while (Vector3.Distance(transform.localScale, unslected) > 0.001f) {
				transform.localScale = Vector3.Lerp(transform.localScale, unslected, Time.time - startTime);
				renderer.material.color = Color.Lerp(renderer.material.color, Color.white, Time.time - startTime);
				yield return null;
			}
		}
	}
}
