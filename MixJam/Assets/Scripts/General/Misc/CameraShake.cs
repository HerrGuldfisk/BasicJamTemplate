using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	Vector3 pos;
	public bool isShaking;

	public void Shake(float duration, float magnitude, float delay=0)
	{
		if (isShaking == false)
		{
			isShaking = true;
			StartCoroutine(ShakeCamera(duration, magnitude, delay));
		}
	}

    private IEnumerator ShakeCamera(float duration, float magnitude, float delay=0f)
	{
		Vector3 originalPos = transform.position;

		float timeElapsed = 0.0f;

		yield return new WaitForSecondsRealtime(delay);

		while (timeElapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

			timeElapsed += Time.fixedUnscaledDeltaTime;

			yield return null;
		}
		transform.localPosition = originalPos;

		isShaking = false;
	}
}
