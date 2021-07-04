using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            gameManager.IncreaseScore(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerManager.Die();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HighScoreSaver.SaveScore(gameManager.HighScore);
        }
    }
}
