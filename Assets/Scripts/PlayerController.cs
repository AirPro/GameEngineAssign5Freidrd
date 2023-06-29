using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Private Variables
    private float speed = 10;
    private float turnSpeed = 10;
    public float jumpHeight = 40;
    public float jumpSpeed = 10;
    public float shiftSpeed = 5;

    private Vector3 startPosition;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log("Let's me know if something is happenning");
    }

    void HandleResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Input.GetKey(KeyCode.K))
            {
                ResetPosition(startPosition);
            }
            else
            {
                ResetPosition();
            }
        }
    }
    void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

    void ResetPosition()
    {
        Vector3 newPos = transform.position;
        newPos.y = 10;
        ResetPosition(newPos);
    }

    void HandleMovement()
    {
        //This is where we get player input
        float steerValue = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float gasValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float jumpValue = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;


        steerValue *= Mathf.Sign(gasValue);

        if (gasValue == 0)
        {
            steerValue = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            steerValue *= shiftSpeed;
            gasValue *= shiftSpeed;
        }

        // Move the vehicle
        Vector3 positionchange = Vector3.forward * gasValue;
        positionchange += Vector3.up * jumpValue;

        transform.Rotate(Vector3.up, steerValue);
        transform.Translate(positionchange);

    }

    // Update is called once per frame
    void Update()
    {
        HandleResetPosition();
        HandleMovement();
    }
}
