using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	public float knockback;
	
	Rigidbody2D rb;
	SpriteRenderer sr;
	Player playerCS;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		playerCS = GetComponent<Player>();
	}	
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		print(other.gameObject.name);
		//if (other.gameObject.name.Equals("Spikes")) {
		if (other.collider is PolygonCollider2D){
			print("Spiked");
			StartCoroutine("Knockback");
			

		}
	}

	IEnumerator Knockback () {
		playerCS.stopAction = true;
		StartCoroutine("Blink");
		rb.velocity = new Vector2(GetKnockback(), 13f);
		yield return new WaitForSeconds(1f);
		playerCS.stopAction = false;
	}

	float GetKnockback () {
		if (playerCS.facingRight) {
			return -1 * knockback;
		}

		else return knockback;
	}

	IEnumerator Blink () {
		for (int ii = 0; ii < 10; ii++) {
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
			yield return new WaitForSeconds(0.1f);
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
			yield return new WaitForSeconds(0.1f);
		}	
	}
}




