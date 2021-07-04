using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static void LoadLevel(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);
    }

    public static void LoadLevelByName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
