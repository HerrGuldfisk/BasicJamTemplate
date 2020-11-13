using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

	#region Singleton
	public static SaveManager _instance;
	public static SaveManager Instance { get { return _instance; } }

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



	public void SaveSoundLevels()
	{
		foreach (KeyValuePair<string, float> entry in AudioManager.Instance.paramValue)
		{
			PlayerPrefs.SetFloat(entry.Key, entry.Value);
		}
		PlayerPrefs.Save();
	}

	public void LoadSoundLevels()
	{
		for (int i = 0; i < AudioManager.Instance.paramNames.Length; i++)
		{
			AudioManager.Instance.paramValue[AudioManager.Instance.paramNames[i]] = PlayerPrefs.GetFloat(AudioManager.Instance.paramNames[i], -3f);
		}
	}
}

