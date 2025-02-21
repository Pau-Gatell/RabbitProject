
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager INSTANCE;

    public string activeLevel;
    public string defaultLevel;

    void Start()
    {
        INSTANCE = this;
        LoadLevel(defaultLevel);
    }

    public void LoadLevel(string levelName, bool loadGame = false)
    {
        StartCoroutine(levelName, loadGame);
    }

  
    public string GetActiveLevel()
    {
        return activeLevel;
    }
}

