using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEffectCards : CardEffect
{
	public override void Execute()
	{
		StartCoroutine(NoEffect(0.6f));
	}

	private IEnumerator NoEffect(float time)
	{
		Debug.Log(Time.time);
		yield return new WaitForSecondsRealtime(time);
		Debug.Log(Time.time);
		MemoryController.Instance.effectsDone = true;
	}
}
