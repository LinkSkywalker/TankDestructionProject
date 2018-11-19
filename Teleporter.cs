using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject destination;
	public GameObject wasteleported;


	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name =="CompleteTank(Clone)" || collider.gameObject.name =="CompleteTank(Clone)" && destination != null)
		{	
			Complete.TankMovement rb = collider.gameObject.GetComponent<Complete.TankMovement>();
			if (rb.m_IsInTeleporterZone) {
				return;
			}
			else {
				Vector3 position=destination.transform.position;
				//position.y+=1;
				collider.gameObject.transform.position=position;
				rb.m_IsInTeleporterZone = true;
				wasteleported = collider.gameObject;
			}	
		}
	}	

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name =="CompleteTank(Clone)" || collider.gameObject.name =="CompleteTank(Clone)" && destination != null)
		{	
			if (wasteleported == collider.gameObject){
				wasteleported = null;
				return;
			}
			Complete.TankMovement rb = collider.gameObject.GetComponent<Complete.TankMovement>();
			rb.m_IsInTeleporterZone = false;
		}
	}
}