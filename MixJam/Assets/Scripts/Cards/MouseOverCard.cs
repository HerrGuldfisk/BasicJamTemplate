using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverCard : MonoBehaviour
{
	Vector3 scale;

	private void Start()
	{
		scale = transform.localScale;
	}

	public void OnMouseOver()
	{

		if (GetComponentInParent<Card>().hoverable == false)
		{
			return;
		}

		AudioManager.Instance.Play("effect_hover");

		HoverAnimation();

		GetComponentInParent<Card>().hoverable = false;
	}

	public void OnMouseLeave()
	{
		HoverAnimation();
		GetComponentInParent<Card>().hoverable = true;
	}

	public void HoverAnimation()
	{
		if (GetComponentInParent<Card>().hoverable)
		{
			LeanTween.scale(gameObject, new Vector3(scale.x * 1.2f, scale.y, scale.z * 1.2f), 0.3f).setEaseInCubic();
		}
		else
		{
			LeanTween.scale(gameObject, scale, 0.3f).setEaseInCubic();
		}

	}
}
