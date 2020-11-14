using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board :  MonoBehaviour
{
	public int x;
	public int y;

	public List<Card> cards;

	public List<Card> currentCards;

	Card[,] board;


	public Board(int x, int y, List<Card> cards)
	{
		this.x = x;
		this.y = y;

		this.cards = cards;
	}

	public void StartUp()
	{
		Debug.Log(cards);

		currentCards = new List<Card>();

		Debug.Log(currentCards);

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

			cards.RemoveAt(randomNumber);
		}

		Shuffle();

		Deal();
	}

	private void Deal()
	{
		int pos = 0;

		for(int j = 0; j < y; j++)
		{
			for (int i = 0; i < x; i++)
			{
				board[i, j] = Instantiate(currentCards[pos], transform);

				board[i, j].MoveTo(i, j);

				pos++;
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

	public void GetRandomCard()
	{
		int randomX = Random.Range(0, x);
		int randomY = Random.Range(0, y);

		if(board[randomX, randomY] != null)
		{

		}
	}
}
