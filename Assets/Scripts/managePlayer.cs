using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managePlayer : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;

    public static int numberOfCoins;
    public Text seedText;

    public static bool isGameStarted;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seedText.text = "Seeds: " + numberOfCoins;
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
