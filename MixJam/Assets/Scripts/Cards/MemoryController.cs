using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryController : MonoBehaviour
{
	#region Singleton
	public static MemoryController _instance;
	public static MemoryController Instance { get { return _instance; } }

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	#endregion

	public List<Card> cards;

	public Board board;

	private int boardX = 4;
	private int boardY = 2;

	public bool effectsDone;

	#region Animation
	public float cardMoveTime;

	public AnimationCurve animMoveCurve;

	public float cardRotationTime;

	public AnimationCurve animFlipCurve;

	public AnimationCurve riseCurve;

	public AnimationCurve fallCurve;

	public float cardHeight;
	#endregion

	public int flippedCards = 0;
	public void ResetGame()
    {
		if (GetComponent<Board>())
		{
			Destroy(board);
		}

		board = gameObject.AddComponent<Board>();
		board.x = boardX;
		board.y = boardY;
		board.cards = cards;
		board.StartUp();
	}

	Card card1;
	Card card2;

	public void StoreCards(Card currentFlippedCard)
	{
		flippedCards += 1;

		if (flippedCards == 1)
		{
			card1 = currentFlippedCard;
		}
		else if (flippedCards == 2)
		{
			GameManager.Instance.gameInputAllowed = false;

			card2 = currentFlippedCard;

			TestCards();
		}
	}

	private void TestCards()
	{
		// Compare the two cards, are they the same?
		if (card1.cardName.Equals(card2.cardName))
		{
			// The cards were the same....
			// Look for the two cards in the board array
			for (int j = 0; j < board.y; j++)
			{
				for (int i = 0; i < board.x; i++)
				{
					// Remove the cards when found
					if (board.board[i, j] == card1 || board.board[i, j] == card2)
					{
						Destroy(board.board[i, j].gameObject);
						board.board[i, j] = null;
					}
				}
			}

			card1 = null;
			card2 = null;
			GameManager.Instance.gameInputAllowed = true;

			int cardsLeft  = 0;

			for (int j = 0; j < board.y; j++)
			{
				for (int i = 0; i < board.x; i++)
				{
					if (board.board[i, j] != null)
					{
						cardsLeft++;
					}
				}
			}

			if(cardsLeft == 0)
			{
				GameManager.Instance.Victory();
			}
		}
		else
		{
			// The cards were not the same, run their effects
			StartCoroutine(RunCardEffects());
			// card1.StartCoroutine(card1.FlipCard());
			// card2.StartCoroutine(card2.FlipCard());
		}

		flippedCards = 0;
	}

	private IEnumerator RunCardEffects()
	{
		card1.CardEffect();
		yield return new WaitUntil(() => effectsDone == true);
		effectsDone = false;
		card2.CardEffect();
		yield return new WaitUntil(() => effectsDone == true);
		effectsDone = false;

		card1 = null;
		card2 = null;

		GameManager.Instance.gameInputAllowed = true;
	}
}
