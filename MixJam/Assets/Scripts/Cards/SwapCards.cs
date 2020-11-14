using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCards : CardEffect
{

	List<Card> cards;

	Card card;

	Board board;

	public override void Execute()
	{
		card = GetComponent<Card>();
		board = MemoryController.Instance.board;
		cards = MemoryController.Instance.board.currentCards;


		Card otherCard = board.GetRandomCard(card);

		SwapValues(card, otherCard);

	}

	private void SwapValues(Card card, Card other)
	{
		/*Card temp = cards[cards.IndexOf(card)];
		cards[cards.IndexOf(card)] = cards[cards.IndexOf(other)];
		cards[cards.IndexOf(other)] = temp;*/

		//cards.

		for (int i = 0; i < cards.Count; i++)
		{
			if(cards[i] == card)
			{
				Debug.Log(card);
			}
		}

		int x = cards.IndexOf(card);

		Debug.Log(x);
	}
}
