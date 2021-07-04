using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelLoad : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int levelIndex;

    private void Awake()
    {
        _button.onClick.AddListener(() => LevelLoader.LoadLevel(levelIndex));
    }
}
