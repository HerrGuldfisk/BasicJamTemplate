using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCards : CardEffect
{

	Card card;

	Board board;

	public override void Execute()
	{
		card = GetComponent<Card>();
		board = MemoryController.Instance.board;


		Card otherCard = board.GetRandomCard(card);

		SwapValues(card, otherCard);

	}

	private void SwapValues(Card card, Card other)
	{
		int[] tempCard = new int[2];
		int[] tempOther = new int[2];

		for (int j = 0; j < board.y; j++)
		{
			for (int i = 0; i < board.x; i++){

				if (board.board[i,j].Equals(card))
				{
					tempCard[0] = i;
					tempCard[1] = j;
				}

				if (board.board[i, j].Equals(other))
				{
					tempOther[0] = i;
					tempOther[1] = j;
				}
			}
		}

		board.board[tempCard[0], tempCard[1]] = other;
		board.board[tempOther[0], tempOther[1]] = card;

		StartCoroutine(MoveCards(card, other, tempCard, tempOther));
	}

	private IEnumerator MoveCards(Card card, Card other, int[] tempCard, int[] tempOther)
	{
		card.RaiseCard(other.cardHeight, MemoryController.Instance.cardRotationTime / 3);
		other.RaiseCard(other.cardHeight, MemoryController.Instance.cardRotationTime / 3);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 2);
		card.MoveTo(tempOther[0], tempOther[1]);
		other.MoveTo(tempCard[0], tempCard[1]);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardMoveTime * 1.5f);
		card.LowerCard(MemoryController.Instance.cardRotationTime / 3);
		other.LowerCard(MemoryController.Instance.cardRotationTime / 3);
	}
}
