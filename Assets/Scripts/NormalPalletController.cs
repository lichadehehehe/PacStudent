using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPalletController : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Eaten");
            //ParticleSystem extraCollisionParticles = gameObject.GetComponent<ParticleSystem>();
            //AudioSource collosionSound = gameObject.GetComponent<AudioSource>();

            //extraCollisionParticles.Emit(500);

            //collosionSound.Play();
            int count = int.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text);
            count ++;
            string countString = count.ToString();

            GameObject.FindGameObjectWithTag("Score").GetComponent<UnityEngine.UI.Text>().text = countString;




            gameObject.active = false;

        }
    }
}
