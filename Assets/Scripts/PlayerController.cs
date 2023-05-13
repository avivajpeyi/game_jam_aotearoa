using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
///
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] ScriptableEvents _eventsSO;

    public float jumpAmount = 35;
    public float currentGravityScale = 10;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public static bool isGrounded;
    public static bool isMovingUp;
    
    bool canJump = true; // for 2d movement
    bool canMoveSideways = true; // for 3d movement


    public float distanceToCheck = 2f;
    public RaycastHit hit;

    
    
    public float[] floorBounds = {-5, 5};

    
    
    // TODO: maybe make the player a static variable so we don't have to find it every time?

    bool alive = true;

    public float speed = 10;
    Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;


    float travelDistance = 0; // distance travelled from start
    Vector3 startPos;

    Collider col2d;
    Collider col3d;

    [SerializeField] float scoreBase = 1;

    
    
    

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        col3d = GameObject.Find("3dCollider").GetComponent<Collider>();
        col2d = GameObject.Find("2dCollider").GetComponent<Collider>();
        // SwitchTo3d();

        ScriptableEvents.eventActivate2D += SwitchTo2d;
        ScriptableEvents.eventActivate3D += SwitchTo3d;
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= SwitchTo2d;
        ScriptableEvents.eventActivate3D -= SwitchTo3d;
    }
    
    public void SwitchTo2d()
    {
        canMoveSideways = false;
        canJump = true;
        col2d.enabled = true;
        col3d.enabled = false;
    }
    
    public void SwitchTo3d()
    {
        canMoveSideways = true;
        canJump = false;
        col2d.enabled = false;
        col3d.enabled = true;
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

        
        rb.AddForce(Physics.gravity * (currentGravityScale - 1) * rb.mass);

        // move sideways

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
        
        // prevent player for going past the edge of the map
        if (transform.position.x <= floorBounds[0])
        {
            transform.position = new Vector3(floorBounds[0], transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= floorBounds[1])
        {
            transform.position = new Vector3(floorBounds[1], transform.position.y, transform.position.z);
        }
    }


    private void Jump()
    {
        
        
        rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
        if (rb.velocity.y > 0)
        {
            isMovingUp = true;
            currentGravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            isMovingUp = false;
            currentGravityScale = fallingGravityScale;
        }
        else
        {
            currentGravityScale = gravityScale;
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, out hit, distanceToCheck);
        
        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (transform.position.y < -5)
        {
            Die();
        }

        travelDistance = Vector3.Distance(startPos, transform.position);

        Score();
    }

    public void Score()
    {
        ScriptableEvents.TriggerScoreEvent(scoreBase * Time.deltaTime);
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
        ScriptableEvents.TriggerResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    
    
}