using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

	AnimationCurve animMoveCurve;

	AnimationCurve animFlipCurve;

	AnimationCurve riseAndFall;

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseAndFall = MemoryController.Instance.riseAndFall;
	}


	public void Clicked()
	{
		if (MemoryController.Instance.board.flippedCards < 2)
		{
			StartCoroutine(FlipCard());
		}
	}

	private IEnumerator FlipCard()
	{
		LeanTween.moveZ(gameObject, 0.8f, MemoryController.Instance.cardRotationTime).setEase(riseAndFall);


		LeanTween.rotate(gameObject, new Vector3(180, 0, 0), MemoryController.Instance.cardRotationTime).setEase(animFlipCurve);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime);
	}

	public void MoveTo(float x, float y)
	{
		if (animMoveCurve != null)
		{
			LeanTween.move(gameObject, new Vector3(x, y, transform.position.z), MemoryController.Instance.cardMoveTime).setEase(animMoveCurve);
		}
		else
		{
			LeanTween.move(gameObject, new Vector3(x, y, transform.position.z), MemoryController.Instance.cardMoveTime).setEase(LeanTweenType.easeSpring);
		}
	}


}
