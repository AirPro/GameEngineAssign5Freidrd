using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    // declare a type private animator to refer to at runtime
    private Animator anim;
    // create a variable that enables actions to complete
    // before other actions take place
    private bool accept_input = true;

    public AnimationClip turnLeftAnimClip;

    public AnimationClip turnRightAnimClip;

    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run"); 
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if ( turnLeftAnimClip != null || turnRightAnimClip != null) 
        {
            AddInputBlockingAnimEndCallback(turnLeftAnimClip);
            AddInputBlockingAnimEndCallback(turnRightAnimClip);
        }
    }

    private void AddInputBlockingAnimEndCallback(AnimationClip clip)
    {
        AnimationEvent animDoneEvent = new AnimationEvent();
        animDoneEvent.time = clip.length;
        animDoneEvent.functionName = "OnInputBlockingAnimationDone";
        clip.AddEvent(animDoneEvent);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (accept_input) 
        {
            HandleInput();
        }
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if(Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash)
        {
            anim.SetTrigger(jumpHash);
        }
    }

    private void OnInputBlockingAnimationDone()
    {
        accept_input = true;
    }

    // Allows the current process to complete before
    // another process can take place
    private void HandleInput()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        anim.SetBool("Crouch", Input.GetKey(KeyCode.C));

        if (Input.GetKey(KeyCode.R)) 
        {
            anim.SetBool("Crouch", false);
            anim.SetTrigger("RightTurn");
            accept_input = false;
        }

        if (Input.GetKey(KeyCode.L)) 
        {
            anim.SetBool("Crouch", false);
            anim.SetTrigger("LeftTurn");
            accept_input = false;
        }

        // try and get my character to walk
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Crouch", false);
            anim.SetTrigger("Walking");
            accept_input = false;
        }
    }
}
