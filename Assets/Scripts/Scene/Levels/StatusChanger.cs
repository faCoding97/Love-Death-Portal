using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChanger : MonoBehaviour
{
    [Header("Main Scenes:")] [SerializeField]
    private GameObject leftScene;

    [SerializeField] private GameObject rightScene;

    [Header("Portals in left scene:")] [SerializeField]
    private GameObject bluePortal;

    [SerializeField] private GameObject purplePortal;
    [SerializeField] private GameObject redPortal;

    [Header("Sub Scenes in right scene:")] [SerializeField]
    private GameObject secondScene;

    [SerializeField] private GameObject thirdScene;
    [SerializeField] private GameObject forthScene;

   

    private int _status;

    private void Awake()
    {
        _status = 0;

        leftScene.SetActive(true);
       
        bluePortal.SetActive(true);
        purplePortal.SetActive(false);
        redPortal.SetActive(false);

        rightScene.SetActive(false);
        secondScene.SetActive(true);
        thirdScene.SetActive(false);
        forthScene.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.GetComponent<Player>())
        {
            if (_status == 0)
            {
                leftScene.SetActive(false);
                bluePortal.SetActive(false);
                purplePortal.SetActive(true);
                rightScene.SetActive(true);
                _status++;
            }

            if (_status == 2)
            {
                leftScene.SetActive(true);
                rightScene.SetActive(false);
                secondScene.SetActive(false);
                thirdScene.SetActive(true);
                _status++;
            }

            if (_status == 4)
            {
                leftScene.SetActive(false);
                purplePortal.SetActive(false);
                redPortal.SetActive(true);
                rightScene.SetActive(true);
                _status++;
            }

            if (_status == 6)
            {
                leftScene.SetActive(true);
                rightScene.SetActive(false);
                thirdScene.SetActive(false);
                forthScene.SetActive(true);
                _status++;
            }

            if (_status == 8)
            {
                leftScene.SetActive(false);
                rightScene.SetActive(true);
                _status++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.GetComponent<Player>())
        {
            if (_status is 1 or 3 or 5 or 7)
            {
                _status++;
            }
        }
    }
}