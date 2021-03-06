using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board :  MonoBehaviour
{
	public int x;
	public int y;

	public List<Card> cards;

	private List<Card> currentCards;

	public Card[,] board;


	public Board(int x, int y, List<Card> cards)
	{
		this.x = x;
		this.y = y;

		this.cards = cards;
	}

	public void StartUp()
	{
		currentCards = new List<Card>();

		board = new Card[x, y];

		int numPlaces = x * y;

		// Pick half as many cards as there are positions.
		for (int i = 0; i < numPlaces / 2; i++)
		{
			// Chose a card at random and add two copies.
			// The card is then removed from the pool of cards.
			int randomNumber = Random.Range(0, cards.Count);
			currentCards.Add(cards[randomNumber]);
			currentCards.Add(cards[randomNumber]);

			// cards.RemoveAt(randomNumber);
		}

		Shuffle();

		StartCoroutine(Deal());
	}

	private IEnumerator Deal()
	{
		int pos = 0;
		Debug.Log(currentCards.Count);
		float timeBetweenCards = 1f / currentCards.Count;

		for(int j = 0; j < y; j++)
		{
			for (int i = 0; i < x; i++)
			{
				board[i, j] = Instantiate(currentCards[pos], transform);

				board[i, j].move.MoveToDealing(i, j);

				pos++;

				yield return new WaitForSecondsRealtime(timeBetweenCards);
			}
		}
	}

	public void Shuffle()
	{
		for (int i = 0; i < currentCards.Count; i++)
		{
			Card temp = currentCards[i];

			// Add a reset for each card so it turns back side up.

			int randomIndex = Random.Range(i, currentCards.Count);
			currentCards[i] = currentCards[randomIndex];
			currentCards[randomIndex] = temp;
		}
	}

	public Card GetRandomCard(Card currentCard)
	{
		bool value = false;
		int randomX = 0;
		int randomY = 0;

		while (!value)
		{
			randomX = Random.Range(0, x);
			randomY = Random.Range(0, y);

			if (board[randomX, randomY] != null && !board[randomX, randomY].Equals(currentCard))
			{
				value = true;
			}
		}

		return board[randomX, randomY];
	}

	public List<int[]> GetPosAroundCard(Card card, bool sorted=true)
	{
		List<int[]> listReturn = new List<int[]>();

		Card centerCard = card;

		int[] centerPos = centerCard.GetPosBoard();

		int startX = centerPos[0] - 1;
		int endX = centerPos[0] + 1;

		int startY = centerPos[1] - 1;
		int endY = centerPos[1] + 1;

		startX = Mathf.Clamp(startX, 0, x - 1);
		endX = Mathf.Clamp(endX, 0, x - 1);

		startY = Mathf.Clamp(startY, 0, y - 1);
		endY = Mathf.Clamp(endY, 0, y - 1);

		for (int j = startY; j <= endY; j++)
		{
			for (int i = startX; i <= endX; i++)
			{
				if (centerPos[0] == i && centerPos[1] == j)
				{
					// Do nothing with the picked card
				}
				else
				{
					int[] temp = new int[2];
					temp[0] = i;
					temp[1] = j;
					listReturn.Add(temp);
				}
			}
		}

		if (!sorted)
		{
			return listReturn;
		}
		else
		{
			if (centerPos[0] == 0 && centerPos[1] == 0)
			{
				Debug.Log("00");
				int[] temp = listReturn[1];
				listReturn[1] = listReturn[2];
				listReturn[2] = temp;
			}
			if (centerPos[0] != 0 && centerPos[0] != x - 1 && centerPos[1] == 0)
			{
				Debug.Log("-0");
				int[] temp = listReturn[2];
				listReturn[2] = listReturn[4];
				listReturn[4] = temp;
			}
			if (centerPos[0] == x -1 && centerPos[1] == 0)
			{
				Debug.Log("x0");
				int[] temp = listReturn[1];
				listReturn[1] = listReturn[2];
				listReturn[2] = temp;
			}

			if (centerPos[0] == 0 && centerPos[1] != 0 && centerPos[1] != y - 1)
			{
				Debug.Log("0-");
				int[] temp = listReturn[3];
				listReturn[3] = listReturn[4];
				listReturn[4] = temp;
			}
			if (centerPos[0] != 0 && centerPos[1] != 0 && centerPos[0] != x - 1 && centerPos[1] != y - 1)
			{
				Debug.Log("--");
				int[] temp = listReturn[3];
				listReturn[3] = listReturn[4];
				listReturn[4] = temp;

				int[] temp1 = listReturn[4];
				listReturn[4] = listReturn[7];
				listReturn[7] = temp1;

				int[] temp2 = listReturn[5];
				listReturn[5] = listReturn[6];
				listReturn[6] = temp2;
			}
			if (centerPos[0] == x - 1 && centerPos[1] != 0 && centerPos[1] != y - 1)
			{
				Debug.Log("0y");
				int[] temp = listReturn[2];
				listReturn[2] = listReturn[4];
				listReturn[4] = temp;
			}

			if (centerPos[0] == 0 && centerPos[1] == y - 1)
			{
				// No sorting needed.
			}
			if (centerPos[0] != 0 && centerPos[0] != x - 1 && centerPos[1] == y - 1)
			{
				Debug.Log("-y");
				int[] temp = listReturn[3];
				listReturn[3] = listReturn[4];
				listReturn[4] = temp;
			}
			if (centerPos[0] == x - 1 && centerPos[1] == y - 1)
			{
				// No sorting needed.
			}

			return listReturn;
		}
	}

	#region testcodethatsucks
	/*
	 * Card owner = card;
		int ownerX = -1;
		int ownerY = -1;


		List<Card> cardsToReturn =  new List<Card>();

		for (int j = 0; j < y; j++)
		{
			for (int i = 0; i < x; i++)
			{
				// Remove the cards when found
				if (board[i, j] == owner)
				{
					ownerX = i;
					ownerY = y;
				}
			}
		}

		int[] pos = owner.GetPosBoard();
		ownerX = pos[0];
		ownerY = pos[1];


		if (board[ownerX - 1, ownerY - 1] != null)
		{
			cardsToReturn.Add(board[ownerX - 1, ownerY - 1]);
		}

		if (board[ownerX - 1, ownerY] != null)
		{
			cardsToReturn.Add(board[ownerX - 1, ownerY]);
		}

		if (board[ownerX - 1, ownerY + 1] != null)
		{
			cardsToReturn.Add(board[ownerX - 1, ownerY + 1]);
		}

		if (board[ownerX, ownerY + 1] != null)
		{
			cardsToReturn.Add(board[ownerX, ownerY + 1]);
		}
		if (board[ownerX + 1, ownerY + 1] != null)
		{
			cardsToReturn.Add(board[ownerX + 1, ownerY + 1]);
		}
		if (board[ownerX + 1, ownerY] != null)
		{
			cardsToReturn.Add(board[ownerX + 1, ownerY]);
		}
		if (board[ownerX + 1, ownerY - 1] != null)
		{
			cardsToReturn.Add(board[ownerX + 1, ownerY - 1]);
		}
		if (board[ownerX, ownerY - 1] != null)
		{
			cardsToReturn.Add(board[ownerX, ownerY - 1]);
		}

		return cardsToReturn;


		/*
		int startY = ownerY - 1;
		int endY = ownerY + 1;

		int startX = ownerX - 1;
		int endX = ownerX + 1;

		if (startY < 0)
		{
			startY = 0;
		}
		if (endY == y)
		{
			startY = ownerY;
		}

		if (startX < 0)
		{
			startX = 0;
		}
		if (endX == x)
		{
			startX = ownerX;
		}

		for (int j = startY; j <= endY; j++)
		{
			for (int i = startX; i <= endX; i++)
			{
				if (board[i,j] != owner)
				{
					cardsToReturn.Add(board[i, j]);
				}
			}
		}

		Debug.Log(cardsToReturn.Count);

		return cardsToReturn;
	 */
	#endregion
}
