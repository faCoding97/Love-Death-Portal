using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resolution : MonoBehaviour, IChangeValue
{
    private readonly List<int> _widths = new() { 800, 1024, 1280, 1366, 1600, 1920, 1980, 2560, 3440, 3840 };
    private readonly List<int> _heights = new() { 600, 768, 1080, 768, 900, 1080, 1200, 1440, 1440, 2160 };

    [Header("Dropdown Resolution: ")] [SerializeField]
    private TMP_Dropdown tmpDropdown;

    private int _intIndexDropdown;
    private readonly string _playerPrefsKeyResolution = "ResolutionPlayerPrefs";


    protected virtual void Awake()
    {
        tmpDropdown.onValueChanged.AddListener(value =>
        {
            _intIndexDropdown = value;
            Changer(_intIndexDropdown);
        });
    }

    private void Changer(int indexUsed)
    {
        Screen.SetResolution(_widths[indexUsed], _heights[indexUsed], Screen.fullScreen);
    }

    public void FullScreen(bool isFull) => Screen.fullScreen = isFull;


    void OnEnable()
    {
        Apply.Save += SaveChanges;
        Cancel.ActionEventChang += Changer;
        if (PlayerPrefs.HasKey(_playerPrefsKeyResolution))
        {
            tmpDropdown.value = PlayerPrefs.GetInt(_playerPrefsKeyResolution);
        }
    }

    void OnDisable()
    {
        Apply.Save -= SaveChanges;
        Cancel.ActionEventChang -= Changer;
        PlayerPrefs.Save();
    }

    private void SaveChanges()
    {
        PlayerPrefs.SetInt(_playerPrefsKeyResolution, _intIndexDropdown);
        PlayerPrefs.Save();
    }


    private void Changer(bool iaCheng)
    {
        if (iaCheng)
            SaveChanges();
        else
        {
            tmpDropdown.value =
                PlayerPrefs.HasKey(_playerPrefsKeyResolution) ? PlayerPrefs.GetInt(_playerPrefsKeyResolution) : 1;
        }
    }

    public bool HaveChanges() =>
        (PlayerPrefs.GetInt(_playerPrefsKeyResolution) != tmpDropdown.value);
}