using UnityEngine;
using System.Collections;

public class ZoomAnimation : MonoBehaviour {

	public static Vector3 unslectedSize = new Vector3 (2.2f, 2.2f, 1);
	public static Vector3 selectedSize = new Vector3 (2.45f, 2.45f, 1);

	public static float startTime;

	public static IEnumerator Zoom (GameObject g) {
		if (g == null)
			yield break;

		startTime = Time.time;

		g.transform.position = new Vector3 (g.transform.position.x,
		                                   g.transform.position.y,
		                                   -1);

		while (Vector3.Distance(g.transform.localScale, selectedSize) > 0.001f) {
			g.transform.localScale = Vector3.Lerp(g.transform.localScale, selectedSize, (Time.time - startTime) * 4);
			// renderer.material.color = Color.Lerp(renderer.material.color, selectedColor, Time.time - startTime);
			yield return null;
		}
	}

	public static IEnumerator ZoomOut (GameObject g) {
		if (g == null)
			yield break;

		startTime = Time.time;

		g.transform.position = new Vector3 (g.transform.position.x,
		                                    g.transform.position.y,
		                                    0);

		while (Vector3.Distance(g.transform.localScale, unslectedSize) > 0.001f) {
			g.transform.localScale = Vector3.Lerp(g.transform.localScale, unslectedSize, (Time.time - startTime) * 4);
			// renderer.material.color = Color.Lerp(renderer.material.color, Color.white, Time.time - startTime);
			yield return null;
		}
	}
}
