using UnityEngine;
using System.Collections;

public class ZoomAnimation : MonoBehaviour {

	Vector3 unslected= new Vector3 (2.2f, 2.2f, 1);
	Vector3 cursor = new Vector3 (2.4f, 2.4f, 1);

	float startTime;

	Color selectedColor = new Color (1, 0.58235294f, 0.5f);

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			yield return new WaitForSeconds (1);

			startTime = Time.time;

			while (Vector3.Distance(transform.localScale, cursor) > 0.001f) {
				transform.localScale = Vector3.Slerp(transform.localScale, cursor, Time.time - startTime);
					yield return null;
			}

			for (int i=0; i<5; i++) {
				startTime = Time.time;

				for (float f=0; f<0.5f; f+=Time.deltaTime) {
					renderer.material.color = Color.Lerp(renderer.material.color, selectedColor, Time.time - startTime);
					yield return null;
				}

				startTime = Time.time;

				for (float f=0; f<0.5f; f+=Time.deltaTime) {
					renderer.material.color = Color.Lerp(renderer.material.color, Color.white, Time.time - startTime);
					yield return null;
				}

				renderer.material.color = Color.white;
			}

			startTime = Time.time;

			renderer.material.color = Color.white;

			while (Vector3.Distance(transform.localScale, unslected) > 0.001f) {
				transform.localScale = Vector3.Slerp(transform.localScale, unslected, Time.time - startTime);
				yield return null;
			}
		}
	}
}
