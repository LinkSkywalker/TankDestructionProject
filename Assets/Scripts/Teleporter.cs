using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject destination;
	public GameObject wasteleported;


	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag =="Player" && destination != null)
		{	
			CameraThirdPerson rb = collider.gameObject.GetComponent<CameraThirdPerson>();
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
		if (collider.gameObject.tag =="Player" && destination != null)
		{	
			if (wasteleported == collider.gameObject){
				wasteleported = null;
				return;
			}
			CameraThirdPerson rb = collider.gameObject.GetComponent<CameraThirdPerson>();
			rb.m_IsInTeleporterZone = false;
		}
	}
}