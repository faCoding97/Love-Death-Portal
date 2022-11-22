using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;


public class Cancel : MonoBehaviour
{
    private List<IChangeValue> _list;

    public static event Action<bool> ActionEventChang;

    [SerializeField] private GameObject panelChanger;


    private void Awake()
    {
        _list = new List<IChangeValue>();
        var ofType = FindObjectsOfType<MonoBehaviour>().OfType<IChangeValue>();
        foreach (IChangeValue s in ofType)
        {
            _list.Add(s);
        }
    }

    public void OnClick()
    {
        foreach (var variable in _list)
        {
            if (variable.HaveChanges())
            {
                panelChanger.SetActive(true);
            }
        }
    }


    public void Question(bool answer) => ActionEventChang?.Invoke(answer);
}