using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	#region Singleton

	public static LevelManager _instance;
	public static LevelManager Instance { get { return _instance; } }

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

	public bool debugMessages;


	private int currentScene;

	private void Start()
	{
		SceneManager.sceneLoaded += OnSceneWasLoaded;
	}

	public void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Scene with name " + scene.name + " and build index " + scene.buildIndex + " was successfully loaded");
		currentScene = SceneManager.GetActiveScene().buildIndex;
	}

	public void LoadLevel()
	{
		// If there is a new level load that, else load the first level.
		if (SceneManager.sceneCountInBuildSettings > currentScene + 1)
		{
			SceneManager.LoadSceneAsync(currentScene + 1);
		}
		else
		{
			SceneManager.LoadSceneAsync(0);
		}
	}

	public void LoadLevel(int index)
	{
		SceneManager.LoadSceneAsync(index);
	}
}
