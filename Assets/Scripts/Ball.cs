using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;
    public GameObject ball;
    public GameObject cylinder;
    public GameObject gameOver;
    public GameObject victory;
    public Text victoryText;
    int level;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        if (metarialName == "Unsafe Color (Instance)")
        {
            ball.GetComponent<Ball>().jumpForce = 0;
            cylinder.GetComponent<Rotate_Move>().enabled = false;
            gameOver.SetActive(true);
            //gm.RestartGame();
        }
        else if (metarialName == "Final Ring (Instance)")
        {
            level = PlayerPrefs.GetInt("level");
            ball.GetComponent<Ball>().jumpForce = 0;
            cylinder.GetComponent<Rotate_Move>().enabled = false;
            victoryText.text = "Level " + level + " Cleaned";
            victory.SetActive(true);
        }
        rb.velocity = Vector3.up * jumpForce;
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0,-0.2f,0), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
    }
}
