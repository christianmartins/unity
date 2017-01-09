using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Animator Anime;
	public Rigidbody2D PlayerRigidBody;
	public int forceJump;
	public bool slide;

	//Attck
	public Animator attackAnime;
	public bool attack;

	//Verifica o chão
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	//slide
	public float slideTemp;
	public float timeTemp;

	//Colisão
	public Transform colider;

	//Attack
	public float attackTemp;
	private float timeAttackTemp;

	//troll
	private int n1 = 0;

	void Start () {
		
	}

	void Update () {
		if ((Input.GetButtonDown("Jump")) && (grounded == true)){
			PlayerRigidBody.AddForce (new Vector2(0,forceJump));
			if (slide == true) {
				colider.position = new Vector3 (colider.position.x, colider.position.y - 0.380f, colider.position.z);
				slide = false;
			}

		}

		if (Input.GetButtonDown ("Slide") && (grounded == true) && (slide == false) &&(attack == false) ) {
			colider.position = new Vector3 (colider.position.x, colider.position.y - 0.380f, colider.position.z);
			slide = true;
			timeTemp = 0;

		}

		//Attack mod
		if (Input.GetButtonDown ("Attack") && (grounded == true) && (slide == false) ) {
			attack = true;
			timeAttackTemp = 0;
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);

		if (attack == true) {
			timeAttackTemp += Time.deltaTime;
			if (timeAttackTemp >= attackTemp) {
				attack = false;
			}
		}

		if (slide == true) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				colider.position = new Vector3 (colider.position.x, colider.position.y + 0.380f, colider.position.z);
				slide = false;
			}
		}




		Anime.SetBool ("jump", !grounded);
		Anime.SetBool ("slide", slide);

		//mod
		Anime.SetBool ("attack", attack);

	}

	void OnTriggerEnter2D(){
		n1 += 1;			
		Debug.Log ("Bateu " + n1);
	}
}
