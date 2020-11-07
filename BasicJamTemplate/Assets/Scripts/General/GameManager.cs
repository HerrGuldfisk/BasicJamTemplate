using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	#region Singleton
	public static GameManager _instance;
	public static GameManager Instance { get { return _instance; } }

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

	private bool inMenu;
	[SerializeField]
	private UIManager UI;

	public void Print(string print)
	{
		Debug.Log(print);
	}

	public void OnExit()
	{
		if (!inMenu)
		{
			UI.canvases["MainMenu"].SetActive(true);
			UI.currentlyActive.transform.GetChild(0).GetComponent<Button>().Select();
		}
		else
		{
			UI.currentlyActive.SetActive(false);
		}
	}

	public void ExitGame()
	{
		// Do everything that should happen before the game is quit.

		Application.Quit();
	}
}
