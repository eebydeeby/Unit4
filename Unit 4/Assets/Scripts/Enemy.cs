using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed; // Variable for how fast the enemy rolls
	private Rigidbody enemyRb;
	private GameObject player;
	
    void Start() 
    {
		enemyRb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player"); // Identifies player object as target
    }

	// Finds player position and pushes enemy ball toward it
    void Update()
    {
		Vector3 lookDirection = ((player.transform.position
		- transform.position).normalized);
        enemyRb.AddForce(lookDirection * speed);
		if (transform.position.y < -10) { Destroy(gameObject); }
    }
}
