using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Animator Anime;
	public Rigidbody2D PlayerRigidBody;
	public int forceJump;
	public bool jump;
	public bool slide;

	//Verifica o chão
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	//slide
	public float slideTemp;
	public float timeTemp;


	void Start () {
		
	}

	void Update () {
		if ((Input.GetButtonDown("Jump")) && (grounded == true)){
			PlayerRigidBody.AddForce (new Vector2(0,forceJump));
			jump = true;
			slide = false;

		}

		if ((Input.GetButtonDown ("Slide")) && (grounded == true)) {
			slide = true;
			timeTemp = 0;


		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, whatIsGround);

		if (slide == true) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				slide = false;
			}
		}

		Anime.SetBool ("jump", !grounded);
		Anime.SetBool ("slide", slide);

	}
}
