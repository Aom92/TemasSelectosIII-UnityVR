using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "extras")
        {
            Destroy(this.gameObject);
        }
        
    }
}
