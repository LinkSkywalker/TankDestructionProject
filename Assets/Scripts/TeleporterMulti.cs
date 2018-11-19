using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterMulti : MonoBehaviour
{
    [Header("Teleporter settings")]
    public GameObject teleporterOutput;
    public float offsetHeight;

    public bool isTeleporting;

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && !isTeleporting)
        {
            isTeleporting = true;
            collision.transform.position = new Vector3(teleporterOutput.transform.position.x, teleporterOutput.transform.position.y + offsetHeight, teleporterOutput.transform.position.z);
        }

        if(gameObject.name == teleporterOutput.name)
        {
            isTeleporting = true;
        }
    }
}
