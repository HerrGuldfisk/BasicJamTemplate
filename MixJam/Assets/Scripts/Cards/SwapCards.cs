using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCards : CardEffect
{

	List<Card> currentCards;

	Card card;

	Board board;

	public override void Execute()
	{
		card = GetComponent<Card>();
		board = MemoryController.Instance.board;
		currentCards = MemoryController.Instance.board.currentCards;


		Card otherCard = board.GetRandomCard(card);

		SwapValues(card, otherCard);

	}

	private void SwapValues(Card card, Card other)
	{
		/*Card temp = cards[cards.IndexOf(card)];
		cards[cards.IndexOf(card)] = cards[cards.IndexOf(other)];
		cards[cards.IndexOf(other)] = temp;*/

		for (int j = 0; j < board.y; j++)
		{
			int[] tempCard = new int[2];
			int[] tempOther = new int[2];
			Card temporary;

			for (int i = 0; i < board.x; i++){

				if (board.board[i,j].Equals(card))
				{
					tempCard[0] = i;
					tempCard[1] = j;

					temporary
				}

				if (board.board[i, j].Equals(other))
				{
					tempOther[0] = i;
					tempOther[1] = j;
				}
			}



		}

		//  Debug.Log(x);
	}

}
