using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverCard : MonoBehaviour
{
	Vector3 scale;
	[HideInInspector]
	private bool hoverable = true;
	private bool newInput = true;

	private void Start()
	{
		scale = transform.localScale;
	}

	public void MouseHover()
	{
		if(hoverable && newInput && GetComponentInParent<Card>().flipped == false)
		{
			newInput = false;
			StartCoroutine(Hover());
		}

	}

	public void OnMouseLeave()
	{
		StopCoroutine(Hover());
		newInput = true;
		HoverAnimation();
		hoverable = true;
	}

	public IEnumerator Hover()
	{
		AudioManager.Instance.Play("effect_hover");

		HoverAnimation();

		hoverable = false;

		yield return new WaitForSeconds(MemoryController.Instance.cardMoveTime);

		newInput = true;
	}


	public void HoverAnimation()
	{
		if (hoverable)
		{
			LeanTween.scale(gameObject, new Vector3(scale.x * 1.1f, scale.y, scale.z * 1.1f), MemoryController.Instance.cardMoveTime / 3).setEaseInOutSine();
		}
		else
		{
			LeanTween.scale(gameObject, scale, MemoryController.Instance.cardMoveTime / 3).setEaseInOutSine();
		}

	}
}
