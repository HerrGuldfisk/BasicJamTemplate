using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : MonoBehaviour
{
	public Vector2 mousePos;

	bool hover;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnMousePosition(InputValue value)
	{
		mousePos = value.Get<Vector2>();

		if (GameManager.Instance.gameInputAllowed == false) { return; }

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mousePos);
		if (Physics.Raycast(ray, out hit, 100f))
		{
			// If the clicked object is a card.
			if (hit.transform.GetComponentInParent<Card>())
			{
				if (!hover)
				{
					AudioManager.Instance.Play("effect_hover");
				}
				hover = true;
			}
		}
		else
		{
			Debug.Log("Not hovering");
			hover = false;
		}
	}

	public void OnLeftClick(InputValue value)
	{
		if (GameManager.Instance.gameInputAllowed == false) { return; }

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mousePos);
		if (Physics.Raycast(ray, out hit, 100f))
		{
			// If the clicked object is a card.
			if(hit.transform.GetComponentInParent<Card>())
			{
				hit.transform.GetComponentInParent<Card>().Clicked();
			}
		}
	}

	public void OnRightClick(InputValue value)
	{

	}

	private Vector2 MouseToWorld()
	{
		return Camera.main.ScreenToWorldPoint(mousePos);
	}
}
