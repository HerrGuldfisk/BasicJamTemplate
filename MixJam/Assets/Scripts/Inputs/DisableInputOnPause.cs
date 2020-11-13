using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DisableInputOnPause : MonoBehaviour
{

	private bool inMenu;
	private PlayerInput input;

    // Start is called before the first frame update
    void Awake()
    {
		GameManager.Instance.onPause.AddListener(Toggle);
		input = GetComponent<PlayerInput>();
    }

	private void Toggle()
	{
		if (inMenu)
		{
			inMenu = false;
			input.ActivateInput();
		}
		else
		{
			inMenu = true;
			input.DeactivateInput();
		}
	}
}
