using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private Dictionary<string, GameObject> canvases = new Dictionary<string, GameObject>();

	private void Start()
	{
		// Placing all canvases in a single dictionary, can be reached with the game objects name
		foreach (Transform child in transform)
		{
			canvases[child.gameObject.name] = child.gameObject;

		}

	}

}
