using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public MoveTo script;

    public void OnTriggerEnter(Collider collider)
    {
       // Debug.Log("Colisión con: " + collider.name);
       // Debug.Log("Tag: " + collider.tag);

        if (collider.gameObject.tag == "jugador")
        {
        //    Debug.Log("Colisión con: " + collider.name);
            script.CollisionWithPlayer();
        }

        if (collider.gameObject.tag == "bullet")
        {
            Debug.Log("Colisión con: " + collider.name);
            script.CollisionWithBullet();

            StartCoroutine("destroyBullet", collider.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            script.CollisionWithPlayerExit();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("Colisión con: " + collision.gameObject.name);
            script.CollisionWithBullet();

            

            StartCoroutine("destroyBullet", collision.gameObject);
        }
    }

    private void destroyBullet(GameObject BulletPrefab)
    {
        
        Destroy(BulletPrefab);
    }
}
