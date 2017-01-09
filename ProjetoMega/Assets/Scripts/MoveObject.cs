using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	public float speed;
	private float x;
	void Start () {
		
	}
	

	void Update () {
		x = transform.position.x;
		x += speed * Time.deltaTime;

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if(x  <= -6){
			Destroy (transform.gameObject);
		}

	}
}
