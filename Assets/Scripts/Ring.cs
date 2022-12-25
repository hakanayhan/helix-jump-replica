using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    private GameManager _gm;
    void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        GameObject ballG = GameObject.FindGameObjectWithTag("Ball");
        _ball = ballG.transform;
    }

    void Update()
    {
        if(transform.position.y - 0.3f > _ball.position.y)
        {
            Destroy(gameObject);
            _gm.AddSkill(1);
            _gm.GameScore(2);
        }
    }
}
