using System;
using UnityEngine;

public class ColliderDetector2D : MonoBehaviour
{
    private static ColliderDetector2D _instance;

    private Collider2D _trigger2D;
    // private Collider2D _triggerEntered2D;
    // private Collider2D _triggeredExited2D;


    private void Awake()
    {
        if (_instance != null)
            Debug.LogError("Found more than one ColliderDetector2D in the scene.");

        _instance = this;
    }

    public static ColliderDetector2D GetInstance() => _instance;


    private void OnTriggerEnter2D(Collider2D other) => _trigger2D = other;
    private void OnTriggerExit2D(Collider2D other) => _trigger2D = other;

    public Collider2D GetOnTriggerEnter2D() => _trigger2D;
    public Collider2D GetOnOnTriggerExit2D() => _trigger2D;
    
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