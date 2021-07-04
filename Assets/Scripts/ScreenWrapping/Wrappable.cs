using UnityEngine;

public class Wrappable : MonoBehaviour
{
    private ScreenWrapper _screenWrapper;

    private void Awake()
    {
        _screenWrapper = FindObjectOfType<ScreenWrapper>();
    }

    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            _screenWrapper.RegisterWrappable(this);
        }
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            _screenWrapper.UnRegisterWrappable(this);
        }
    }
}
