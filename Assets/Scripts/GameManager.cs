using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text levelText;
    public int level;
    public int skill = 0;
    void Start()
    {
        score = PlayerPrefs.GetInt("lastScore");
        scoreText.text = score.ToString();
        level = PlayerPrefs.GetInt("level");
        if (level < 1) {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }
        levelText.text = "Level: " + level.ToString();
    }

    void Update()
    {
        
    }

    public void GameScore(int ringScore)
    {
        score += ringScore;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        level = level + 1;
        PlayerPrefs.SetInt("level", level);
        levelText.text = "Level: " + level.ToString();
        SceneManager.LoadScene(0);
    }

    public void addSkill(int n)
    {
        skill = skill + n;
        Debug.Log(skill);
    }

    public void removeSkill()
    {
        skill = 0;
    }
}
