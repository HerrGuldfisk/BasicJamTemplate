using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

	AnimationCurve animCurve;

	public void Clicked()
	{
		if()
	}

	public void MoveTo(float x, float y)
	{
		if (animCurve != null)
		{
			LeanTween.move(gameObject, new Vector3(x, y, transform.position.z), 0.4f).setEase(animCurve);
		}
		else
		{
			LeanTween.move(gameObject, new Vector3(x, y, transform.position.z), 0.4f).setEase(LeanTweenType.easeSpring);
		}
	}


}
