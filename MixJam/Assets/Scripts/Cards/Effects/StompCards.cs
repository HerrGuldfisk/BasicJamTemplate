using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCards : CardEffect
{
	List<int[]> posAround;

	List<Card> cardsAtPositions;

	public override void Execute()
	{
		GetCardBoard();

		posAround = new List<int[]>(board.GetPosAroundCard(card));

		cardsAtPositions = new List<Card>();

		for ( int i = 0; i < posAround.Count; i++)
		{
			cardsAtPositions.Add(board.board[posAround[i][0], posAround[i][1]]);
		}

		Card temp = null;

		for (int i = 0; i < cardsAtPositions.Count; i++)
		{
			if (cardsAtPositions[i] != null)
			{
				if (i == 0)
				{
					if (board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]] != null)
					{
						temp = board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]];
					}

					board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]] = cardsAtPositions[i];

				}
				else if (i == posAround.Count - 1 && temp != null)
				{
					board.board[posAround[i - 1][0], posAround[i - 1][1]] = temp;
				}
				else
				{
					board.board[posAround[i - 1][0], posAround[i - 1][1]] = cardsAtPositions[i];
				}
			}
		}

		foreach(Card card in cardsAtPositions)
		{
			Debug.Log(card.name + " " + card.GetPosBoard()[0] + " " + card.GetPosBoard()[1]);
		}

		StartCoroutine(Stomp());

	}

	private IEnumerator Stomp()
	{
		// card.move.Raise(0.5f, 1f);
		// yield return new WaitForSecondsRealtime(0.3f);
		card.move.Shake(0.7f, 0.02f, true);
		yield return new WaitForSecondsRealtime(1f);
		card.move.Lower(0.2f);
		AudioManager.Instance.Play("effect_tap");
		yield return new WaitForSecondsRealtime(0.2f);
		Camera.main.GetComponent<CameraShake>().Shake(2f, 0.1f);

		for (int i = 0; i < cardsAtPositions.Count; i++)
		{
			if(cardsAtPositions[i] != null)
			{
				cardsAtPositions[i].move.Jump(0.25f, 0.45f);
				cardsAtPositions[i].move.MoveTo(cardsAtPositions[i].GetPosBoard()[0], cardsAtPositions[i].GetPosBoard()[1], 0.45f);
			}

		}
		yield return new WaitForSecondsRealtime(0.45f);

		AudioManager.Instance.Play("effect_tap");

		MemoryController.Instance.effectsDone = true;
	}
}
