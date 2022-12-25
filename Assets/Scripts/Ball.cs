using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _splashPrefab;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _victory;
    [SerializeField] private Material _unskilledBallRef;
    [SerializeField] private Text _victoryText;
    private GameManager _gm;
    int level;
    void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        if (metarialName == "Final Ring (Instance)")
        {
            level = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("lastScore", _gm.score);
            _ball.GetComponent<Ball>()._jumpForce = 0;
            _cylinder.GetComponent<Rotate_Move>().enabled = false;
            _victoryText.text = "Level " + level + " Cleaned";
            _victory.SetActive(true);
        }
        else if (_gm.skill > 2)
        {
            _rb.velocity = Vector3.up * _jumpForce;
            _ball.GetComponent<Renderer>().material = _unskilledBallRef;
            _gm.RemoveSkill();
            Destroy(other.transform.parent.gameObject);
            return;
        }
        else if (metarialName == "Unsafe Color (Instance)")
        {
            PlayerPrefs.SetInt("lastScore", 0);
            _ball.GetComponent<Ball>()._jumpForce = 0;
            _cylinder.GetComponent<Rotate_Move>().enabled = false;
            _gameOver.SetActive(true);
            //_gm.RestartGame();
        }
        else if (metarialName == "Safe Color (Instance)")
        {
            _gm.RemoveSkill();
        }
        _rb.velocity = Vector3.up * _jumpForce;
        GameObject splash = Instantiate(_splashPrefab, transform.position + new Vector3(0, -0.2f, 0), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
    }
}
