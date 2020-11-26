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

	private List<int> currentScenesBuildIndex = new List<int>();
	private int currentScene;


	private void Start()
	{
		SceneManager.sceneLoaded += OnSceneWasLoaded;

	}

	public void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Scene with name " + scene.name + " with build index " + scene.buildIndex + " was successfully loaded");
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
			currentScenesBuildIndex.Add(currentScene + 1);
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
		Debug.Log("Loading level");
		SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
		currentScenesBuildIndex.Add(index);
	}

	/// <summary>
	/// Unloads the oldest scene in use.
	/// </summary>
	public void UnloadLevel(int index)
	{
		if (currentScenesBuildIndex.Count > index)
		{
			SceneManager.UnloadSceneAsync(currentScenesBuildIndex[index]);
			currentScenesBuildIndex.Remove(currentScenesBuildIndex[index]);
		}
		else
		{
			Debug.Log("There aren't that many scenes in use");
		}
	}

	/// <summary>
	/// Unloads all currently active scenes.
	/// </summary>
	public void UnloadAllLevels()
	{
		foreach (int buildIndex in currentScenesBuildIndex)
		{
			SceneManager.UnloadSceneAsync(currentScenesBuildIndex[0]);
			currentScenesBuildIndex.Remove(currentScenesBuildIndex[0]);
		}
	}
}
