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


	void Start()
    {
		board = gameObject.AddComponent<Board>();
		board.x = 4;
		board.y = 2;
		board.cards = cards;
		board.StartUp();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
