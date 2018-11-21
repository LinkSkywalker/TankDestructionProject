using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraFollowPlayer : NetworkBehaviour
{
   // public Transform camPlace;
 //   public float speed = 10;
    public Transform playerTransform;
    public int depth = -20;

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 10, depth);
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }

    /*void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, camPlace.position, speed * Time.deltaTime);
	}*/
}
