using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impassable"))
        {
            Debug.Log("911");
            ParticleSystem extraCollisionParticles = gameObject.GetComponent<ParticleSystem>();
            AudioSource collosionSound = gameObject.GetComponent<AudioSource>();

            extraCollisionParticles.Emit(500);

            collosionSound.Play();

        }
    }
}
