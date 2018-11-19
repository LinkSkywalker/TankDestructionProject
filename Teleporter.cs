using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject destination;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name =="CompleteTank(Clone)" || collider.gameObject.name =="CompleteTank(Clone)" && destination != null){

		
			//foreach(Teleporteur tp in FindObjectsOfType<Teleporteur>()){
				
				//if(tp.destination==destination && tp != this){
					Vector3 position=destination.transform.position;
					position.y+=1.2f;
					collider.gameObject.transform.position=position;
				//}
			//}


		}
	}	
}