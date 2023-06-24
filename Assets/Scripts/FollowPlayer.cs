using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    // private Vector3 offset = new Vector3(0,12,-24);

    // Start is called before the first frame update
    void Start()
    {

    }

    void MoveBehindPlayer()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.y = transform.position.y;
        newPosition.z -= 20;
        transform.position = newPosition;
    }

    void MoveOnTheSideOfPlayer()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = player.transform.position.z;
        transform.position = newPosition;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Offset the camera behind the player by adding the player's position.
        // transform.position = player.transform.position + offset();
        MoveBehindPlayer();
    }
}
