using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGravity : MonoBehaviour {

    public float rangeBeforeFall = 5;


    private void Start()
    {
    }
    private void Update ()
    {
        // Check if wall can fall
        bool fallingDown;
        Ray rayDown = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hitDown;
        fallingDown = Physics.Raycast(rayDown, out hitDown, rangeBeforeFall);

        /* // Check if wall has neighbor
        bool fallingRight;
        Ray rayRight = new Ray(gameObject.transform.position, Vector3.right);
        RaycastHit hitRight;
        fallingRight = Physics.Raycast(rayRight, out hitRight, rangeBeforeFall);*/


        if (!fallingDown)
        {
            Detonate();
        }


    }

    private void Detonate()
    {
        int objectChildNumber = transform.childCount;

        for(int i = 0; i < objectChildNumber; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;

            gameObject.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
        gameObject.transform.DetachChildren();
    }
}
