using System.Collections;
using TMPro;
using UnityEngine;
using Ink.Runtime;


public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    [Header("Dialogue UI")] [SerializeField]
    private GameObject dialoguePanel;

    // for TextMeshProUGUI we need =>  using TMPro;
    [SerializeField] private TextMeshProUGUI dialogueText;

    // for story we need =>  using Ink.Runtime;
    private Story _story;

    public bool DialoguePlaying { get; private set; }


    private void Awake()
    {
        // Show Warning when play a game and we doesn't instance to DialogueManager 
        if (_instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue manager in the scene");
        }

        _instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        DialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!DialoguePlaying)
        {
            return;
        }
        
        if (InputManager.GetInstance().GetDialoguePressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        _story = new Story(inkJson.text);
        DialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }


    // we display our dialogue
    private void ContinueStory()
    {
        if (_story.canContinue)
        {
            //set text for current dialogue line
            dialogueText.text = _story.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    public IEnumerator ExitDialogueMode()
    {
        DialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        yield return new WaitForSeconds(.2f);
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