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
	void Update()
    {
		if (advancedMovement)
		{
			AdvancedMovement();
		}
    }

	public void OnMove(InputValue value)
	{
		inputDirection = value.Get<Vector2>();
		Debug.Log(inputDirection);
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



	}


	public void OnJump()
	{

	}
}
