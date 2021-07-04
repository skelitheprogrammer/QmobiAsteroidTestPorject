using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeReference] private TextMeshProUGUI _highScoreText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdateHighScoreUI()
    {
        _highScoreText.SetText($"HighScore \n{_gameManager.HighScore}");
    }
}
