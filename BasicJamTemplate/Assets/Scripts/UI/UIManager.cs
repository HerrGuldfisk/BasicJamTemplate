using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	#region Singleton

	public static UIManager _instance;
	public static UIManager Instance { get { return _instance; } }

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

	public Dictionary<string, GameObject> canvases = new Dictionary<string, GameObject>();

	public GameObject currentlyActive { get; private set; }

	void Start()
	{
		// Placing all canvases in a single dictionary, can be reached with the game objects name
		foreach (Transform child in transform)
		{
			canvases[child.gameObject.name] = child.gameObject;
		}

		currentlyActive = canvases["MainMenu"];
	}


	public void NewGame()
	{
		Debug.Log("New Game");

		// TODO Connect to game manager.
	}


	public void OpenMenu(string menu)
	{
		try
		{
			if (canvases[menu])
			{
				currentlyActive.SetActive(false);
				currentlyActive = canvases[menu];
				currentlyActive.SetActive(true);
			}
		}
		catch
		{
			Debug.LogWarning("There are no menu with the name: " + menu);
		}
	}

	public void SetActiveButton(Button button)
	{
		button.Select();
	}

	public void SetActiveButton(Slider slider)
	{
		slider.Select();
	}

	public void ResetMenu()
	{
		foreach(KeyValuePair<string, GameObject> entry in canvases)
		{
			entry.Value.SetActive(false);

			// Might add a default menu that should eb active.
		}
	}

	public void ExitGame()
	{
		Debug.Log("Exit Game");
		GameManager.Instance.ExitGame();
	}
}
