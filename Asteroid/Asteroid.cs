using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private static int lives = 3;
    private void OnTriggerEnter(Collider other) {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null) {return;}

        if (lives < 1){
            playerHealth.Crash();
            lives = 3;
        } else {
            lives--;
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
