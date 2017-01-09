using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject barrierPrefab; // Objeto a ser spawnado
	public float rateSpwan;	//Intervalo de spwan	
	private float currentTime; //Tempo decorrido

	private int position;
	private float y;
	public float posA;
	public float posB;

	void Start () {
		
	}

	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime >= rateSpwan) {
			currentTime = 0;
			position = Random.Range (1, 100);
			if (position > 50) {
				//em cima
				y = -0.471f;
			}
			else {
				//embaixo
				y = -1.252f;
			}
			GameObject tempPrefab = Instantiate (barrierPrefab) as GameObject;
			tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);
			

		}

	}

}
