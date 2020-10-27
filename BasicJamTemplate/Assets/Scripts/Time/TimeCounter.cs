using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
	public bool running = true;
	public bool unscaled = true;
	public float time { get; private set; }

    void Update()
    {
		if (!running) { return; }

		if (unscaled)
		{
			time += Time.unscaledDeltaTime;
		}
		else
		{
			time = Time.deltaTime;
		}

    }

	public void StartCounting()
	{
		running = true;
	}

	public void ResetCounter()
	{
		running = false;
		time = 0;
	}

	public void Pause()
	{
		running = false;
	}
}
