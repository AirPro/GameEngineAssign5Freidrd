using UnityEngine;

public class MoveTransformPositionWithInputLimitMovement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5)
            transform.position += Vector3.right;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5)
            transform.position += Vector3.left;
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 5)
            transform.position += Vector3.forward;
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > -1)
            transform.position += Vector3.back;

        if (Input.GetKeyDown(KeyCode.Space))
            transform.position = new Vector3(0, 0.5f, 0);
    }
}