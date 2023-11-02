using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] Transform _ballTransform;
    [SerializeField] Rigidbody2D MyRigidbody;
    [SerializeField] float ySpeed = 2;
    void Start()
    {
        if (PlayerPrefs.GetInt("difficulty", 0) == 1)
            ySpeed = 4;
        gm = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        if (gm.isGameOver)
            return;
        float myY = transform.position.y;
        float ballY = _ballTransform.position.y;
        float diff = Mathf.Abs(myY - ballY);
        if (diff > 0.2)
        {
            
                if (myY < ballY)
                    MyRigidbody.velocity = new Vector2(0, ySpeed);
                else if (myY > ballY)
                    MyRigidbody.velocity = new Vector2(0, -ySpeed);
                else
                    MyRigidbody.velocity = Vector2.zero;
            
        }
        else
            MyRigidbody.velocity = Vector2.zero;
    }
    void Update()
    {
        
    }
}
