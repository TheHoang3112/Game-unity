using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image liveImageDisplay;
    public Text scoreText;
    public GameObject titleScreen;
    private int score = 0;
    public void UpdateLives(int currentLives)
    {
        score += 5;
        liveImageDisplay.sprite = lives[currentLives];

    }
    public void UpdateScore()
    {
        

        scoreText.text = "Score: " + score;
    }
    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }
    public void HidingTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }
}
