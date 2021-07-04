using UnityEngine;

//If project would grow i should create seperate class for variable storage to better encapsulation
//https://github.com/skillitronic/MyTools/tree/main/Assets/Scripts/Save%20System
public static class HighScoreSaver 
{
    public static void SaveScore(int value)
    {
        PlayerPrefs.SetInt("score", value);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt("score");
    }
}
