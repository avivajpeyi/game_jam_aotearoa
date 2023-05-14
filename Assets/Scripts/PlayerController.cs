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
    float jumpAmount = 35;
    float currentGravityScale = 10;
    float gravityScale = 10;
    float fallingGravityScale = 40;
    public static bool isGrounded;
    public static bool canMoveLeft;
    public static bool canMoveRight;
    private Transform t;

    public bool nudgeMode = true;

    bool canJump = false; // for 2d movement
    bool canMoveSideways = true; // for 3d movement


    public float distanceToCheck = 2f;
    public RaycastHit hit;
    [SerializeField] public Transform[] isGroundedPtsFront;
    [SerializeField] public Transform[] isGroundedPtsBack;


    public float[] floorBounds = { -5, 5 };

    bool alive = true;

    public float speed = 10;
    Rigidbody rb;

    public float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    Vector3 startPos;
    Collider col2d;
    Collider col3d;

    [SerializeField] float scoreBase = 1;


    private void Start()
    {
        t = transform;
        startPos = t.position;
        rb = GetComponent<Rigidbody>();
        col3d = GameObject.Find("3dCollider").GetComponent<Collider>();
        col2d = GameObject.Find("2dCollider").GetComponent<Collider>();
        ScriptableEvents.eventActivate2D += SwitchTo2d;
        ScriptableEvents.eventActivate3D += SwitchTo3d;
        ScriptableEvents.endGame += Die;
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= SwitchTo2d;
        ScriptableEvents.eventActivate3D -= SwitchTo3d;
        ScriptableEvents.endGame -= Die;
    }


    private void Update()
    {
        if (!alive) return;
        CheckGrounded();

        if (canMoveSideways)
        {
            if (nudgeMode)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (horizontalInput < 0)
                        horizontalInput = 1;
                    else
                        horizontalInput = -1;
                }
            }
            else
            {
                horizontalInput = Input.GetAxis("Horizontal");
            }
        }


        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PlayerController: Jump!");
            Jump();
        }

        if (transform.position.y < -5)
            Die();
        Score();
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        float dx = speed * Time.fixedDeltaTime;
        Vector3 forwardMove = dx * t.forward;
        Vector3 hoirzMove = Vector3.zero;

        if (canMoveSideways)
        {
            float x = t.position.x;
            float minx = floorBounds[0] + 2f;
            float maxx = floorBounds[1] - 2f;
            hoirzMove = horizontalInput * dx * horizontalMultiplier * t.right;
            if (minx >= x)
            {
                canMoveLeft = false;
                if (horizontalInput < 0)
                    hoirzMove = Vector3.zero;
            }
            else if (maxx <= x)
            {
                canMoveRight = false;
                if (horizontalInput > 0)
                    hoirzMove = Vector3.zero;
            }
            else
            {
                canMoveLeft = true;
                canMoveRight = true;
            }
        }

        rb.MovePosition(rb.position + forwardMove + hoirzMove);

        rb.AddForce((currentGravityScale - 1) * rb.mass * Physics.gravity);
    }


    public void SwitchTo2d()
    {
        // move the chumken up a bit
        t.position = new Vector3(t.position.x, t.position.y + 1, t.position.z);
        canMoveSideways = false;
        canMoveLeft = false;
        canMoveRight = false;
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


    void CheckGrounded()
    {
        
        LayerMask mask = LayerMask.GetMask("Floor");
        bool front = Physics.Linecast(isGroundedPtsFront[0].position,
            isGroundedPtsFront[1].position, out hit, mask); 
        
        if (front)
        {
            Debug.Log("PlayerController: front CheckGrounded: " + hit.collider.name);
        }
        
        bool back = Physics.Linecast(isGroundedPtsBack[0].position,
            isGroundedPtsBack[1].position, out hit,mask);
        
        if (back)
        {
            Debug.Log("PlayerController: front CheckGrounded: " + hit.collider.name);
        }
        
        isGrounded = front || back;

        Debug.Log(
            "PlayerController: CheckGrounded: " + isGrounded + " front: " + front + " back: " + back);
        
    }

    private void OnDrawGizmos()
    {
        if (!alive)
            return;
        // if Grounded, draw a green, otherwise red, sphere above player
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.up * distanceToCheck, 0.1f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(isGroundedPtsFront[0].position, isGroundedPtsFront[1].position);
        Gizmos.DrawLine(isGroundedPtsBack[0].position, isGroundedPtsBack[1].position);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
        if (rb.velocity.y > 0)
            currentGravityScale = gravityScale;
        else if (rb.velocity.y < 0)
            currentGravityScale = fallingGravityScale;
        else
            currentGravityScale = gravityScale;
    }


    public void Score()
    {
        ScriptableEvents.TriggerScoreEvent(scoreBase * Time.deltaTime);
    }

    public void Die()
    {
        alive = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.detectCollisions = false;
        col3d.enabled = false;
        col2d.enabled = false;
        Debug.Log("get rekt u fokin noob, u ded");
    }
}