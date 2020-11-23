using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCards : CardEffect
{
	List<Card> cards;

	List<int[]> positions;

	public override void Execute()
	{
		GetCardBoard();

		cards = new List<Card>(board.GetCardsAround(card));

		positions = new List<int[]>();



		foreach (Card card in cards)
		{
			positions.Add(card.GetPosBoard());
		}

		for (int i = 0; i < cards.Count; i++)
		{

			if (i == 0)
			{
				board.board[positions[positions.Count - 1][0], positions[positions.Count - 1][1]] = cards[i];
			}
			else
			{
				board.board[positions[i - 1][0], positions[i - 1][1]] = cards[i];
			}
		}

		StartCoroutine(Stomp());
	}

	private IEnumerator Stomp()
	{
		card.move.Raise(0.5f, 1f);
		yield return new WaitForSecondsRealtime(0.3f);
		card.move.Shake(0.7f, 0.01f, true);
		yield return new WaitForSecondsRealtime(0.2f);
		card.move.Lower(0.2f);
		AudioManager.Instance.Play("effect_tap");
		yield return new WaitForSecondsRealtime(0.2f);

		for (int i = 0; i < cards.Count; i++)
		{
			cards[i].move.Jump(0.25f, 0.45f);
			cards[i].move.MoveTo(positions[i][0], positions[i][1], 0.45f);
		}
		yield return new WaitForSecondsRealtime(0.45f);

		AudioManager.Instance.Play("effect_tap");

		MemoryController.Instance.effectsDone = true;
	}
}
