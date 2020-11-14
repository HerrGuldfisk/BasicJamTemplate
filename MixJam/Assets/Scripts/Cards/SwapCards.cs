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


	}

}
