using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	#region Singleton
	public static AudioManager _instance;
	public static AudioManager Instance { get { return _instance; } }

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
	private AudioMixer mixer;

	public string changedValue;

	private void Start()
	{

	}


	public void ChangedValue(string name)
	{
		changedValue = name + "Volume";
	}

	public void FromSlider(float sliderValue)
	{
		mixer.SetFloat(changedValue, Mathf.Log10(sliderValue) * 30);
	}
}
