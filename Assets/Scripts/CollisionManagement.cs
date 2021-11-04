using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagement : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {   
        // if the collision detecter collides with the wall
        if (other.gameObject.CompareTag("Impassable"))
        {
            //get the collision gameobject's particle system
            ParticleSystem extraCollisionParticles = gameObject.GetComponent<ParticleSystem>();
            //get the colllision sound
            AudioSource collosionSound = gameObject.GetComponent<AudioSource>();
            //emit the collision particles
            extraCollisionParticles.Emit(500);
            //play the collision sound
            collosionSound.Play();

        }
    }
}
