using UnityEngine;

// This shows the Movement with Input Limited by position using properties to make the code easier to read at first glance 
public class MoveTransformPositionWithInputLimitMovementCleaned : MonoBehaviour
{
    void Update()
    {
        if (ShouldMoveRight)
            transform.position += Vector3.right;
        
        if (ShouldMoveLeft)
            transform.position += Vector3.left;
        
        if (ShouldMoveForward)
            transform.position += Vector3.forward;
        
        if (ShouldMoveBack)
            transform.position += Vector3.back;

        if (ShouldReset)
            transform.position = new Vector3(0, 0.5f, 0);
    }

    private bool ShouldReset => Input.GetKeyDown(KeyCode.Space);
    private bool ShouldMoveBack => Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > -1;
    private bool ShouldMoveForward => Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 5;
    private bool ShouldMoveLeft => Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5;
    private bool ShouldMoveRight => Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5;
}