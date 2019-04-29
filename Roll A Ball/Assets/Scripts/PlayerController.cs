using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Text scoreText;
    public Text victoryText;

    private Rigidbody ball;
    private int score;

    void Start()
    {
        ball = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
        victoryText.text = "";
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.acceleration.x;
        float verticalMove = Input.acceleration.y;

        Vector3 ballMovementForce = new Vector3(horizontalMove, 0.0f, verticalMove);
        ball.AddForce(ballMovementForce * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            setCountText();
        }
    }

    void setCountText()
    {
        scoreText.text = "Score:" + score.ToString();
        if(score >= 11)
        {
            victoryText.text = "You Win!";
        }
    }
}
