using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveAbility : MonoBehaviour
{
    [Header("Movement Params")] [SerializeField]
    private float walkSpeed = 10f;

    // other
    private IAnimationController _mecanimController;

    // components attached to player
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _mecanimController = GetComponent<IAnimationController>();
        
    }


    private void FixedUpdate()
    {
        HandleHorizontalMovement();
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        _mecanimController.PlayWalking(Convert.ToBoolean(moveDirection.x));
        _rigidbody2D.velocity = new Vector2(moveDirection.x * walkSpeed, _rigidbody2D.velocity.y);
        RotateTowardsDirection(moveDirection.x);
    }


    private void RotateTowardsDirection(float direction)
    {
        if (direction > 0)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (direction < 0)
        {
            _transform.rotation = Quaternion.Euler(0, 180, 0);
        }
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