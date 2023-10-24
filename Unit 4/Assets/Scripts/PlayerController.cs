using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private GameObject focalPoint;
	public GameObject powerupIndicator;
	private Rigidbody playerRb;
	public bool hasPowerup; // State of player's powered-up status
	public float speed = 5.0f; // Speed player moves
	private float PowerupStrength = 15.0f; // Force with which player pushes away enemies
	
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
		// Pushes player ball with forward force when W or S are pressed
        float forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
		// Moves powerup indicator around with player, using an offset
		powerupIndicator.transform.position = transform.position
			+ new Vector3(0, -0.5f, 0);
    }
	
	// Handles powerup event when player touches powerup
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup")){
			hasPowerup = true;
			Destroy(other.gameObject);
			StartCoroutine(PowerupCountdownRoutine());
			powerupIndicator.gameObject.SetActive(true);
		}
	}
	
	// Sets countdown for powerup status
	IEnumerator PowerupCountdownRoutine() {
		yield return new WaitForSeconds(7);
		hasPowerup = false;
		powerupIndicator.gameObject.SetActive(false);
	}
	
	// Handles collision between player and enemy, pushing enemy with added force if player is powered up
	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {
			
			Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (collision.gameObject.transform.position = transform.position);
			
			Debug.Log("Collided with" + collision.gameObject.name
				+ " with Powerup set to " + hasPowerup);
			enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
		}
	}
}
