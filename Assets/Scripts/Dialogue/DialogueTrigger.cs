using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Shape")] [SerializeField]
    protected GameObject visualShape;

    [Header("Ink Json")] [SerializeField] protected TextAsset inkJson;

    protected bool playerInRange;

    private void Awake()
    {
        visualShape.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().DialoguePlaying)
        {
            if (InputManager.GetInstance().GetDialoguePressed())
            {
                 DialogueManager.GetInstance().EnterDialogueMode(inkJson);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.GetComponent<Player>())
        {
            playerInRange = true;
            visualShape.SetActive(true);
            visualShape.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.GetComponent<Player>())
        {
            playerInRange = false;
            visualShape.SetActive(false);
            StartCoroutine(DialogueManager.GetInstance().ExitDialogueMode());
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