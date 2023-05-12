using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    
    

    bool canJump = true; // for 2d movement
    bool canMoveSideways = true; // for 3d movement


    // TODO: maybe make the player a static variable so we don't have to find it every time?

    bool alive = true;

    public float speed = 10;
    Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;



    float travelDistance = 0; // distance travelled from start
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!alive) return;
        
        // always move forward
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = Vector3.zero;
        
        
        if (canMoveSideways)
        {
            horizontalMove = transform.right * horizontalInput * speed *
                                     Time.fixedDeltaTime * horizontalMultiplier;
        }

        // move sideways
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }


    private void Jump()
    {
        Debug.Log("Jump boi");
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        
        if (transform.position.y < -5)
        {
            Die();
        }
        
        travelDistance = Vector3.Distance(startPos, transform.position);
        
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        Debug.Log("get rekt u fokin noob");
        // TODO: maybe make a game manager class to handle this?
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}