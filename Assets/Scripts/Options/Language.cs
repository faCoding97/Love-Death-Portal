using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour, IChangeValue
{
    [Header("Language dropdown:")] [SerializeField]
    private TMP_Dropdown tmpDropdown;

    private int _intIndexDropdown;
    private readonly string _playerPrefsKey = "LanguagePlayerPrefs";

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
        StartCoroutine(SetLanguage(indexUsed));
    }


    private IEnumerator SetLanguage(int indexSetLanguage)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indexSetLanguage];
    }

    void OnEnable()
    {
        Apply.Save += SaveChanges;
        Cancel.ActionEventChang += Changer;
        if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            tmpDropdown.value = PlayerPrefs.GetInt(_playerPrefsKey);
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
        PlayerPrefs.SetInt(_playerPrefsKey, _intIndexDropdown);
        PlayerPrefs.Save();
    }

    private void Changer(bool iaCheng)
    {
        if (iaCheng)
            SaveChanges();
        else
        {
            tmpDropdown.value =
                PlayerPrefs.HasKey(_playerPrefsKey) ? PlayerPrefs.GetInt(_playerPrefsKey) : 1;
        }
    }

    public bool HaveChanges() => PlayerPrefs.GetInt(_playerPrefsKey) != tmpDropdown.value;
}