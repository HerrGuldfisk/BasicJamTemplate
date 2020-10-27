using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public bool running = true;
	public float time;
	public bool unscaled = true;
	public bool destroyOnFinish = true;

	public UnityEvent onTimerFinish = new UnityEvent();

	private void Start()
	{

	}

	void Update()
    {
		if (!running) { return; }

		if (time == 0)
		{
			onTimerFinish.Invoke();
			running = false;

			if (destroyOnFinish)
			{
				Destroy(this);
			}
		}

		if (unscaled)
		{
			time -= Time.unscaledDeltaTime;
		}
		else
		{
			time -= Time.deltaTime;
		}

		if (time <= 0f)
		{
			time = 0f;
		}
    }
}
