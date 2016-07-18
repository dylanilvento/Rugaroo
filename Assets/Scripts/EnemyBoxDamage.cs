using UnityEngine;
using System.Collections;

public class EnemyBoxDamage : MonoBehaviour {
	EnemyBoxMovement enemyMvmt;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		enemyMvmt = GetComponent<EnemyBoxMovement>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Contains("Attack")) {
			StartCoroutine("Knockback");
		}
	}

	IEnumerator Knockback () {
		enemyMvmt.stopAction = true;
		rb.velocity = new Vector2(GetKnockback(), 13f);
		yield return new WaitForSeconds(1f);
		enemyMvmt.stopAction = false;
	}

	float GetKnockback () {
		if (enemyMvmt.facingRight) {
			return -1 * 4f;
		}

		else return 4f;
	}
}
