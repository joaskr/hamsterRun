using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    // There are 3 lanes left (0), middle (1) and right (2)
    private int actualLane = 1;
    public float distanceBetweenLanes = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        if(Input.GetKeyDown(KeyCode.RightArrow) & actualLane < 2)
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

        transform.position = Vector3.Lerp(transform.position, targetPosition, 60 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
