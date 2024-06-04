using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private int slideSmooth = 60;

    // There are 3 lanes left (0), middle (1) and right (2)
    private int actualLane = 1;
    public float distanceBetweenLanes = 4;

    public float jumpForce;
    public float gravity = -20;

    public Vector3 crawlScale = new Vector3(0.5f, 0.2f, 0.5f); 
    public Vector3 normalScale = new Vector3(0.5f, 0.5f, 0.5f);
    private bool isCrawling = false;
    private float crawlTimer = 0.0f;
    private float crawlDuration = 0.8f;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!managePlayer.isGameStarted)
        {
            return;
        }
        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        direction.z = forwardSpeed;
        
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !isCrawling)
            {
                Crawl();
            } else if (isCrawling)
            {
                crawlTimer += Time.deltaTime;
                if (crawlTimer >= crawlDuration) {
                    Uncrawl();
                }
            }
        } else
        {
            direction.y += gravity * Time.deltaTime;        }

        if (Input.GetKeyDown(KeyCode.RightArrow) & actualLane < 2)
        {
          actualLane++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) & actualLane > 0)
        {
          actualLane--;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
       
        if(actualLane == 0)
        {
            targetPosition += Vector3.left * distanceBetweenLanes;
        } else if (actualLane == 2)
        {
            targetPosition += Vector3.right * distanceBetweenLanes;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, slideSmooth * Time.fixedDeltaTime);
        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        if (!managePlayer.isGameStarted)
        {
            return;
        }
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void Crawl()
    {
        isCrawling = true;
        crawlTimer = 0.0f;
        transform.localScale = crawlScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
    }

    private void Uncrawl()
    {
        isCrawling = false;
        transform.localScale = normalScale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            managePlayer.gameOver = true;
        }
    }
}
