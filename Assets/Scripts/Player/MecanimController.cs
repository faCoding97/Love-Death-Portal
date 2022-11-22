using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MecanimController : MonoBehaviour, IAnimationController
{
    private Animator _animator;

    private readonly int _walkBoolVar = Animator.StringToHash("Walk");
    private readonly int _suicide = Animator.StringToHash("Suicide");

    private void Awake()
    {
        _animator ??= GetComponent<Animator>();
    }

    public void PlayWalking(bool isPlay)
    {
        _animator.SetBool(_walkBoolVar, isPlay);
    }

    public void PlaySuicide(bool isPlay)
    {
        _animator.SetBool(_suicide, isPlay);
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