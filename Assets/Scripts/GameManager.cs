using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int level;
    public int skill = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _levelText;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Material _skilledBallRef;
    void Start()
    {
        score = PlayerPrefs.GetInt("lastScore");
        _scoreText.text = score.ToString();
        level = PlayerPrefs.GetInt("level");
        if (level < 1) {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }
        _levelText.text = "Level: " + level.ToString();
    }

    void Update()
    {
        
    }

    public void GameScore(int ringScore)
    {
        if (skill > 2) {
            ringScore += skill - 1;
        }
        Debug.Log(ringScore);
        score += ringScore;
        _scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        level = level + 1;
        PlayerPrefs.SetInt("level", level);
        _levelText.text = "Level: " + level.ToString();
        SceneManager.LoadScene(0);
    }

    public void AddSkill(int n)
    {
        skill = skill + n;
        if (skill == 4)
        {
            _ball.GetComponent<Renderer>().material = _skilledBallRef;
        }
        Debug.Log(skill);
    }

    public void RemoveSkill() { skill = 0; }
}
