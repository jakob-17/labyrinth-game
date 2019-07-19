using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LabyrinthLevel : MonoBehaviour
{
    public GenerateLevel levelScript;
    public static LabyrinthLevel instance = null;

    private int level = 1;
    
    // Start is called before the first frame update
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        level++;
        InitGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void GameOver()
    {
        enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    void InitGame()
    {
        levelScript.SetupScene(level);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
