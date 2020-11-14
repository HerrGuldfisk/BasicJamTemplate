using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

	[SerializeField]
	private UIManager UI;

	public bool menuActive;

	public UnityEvent onPause = new UnityEvent();


	public bool gameInputAllowed = true;


	private void Start()
	{
		UIManager.Instance.onResume.AddListener(OnExit);
		OnExit();
	}

	public void Print(string print)
	{
		Debug.Log(print);
	}

	public void Victory()
	{
		UI.OpenMenu("InGameMenu");
	}

	public void OnExit()
	{
		if (!menuActive)
		{
			menuActive = true;
			onPause.Invoke();
			UI.OpenMenu("MainMenu");

			// UI.currentlyActive.transform.GetChild(0).GetComponent<Button>().Select();
		}
		else
		{
			if (menuActive)
			{
				if (UI.currentlyActive.name.Equals("MainMenu") || UI.currentlyActive.name.Equals("InGameMenu"))
				{
					menuActive = false;
					onPause.Invoke();
					UI.currentlyActive.gameObject.SetActive(false);
				}
				else
				{
					UI.OpenMenu("MainMenu");
					UI.currentlyActive.transform.GetChild(1).GetComponent<Button>().Select();
				}
			}
		}
	}

	public void ExitGame()
	{
		// Do everything that should happen before the game is quit.

		Application.Quit();
	}
}
