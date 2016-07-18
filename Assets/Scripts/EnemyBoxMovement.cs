using UnityEngine;
using System.Collections;

public class EnemyBoxMovement : MonoBehaviour {

	public bool stopAction = false;
	public bool facingRight = false;
	float player;
	Rigidbody2D rb;
	public float speed;
	// Use this for initialization
	void Start () {
		print (speed);
		
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player = GameObject.Find("Player").transform.position.x;
		if (!stopAction) {
			if (player > gameObject.transform.position.x + 2f) {
				rb.velocity = new Vector2(speed, rb.velocity.y);
				if (!facingRight) Flip();
			}
			else if (player < gameObject.transform.position.x - 2f) {
				rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
				if (facingRight) Flip();
			}
		}
	
	}

	void Flip () {

		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
