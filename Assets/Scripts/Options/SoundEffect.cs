using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour, IChangeValue
{
    [Header("TextMeshPros and Sliders \nSound Effect:")] [SerializeField]
    private Slider slider;

    [SerializeField] private TextMeshProUGUI textMeshPro;
    private float _floutValueSlider;
    private readonly string _playerPrefsKey = "SoundEffectPlayerPrefs";

    private void Awake()
    {
        slider.onValueChanged.AddListener(value =>
        {
            _floutValueSlider = value;
            textMeshPro.text = _floutValueSlider.ToString("0");
            Changer(_floutValueSlider);
        });
    }

    private void Changer(float indexUsed)
    {
    }

    private void OnEnable()
    {
        Apply.Save += SaveChanges;
        Cancel.ActionEventChang += ChangeCurrentValue;
        if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            slider.value = PlayerPrefs.GetFloat(_playerPrefsKey);
        }
    }

    private void OnDisable()
    {
        Apply.Save -= SaveChanges;
        Cancel.ActionEventChang -= ChangeCurrentValue;
        PlayerPrefs.Save();
    }

    private void SaveChanges()
    {
        PlayerPrefs.SetFloat(_playerPrefsKey, _floutValueSlider);
        PlayerPrefs.Save();
    }
    
    private void ChangeCurrentValue(bool iaCheng)
    {
        if (iaCheng)
            SaveChanges();
        else
        {
            slider.value =
                PlayerPrefs.HasKey(_playerPrefsKey) ? PlayerPrefs.GetFloat(_playerPrefsKey) : 1;
        }
    }

    public bool HaveChanges() => Math.Abs(PlayerPrefs.GetFloat(_playerPrefsKey) - slider.value) != 0;
}