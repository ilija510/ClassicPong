using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float ySpeed = 2;
    void Start()
    {
        if (PlayerPrefs.GetInt("difficulty", 0) == 1)
            ySpeed = 4;
        gm = FindObjectOfType<GameManager>();
        _rb.velocity = Vector2.zero;
    }

    void Update()
    {
        if (gm.isGameOver)
            return;
        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = new Vector2(0, ySpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = new Vector2(0, -ySpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = new Vector2(ySpeed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }
}
