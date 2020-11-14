using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

	AnimationCurve animMoveCurve;

	AnimationCurve animFlipCurve;

	AnimationCurve riseCurve;

	AnimationCurve fallCurve;

	float cardHeight;

	public bool flipped;

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseCurve = MemoryController.Instance.riseCurve;
		fallCurve = MemoryController.Instance.fallCurve;
		cardHeight = MemoryController.Instance.cardHeight;
	}


	public void Clicked()
	{
		StartCoroutine(FlipCard());
		/*
		if (MemoryController.Instance.board.flippedCards < 2)
		{
			StartCoroutine(FlipCard());
		}*/
	}

	private IEnumerator FlipCard()
	{
		LeanTween.moveZ(gameObject, cardHeight, MemoryController.Instance.cardRotationTime / 3).setEase(riseCurve);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 9);
		if(flipped == false)
		{
			LeanTween.rotate(gameObject, new Vector3(0, 180.1f, 0), MemoryController.Instance.cardRotationTime).setEase(animFlipCurve);
			flipped = true;
		}
		else
		{
			LeanTween.rotate(gameObject, new Vector3(0, 0, 0), MemoryController.Instance.cardRotationTime).setEase(animFlipCurve);
			flipped = false;
		}
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime * 7 / 9);
		LeanTween.moveZ(gameObject, 0, MemoryController.Instance.cardRotationTime / 3).setEase(fallCurve);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 3);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
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
