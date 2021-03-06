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

		Card tempCard = null;

		for (int i = 0; i < cardsAtPositions.Count; i++)
		{
			if (i == 0)
			{
				if (board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]] != null)
				{
					tempCard = board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]];
				}

				if (cardsAtPositions[i] != null)
				{
					board.board[posAround[posAround.Count - 1][0], posAround[posAround.Count - 1][1]] = cardsAtPositions[i];
				}

			}
			else if (i == posAround.Count - 1 && tempCard != null)
			{
				board.board[posAround[i - 1][0], posAround[i - 1][1]] = tempCard;
			}
			else
			{

				board.board[posAround[i - 1][0], posAround[i - 1][1]] = cardsAtPositions[i];

			}

		}

		StartCoroutine(Stomp());

	}

	private IEnumerator Stomp()
	{
		card.move.Raise(0.7f, 0.5f);
		yield return new WaitForSecondsRealtime(0.3f);
		card.move.Shake(0.7f, 0.02f, true);
		yield return new WaitForSecondsRealtime(0.7f);
		card.move.Lower(0.3f);
		AudioManager.Instance.Play("effect_tap");
		yield return new WaitForSecondsRealtime(0.3f);
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
