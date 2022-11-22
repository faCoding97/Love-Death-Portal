using System;
using UnityEngine;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.
[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private Vector2 _moveDirection = Vector2.zero;
    private bool _dialoguePressed;

    private bool _interactPressed;

    // private bool _escapePressed;
    private bool _gameIsPaused;
    private static InputManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }

        _instance = this;
    }

    public static InputManager GetInstance()
    {
        return _instance;
    }


    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactPressed = true;
        }
        else if (context.canceled)
        {
            _interactPressed = false;
        }
    }

    public void DialoguePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dialoguePressed = true;
        }
        else if (context.canceled)
        {
            _dialoguePressed = false;
        }
    }

    public void EscapePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pausePanel.SetActive(!_gameIsPaused);
            _gameIsPaused = !_gameIsPaused;
            PauseGame();
        }
    }

    public Vector2 GetMoveDirection()
    {
        return _moveDirection;
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again.
    public bool GetInteractPressed()
    {
        bool result = _interactPressed;
        _interactPressed = false;
        return result;
    }

    public bool GetDialoguePressed()
    {
        bool result = _dialoguePressed;
        _dialoguePressed = false;
        return result;
    }

    void PauseGame()
    {
        Time.timeScale = _gameIsPaused ? 0 : 1;
    }
}


/*
                                                                   88
88888888889                     .8888.        					   88     00					
888                          .88	 "88						   88		    00.					   9
888           .8888.       88				  .8888.	    .888888I	  88	88888888.   	 .88880*
8888889     `P   )888     88				0"      0.    0"       88	  88	88	   88     6"       "9   
888           .oF"888      88			   0"        .0  0"         .0	  88	88	   88    6(         )9  
888         B8(    888      "88	      .88   0"      .0    0"       .0     88	88	   88     6"       .9   
889   	    `Y888""89	       "88888"		 "8888"        "8888""Y 89.	  88    88     "89     "8888888"  
                                                                                                     "89
                                                                                             68(       )89
                                                                                              68.     .89
                                                                                                 "6889"               
https://www.linkedin.com/in/farazaghababayi         
*/