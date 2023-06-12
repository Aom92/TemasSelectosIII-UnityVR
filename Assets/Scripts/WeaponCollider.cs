using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public MoveTo script;
   
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "jugador")
        {
            script.WeaponHit();
        }
    }
}

