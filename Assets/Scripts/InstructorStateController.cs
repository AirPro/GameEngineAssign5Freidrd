using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructorStateController : MonoBehaviour
{
    // Creater an animator object
    Animator animator;
    // Start is called before the first frame update

    public GameObject MainPlayer;
    public float TargetDistance = 2f;
    public float AllowedDistance = 5f;
    public GameObject TheNPC;
    public float FollowSpeed = .5f;
    public RaycastHit Shot;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("W"))
        //{
        //    animator.SetBool("IsWalking", true);
        //}
        //if (!Input.GetKey("W"))
        //{
        //    animator.SetBool("IsWalking", false);
        //} 
        transform.LookAt(MainPlayer.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 0.02f;
                TheNPC.GetComponent<Animation>().Play("Walking");
                transform.position = Vector3.MoveTowards(transform.position, MainPlayer.transform.position, FollowSpeed);
            }
            else
            {
                FollowSpeed = 0;
                TheNPC.GetComponent<Animation>().Play("Idle");
            }
        }
    }
}
