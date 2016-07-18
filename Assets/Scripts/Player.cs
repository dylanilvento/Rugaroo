using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed;
	public float jump;
	public bool facingRight = true;
	public bool stopMvmtRight = false;
	public bool stopMvmtLeft = false;
	public bool grounded = true;

	public enum Form {Bull, Frog, Tiger};

	Animator anim;
	public bool stopAction = false;

	Rigidbody2D rb;

	BoxCollider2D tigerAttack;

	// Use this for initialization
	void Start () {
		Form form = Form.Tiger;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		tigerAttack = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
	}

	void FixedUpdate () { 

		float move = Input.GetAxis("Horizontal");
		
		if (!stopAction) {
			if (!stopMvmtLeft || !stopMvmtRight) {	
				anim.SetFloat("Speed", Mathf.Abs(move));
				rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
			
			}

			if ((move > 0 && stopMvmtRight) || (move < 0 && stopMvmtLeft)) {
				anim.SetFloat("Speed", 0.00f);
				rb.velocity = new Vector2(0f, 0f);

			}
		}
		if (stopAction) {
			anim.SetFloat("Speed", 0.00f);
		}

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			anim.SetTrigger("Attack");
			StartCoroutine("Attack");
		}

		if (Input.GetKeyDown("up") && grounded) {
			rb.velocity = new Vector2(0f, jump);
			grounded = false;
		}
	}

	void Flip () {

		facingRight = !facingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x *= -1;
		transform.localScale = playerScale;
	}

	void OnCollisionEnter2D (Collision2D other) {
		print("Test1");
		if (other.gameObject.name.Equals("Ground")) {

			print("Test2");
			grounded = true;
		}
	}

	IEnumerator Attack () {
		tigerAttack.enabled = true;
		yield return new WaitForSeconds(0.5f);
		tigerAttack.enabled = false;
	}

}
