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

	private List<Scene> allScenes = new List<Scene>();
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

	/// <summary>
	/// Loads the next scene in the build order.
	/// </summary>
	public void LoadLevel()
	{
		// If there is a new level load that, else load the first level.
		if (SceneManager.sceneCountInBuildSettings > currentScene + 1)
		{
			SceneManager.LoadSceneAsync(currentScene + 1, LoadSceneMode.Additive);
		}
		else
		{
			SceneManager.LoadSceneAsync(0);
		}
	}

	/// <summary>
	/// Loads the <paramref name="index"/> from the build order.
	/// </summary>
	/// <param name="index"></param>
	public void LoadLevel(int index)
	{
		SceneManager.LoadSceneAsync(index);
	}

	/// <summary>
	/// Unloads the oldest scene in use.
	/// </summary>
	public void UnloadLevel()
	{
		if (allScenes.Count > 0)
		{
			SceneManager.UnloadSceneAsync(allScenes[0]);
			allScenes.Remove(allScenes[0]);
		}
		else
		{
			Debug.Log("There are no scenes that can be unloaded");
		}
	}

	/// <summary>
	/// Unloads all currently active scenes.
	/// </summary>
	public void UnloadAllLevels()
	{
		foreach (Scene scene in allScenes)
		{
			SceneManager.UnloadSceneAsync(allScenes[0]);
			allScenes.Remove(allScenes[0]);
		}
	}
}
