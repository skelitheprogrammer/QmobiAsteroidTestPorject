using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gamePlayScoreText;
    [SerializeField] private TextMeshProUGUI _endScoreText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdateGamePlayScoreUI()
    {
        _gamePlayScoreText.SetText($"Score \n{_gameManager.Score}");

    }

    public void UpdateEndScoreUI()
    {
        _endScoreText.SetText($"Score: {_gameManager.Score}");
    }
}
