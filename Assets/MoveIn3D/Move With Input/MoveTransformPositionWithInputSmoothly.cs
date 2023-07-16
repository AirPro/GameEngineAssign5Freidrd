using UnityEngine;

// Moves the object with world space coordinates like Vector3.right (does not account for the objects rotation)
public class MoveTransformPositionWithInputSmoothly : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Time.deltaTime * _moveSpeed * Vector3.right;
        
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Time.deltaTime * _moveSpeed * Vector3.left;
        
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;
        
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position += Time.deltaTime * _moveSpeed * Vector3.back;

        if (Input.GetKey(KeyCode.Space))
            transform.position = new Vector3(0, 0.5f, 0);
    }
}