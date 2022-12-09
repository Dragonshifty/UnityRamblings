using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public static int lives = 2;
    private void OnTriggerEnter(Collider other) {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null) {return;}

        if (lives < 2){
            playerHealth.Crash();
            lives = 2;
            
        } else {
            --lives;
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public int DisplayLives(){
        return lives;
    }
}
