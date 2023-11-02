using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float xSpeed = -5;
    private float ySpeed;
    private float constSpeed;
    private GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(":)"))
        {
           gm.playerScored();
        }
        else if (collision.CompareTag(":("))
        {
            gm.aiScored();
        }
        ResetBall();
        Invoke("LaunchBall", 2);
    }

    private void ResetBall()
    {
        gameObject.transform.position = Vector3.zero;
        _rb.velocity = Vector2.zero;
    }

    private void LaunchBall()
    {
        ySpeed = Random.Range(-4f, 4f);
        _rb.velocity = new Vector2(xSpeed, ySpeed);
        constSpeed = Mathf.Sqrt(xSpeed * xSpeed + ySpeed * ySpeed);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("difficulty", 0) == 1)
            xSpeed *= 2;
        gm = FindObjectOfType<GameManager>();
        Invoke("LaunchBall", 2);
    }

    void FixedUpdate()
    {
        if(gm.isGameOver)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
        _rb.velocity = _rb.velocity.normalized * constSpeed;
    }
}