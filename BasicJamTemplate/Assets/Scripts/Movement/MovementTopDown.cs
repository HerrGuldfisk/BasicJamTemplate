using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class MovementTopDown : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	public bool advancedMovement = false;
	[ConditionalHide("advancedMovement", true)]
	public float acceleration = 2;
	[ConditionalHide("advancedMovement", true)]
	public float deceleration = 1;

	private Vector2 inputDirection;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
    }

	// Update is called once per frame
	void FixedUpdate()
    {
		if (advancedMovement)
		{
			AdvancedMovement();
		}
    }

	public void OnMove(InputValue value)
	{
		inputDirection = value.Get<Vector2>();
		MovePlayer();
	}

	private void MovePlayer()
	{
		if (!advancedMovement)
		{
			BasicMovement();
		}
	}

	private void BasicMovement()
	{
		rb.velocity = new Vector2(inputDirection.x, inputDirection.y) * speed;
	}

	private void AdvancedMovement()
	{
		Vector2 tempSpeed = rb.velocity;

		if (inputDirection.magnitude > 0)
		{
			if (tempSpeed.magnitude <= speed)
			{
				float factor;
				float degree = Vector2.Angle(rb.velocity, inputDirection);

				if (degree >= 90)
				{
					factor = 0;
				}
				else
				{
					factor = Mathf.Cos(Mathf.Deg2Rad * degree);
				}

				Vector2 tempAcc = inputDirection * (speed - tempSpeed.magnitude * factor) * acceleration * Time.fixedDeltaTime;

				if((rb.velocity + tempAcc).magnitude >= speed)
				{
					rb.velocity = rb.velocity.normalized * speed;
				}
				else
				{
					rb.velocity += tempAcc;
				}

			}
		}
		else
		{
			if (rb.velocity.magnitude == 0) { return; }
			rb.velocity -= rb.velocity * deceleration * Time.fixedDeltaTime;

			if(rb.velocity.magnitude <= 0.01f)
			{
				rb.velocity = Vector2.zero;
			}
		}




	}


	public void OnJump()
	{

	}

	public void OnAction()
	{

	}

	public void OnShift()
	{

	}
}
