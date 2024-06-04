using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managePlayer : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;

    public static bool isGameStarted;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            isGameStarted = false;
        }
        if(isGameStarted)
        {
            startGamePanel.SetActive(false);
        }
    }
}
