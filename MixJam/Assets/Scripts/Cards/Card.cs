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

	private void Awake()
	{
		move = GetComponent<CardMovement>();
	}

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseCurve = MemoryController.Instance.riseCurve;
		fallCurve = MemoryController.Instance.fallCurve;
		cardHeight = MemoryController.Instance.cardHeight;



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

	public int[] GetPosBoard()
	{
		int[] position = new int[2];

		for (int j = 0; j < MemoryController.Instance.board.y; j++)
		{
			for ( int i = 0; i < MemoryController.Instance.board.x; i++)
			{
				if (MemoryController.Instance.board.board[i, j] == this)
				{
					position[0] = i;
					position[1] = j;
				}

			}
		}

		return position;
	}

	public void CardEffect()
	{
		cardEffect.Execute();
	}
}
