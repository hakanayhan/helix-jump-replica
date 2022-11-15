using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        GameObject ballG = GameObject.FindGameObjectWithTag("Ball");
        ball = ballG.transform;
    }

    void Update()
    {
        if(transform.position.y - 0.5f > ball.position.y)
        {
            Destroy(gameObject);
            gm.GameScore(25);
        }
    }
}
