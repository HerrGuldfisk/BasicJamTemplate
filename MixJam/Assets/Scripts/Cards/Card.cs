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

	public CardEffect cardEffect;

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
		Debug.Log(MemoryController.Instance.flippedCards);
		if (MemoryController.Instance.flippedCards < 2 && flipped == false)
		{
			MemoryController.Instance.StoreCards(this);
			StartCoroutine(FlipCard());
		}
	}

	public IEnumerator FlipCard()
	{
		RaiseCard(cardHeight, MemoryController.Instance.cardRotationTime / 3);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 9);
		RotateCard(MemoryController.Instance.cardRotationTime);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime * 7 / 9);
		LowerCard(MemoryController.Instance.cardRotationTime / 3);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 2.9f);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}

	public void RaiseCard(float height, float time)
	{
		LeanTween.moveZ(gameObject, height, time).setEase(riseCurve);
	}

	public void RotateCard(float time)
	{
		if (flipped == false)
		{
			LeanTween.rotate(gameObject, new Vector3(0, 180.1f, 0), time).setEase(animFlipCurve);
			flipped = true;
		}
		else
		{
			LeanTween.rotate(gameObject, new Vector3(0, 0, 0), time).setEase(animFlipCurve);
			flipped = false;
		}
	}

	public void LowerCard(float time)
	{
		LeanTween.moveZ(gameObject, 0, time).setEase(fallCurve);
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
