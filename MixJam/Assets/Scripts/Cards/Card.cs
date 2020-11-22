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

	public CardMovement move;

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseCurve = MemoryController.Instance.riseCurve;
		fallCurve = MemoryController.Instance.fallCurve;
		cardHeight = MemoryController.Instance.cardHeight;

		move = GetComponent<CardMovement>();

		cardName = gameObject.name;
	}

    public void Clicked()
	{
		if (MemoryController.Instance.flippedCards < 2 && flipped == false)
		{
			MemoryController.Instance.StoreCards(this);
			move.FullFlip();
		}
	}

	public void CardEffect()
	{
		cardEffect.Execute();
	}
}
