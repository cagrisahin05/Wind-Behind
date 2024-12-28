using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int hitPoints = 10;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;


    private void Start() 
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        
    }

    private void OnParticleCollision(GameObject other) 
    {
        Debug.Log("Particle collision detected with: " + other.name);
        ProcessHit();
    }

    private void ProcessHit() 
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
           
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
