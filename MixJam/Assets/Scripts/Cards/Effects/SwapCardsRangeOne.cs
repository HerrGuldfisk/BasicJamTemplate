using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCardsRangeOne : CardEffect
{
	public override void Execute()
	{
		GetCardBoard();

		List<int[]> otherCardsPositions = board.GetPosAroundCard(card);

		int randomNumber = Random.Range(0, otherCardsPositions.Count - 1);

		List<Card> otherCards = new List<Card>();

		for (int i = 0; i < otherCardsPositions.Count; i++)
		{
			if(board.board[otherCardsPositions[i][0], otherCardsPositions[i][1]] != null)
			{
				otherCards.Add(board.board[otherCardsPositions[i][0], otherCardsPositions[i][1]]);
			}
		}

		if (otherCards.Count > 0)
		{
			Card otherCard = board.board[otherCardsPositions[randomNumber][0], otherCardsPositions[randomNumber][1]];
			SwapValues(card, otherCard);
		}
		else
		{
			Debug.Log("No cards to swap with, what should happen now?");
		}
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
