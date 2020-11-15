using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEffectCards : CardEffect
{
	public override void Execute()
	{
		StartCoroutine(WaitForTime(0.6f, NoEffect()));
	}

	private void NoEffect()
	{
		MemoryController.Instance.effectsDone = true;
	}
}
