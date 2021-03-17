using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config param.
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSound;
    
    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    Rigidbody2D tBody;

    // cached component references

    AudioSource myAudioSource;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        tBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            tBody.velocity = new Vector2(tBody.velocity.x, 0);
        }
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            tBody.velocity = new Vector2(xPush, yPush);
        }
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            myAudioSource.PlayOneShot(clip);


            if (Mathf.Abs(tBody.velocity.x) < 0.14f)
            {
                tBody.velocity = new Vector2(3, tBody.velocity.y);
                
            }
            if(Mathf.Abs(tBody.velocity.y) < 0.14f)
            {
                tBody.velocity = new Vector2(tBody.velocity.x, 3);
                
            }

        }
        

    }
        
}
