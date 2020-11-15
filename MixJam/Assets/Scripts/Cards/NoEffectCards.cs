using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEffectCards : CardEffect
{
	public override void Execute()
	{
		card = GetComponent<Card>();
		StartCoroutine(NoEffect(MemoryController.Instance.cardRotationTime / 2.9f));
	}

	private IEnumerator NoEffect(float time)
	{
		yield return new WaitForSecondsRealtime(time * 3);
		card.LowerCard(MemoryController.Instance.cardRotationTime / 3);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 3);
		Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.02f);
		yield return new WaitForSecondsRealtime(time * 1f);
		MemoryController.Instance.effectsDone = true;
	}
}
