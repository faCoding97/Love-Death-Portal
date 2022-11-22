using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _taglle;


    public void TagglePause()
    {
        _pausePanel.SetActive(!_taglle);
    }
}
