using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCardsRangeOne : CardEffect
{
	public override void Execute()
	{
		GetCardBoard();

		List<int[]> otherCards = board.GetPosAroundCard(card);

		int randomNumber = Random.Range(0, otherCards.Count - 1);

		Card otherCard = board.board[otherCards[randomNumber][0], otherCards[randomNumber][1]];

		SwapValues(card, otherCard);

	}

	private void SwapValues(Card card, Card other)
	{
		int[] tempCard = new int[2];
		int[] tempOther = new int[2];

		for (int j = 0; j < board.y; j++)
		{
			for (int i = 0; i < board.x; i++)
			{

				if (board.board[i, j] == card)
				{
					tempCard[0] = i;
					tempCard[1] = j;
				}

				if (board.board[i, j] == other)
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
}
