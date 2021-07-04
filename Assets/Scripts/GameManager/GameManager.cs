using UnityEngine;
using UnityEngine.Events;


//Could use singleton, but not for this project
public class GameManager : MonoBehaviour
{

    [SerializeField] private int _score = 0;
    public int Score => _score;

    public int HighScore { get; private set; }

    [SerializeField] private AudioFile _gameOverAudio;

    [SerializeField] private UnityEvent _OnGameInitEvent;
    public UnityEvent OnGameOverEvent;

    [SerializeField] private UnityEvent _OnScoreChangedEvent;

    private void Awake()
    {
        HighScore = HighScoreSaver.LoadScore();
    }

    private void OnEnable()
    {
        OnGameOverEvent.AddListener(() => AudioSystem.PlaySFX(_gameOverAudio));
        OnGameOverEvent.AddListener(CheckHighScore);
    }

    private void OnDisable()
    {
        OnGameOverEvent.RemoveListener(() => AudioSystem.PlaySFX(_gameOverAudio));
        OnGameOverEvent.RemoveListener(CheckHighScore);
    }

    private void Start()
    {
        _OnGameInitEvent?.Invoke();
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _OnScoreChangedEvent?.Invoke();
    }

    private void CheckHighScore()
    {
        if (Score < HighScore) return;
        
        HighScoreSaver.SaveScore(Score);
    }
}
