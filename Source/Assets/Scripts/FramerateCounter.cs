using UnityEngine;
using System.Collections;

public class FramerateCounter : MonoBehaviour {

	static int frameCount = 0;
	static float dt = 0.0f;
	static float fps;
	static float updateRate = 1.0f;  // 4 updates per sec.

	public static float Fps {
		get
		{
			frameCount++;
			dt += Time.deltaTime;
			if (dt > 1.0/updateRate)
			{
				fps = frameCount / dt ;
				frameCount = 0;
				dt -= 1.0f / updateRate;
			}
			
			return fps;
		}
	}
}
