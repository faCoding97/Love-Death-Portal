using UnityEngine;

public class Apply : MonoBehaviour
{
    public delegate void ApplyAction();
    public static event ApplyAction Save;
    
    public void OnClick()
    {
        Save ?.Invoke();
    }
}
