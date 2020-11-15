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

	public float cardHeight;

	public bool flipped;

	public CardEffect cardEffect;

	public string cardName;

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseCurve = MemoryController.Instance.riseCurve;
		fallCurve = MemoryController.Instance.fallCurve;
		cardHeight = MemoryController.Instance.cardHeight;

		cardName = gameObject.name;
	}

    private void OnMouseEnter()
    {
		AudioManager.Instance.Play("effect_hover");
	}

    public void Clicked()
	{
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
		Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.02f);
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
			// play audio
			AudioManager.Instance.Play("effect_flip");
			flipped = true;
		}
		else
		{
			LeanTween.rotate(gameObject, new Vector3(0, 0, 0), time).setEase(animFlipCurve);
			// play audio
			AudioManager.Instance.Play("effect_flip");
			flipped = false;
		}
	}

	public void LowerCard(float lowerTime)
	{
		AudioManager.Instance.Play("effect_tap");
		LeanTween.moveZ(gameObject, 0, lowerTime).setEase(fallCurve);
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

	public void CardEffect()
	{
		cardEffect.Execute();
	}
}
