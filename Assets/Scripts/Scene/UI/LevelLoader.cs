using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float _transitionTime = 2f;
    private static readonly int Start = Animator.StringToHash("Start");
    [SerializeField] private bool flag;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Animation
        transition.SetTrigger(Start);

        // Waite
        yield return new WaitForSeconds(_transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    public void OnPlay()
    {
        if (flag)
        {
            transition.SetTrigger(Start);
        }
    }
}