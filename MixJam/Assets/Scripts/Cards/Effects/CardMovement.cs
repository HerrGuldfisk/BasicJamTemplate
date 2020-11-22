using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics.Animation;

public class CardMovement : MonoBehaviour
{
	#region Animation CONSTANTS
	AnimationCurve animMoveCurve;

	AnimationCurve animFlipCurve;

	AnimationCurve riseCurve;

	AnimationCurve fallCurve;

	AnimationCurve bezierCurve;

	public float raiseHeight;
	#endregion

	private const float shortTime = 0.2f;
	private const float mediumTime = 0.35f;
	private const float longTime = 0.6f;

	private const float cardRatio = 0.66f;

	private bool isShaking;

	private void Start()
	{
		animMoveCurve = MemoryController.Instance.animMoveCurve;
		animFlipCurve = MemoryController.Instance.animFlipCurve;
		riseCurve = MemoryController.Instance.riseCurve;
		fallCurve = MemoryController.Instance.fallCurve;
		raiseHeight = MemoryController.Instance.cardHeight;
		bezierCurve = MemoryController.Instance.bezierCurve;
	}


	public void Raise(float height = 0.5f, float time=longTime)
	{
		if (riseCurve != null)
		{
			LeanTween.moveY(gameObject, height, time).setEase(riseCurve);
		}
		else
		{
			LeanTween.moveY(gameObject, height, time).setEaseInOutCubic();
		}
	}

	public void Lower(float time=mediumTime)
	{
		if(fallCurve != null)
		{
			LeanTween.moveY(gameObject, 0, time).setEase(fallCurve);
		}
		else
		{
			LeanTween.moveY(gameObject, 0, time).setEaseInCubic();
		}

		AudioManager.Instance.Play("effect_tap");
	}

	public void SlamDown()
	{

	}

	public void Rotate(float time)
	{
		bool flipped = GetComponent<Card>().flipped;

		if (flipped == false)
		{
			if(animFlipCurve != null)
			{
				LeanTween.rotate(gameObject, new Vector3(0, 0, 180.01f), time).setEase(animFlipCurve);
			}
			else
			{
				LeanTween.rotate(gameObject, new Vector3(0, 0, 180.01f), time).setEaseInOutQuint();
			}

			GetComponent<Card>().flipped = true;
		}
		else
		{
			if (animFlipCurve != null)
			{
				LeanTween.rotate(gameObject, new Vector3(0, 0, 0), time).setEase(animFlipCurve);
			}
			else
			{
				LeanTween.rotate(gameObject, new Vector3(0, 0, 0), time).setEaseInOutQuint();
			}

			GetComponent<Card>().flipped = false;
		}
		// Play Audio
		AudioManager.Instance.Play("effect_flip");
	}

	public void FullFlip()
	{
		StartCoroutine(FullFlipRoutine());
	}

	private IEnumerator FullFlipRoutine()
	{
		Raise(raiseHeight, shortTime);
		yield return new WaitForSecondsRealtime(shortTime / 3f);
		Rotate(longTime);
		yield return new WaitForSecondsRealtime(shortTime * 2f);
		Lower(shortTime);
		yield return new WaitForSecondsRealtime(shortTime);

		Camera.main.GetComponent<CameraShake>().Shake(shortTime, 0.02f);
	}

	public void MoveTo(float x, float y)
	{
		if (animMoveCurve != null)
		{
			LeanTween.move(gameObject, new Vector3(x * cardRatio, transform.position.y, y), mediumTime).setEase(animMoveCurve);
		}
		else
		{
			LeanTween.move(gameObject, new Vector3(x * cardRatio, transform.position.y, y), mediumTime).setEaseInOutCubic();
		}
	}

	public void MoveToDealing(float x, float y)
	{
		// Add sound effect for delaing cards.
		LeanTween.move(gameObject, new Vector3(x *  cardRatio, transform.position.y, y), longTime * 2).setEaseOutExpo();
	}

	public void MoveBezier(Vector3 self, Vector3 p1, Vector3 p2, Vector3 end, AnimationCurve curve=null)
	{
		StartCoroutine(MoveBezierRoutine(self, p1, p2, end, curve));
	}

	private IEnumerator MoveBezierRoutine(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, AnimationCurve curve=null)
	{
		float t = 0;
		Bezier bez = new Bezier();
		AnimationCurve animCurve;

		if (curve != null)
		{
			animCurve = curve;
		}
		else
		{
			animCurve = bezierCurve;
		}


		while (t < 1)
		{
			float CurvePos = animCurve.Evaluate(t);
			Vector3 pos = bez.CalculateBezierPoint(CurvePos, p0, p1, p2, p3);
			transform.position = pos;

			t += Time.unscaledDeltaTime;
			yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
		}

		// Makes sure the final position is reached is reached.
		transform.position = p3;
	}


	// Methods below only affect the card's graphics and not the "actual" position of the card.

	public void Shake(float time, float intensity, bool growing=false)
	{
		if (isShaking) { return; }

		Transform childBody = null;

		foreach(Transform child in transform)
		{
			if(child.CompareTag("CardModel"))
			{
				childBody = child;
			}
		}

		if(childBody == null)
		{
			Debug.Log("The card does not have a child object to shake");
			return;
		}

		StartCoroutine(ShakeRoutine(childBody, time, intensity, growing));


	}

	private IEnumerator ShakeRoutine(Transform body, float time, float _intensity, bool growing)
	{
		Vector3 originalPos = body.position;
		float goalIntensity = _intensity;
		float intensity = goalIntensity;
		float duration = time;

		while(duration > 0)
		{
			if (growing)
			{
				intensity += (time / Time.unscaledDeltaTime);
			}

			float x = Random.Range(-1f, 1f) * intensity;
			float y = Random.Range(-1f, 1f) * intensity;
			float z = Random.Range(-1f, 1f) * intensity;

			transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z + z);

			duration -= Time.unscaledDeltaTime;
			yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);

		}

		transform.position = originalPos;

		isShaking = false;
	}
}
