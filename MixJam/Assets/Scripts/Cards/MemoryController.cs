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

	private bool effectsDone;

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
			card2 = currentFlippedCard;

			TestCards();
		}
	}

	private void TestCards()
	{
		if (card1.Equals(card2))
		{
			board.currentCards.Remove(card1);
			board.currentCards.Remove(card2);
		}
		else
		{
			StartCoroutine(RunCardEffects());
		}

		card1.StartCoroutine(card1.FlipCard());
		card2.StartCoroutine(card2.FlipCard());
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
	}
}
