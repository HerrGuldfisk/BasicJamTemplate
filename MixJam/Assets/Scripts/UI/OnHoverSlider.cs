using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverSlider : MonoBehaviour, ISelectHandler, IDeselectHandler
{
	private Slider slider;

	public AnimationCurve curveSelect;

	public AnimationCurve curveDeselect;

	public LeanTweenType easeType;

	// Start is called before the first frame update
	void Start()
	{
		slider = GetComponent<Slider>();
	}

	public void OnSelect(BaseEventData eventData)
	{
		LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.2f).setEase(curveSelect);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.2f).setEase(curveDeselect);
	}
}
