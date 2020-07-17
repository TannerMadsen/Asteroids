using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(){
        this.GetComponentInParent<AsteroidScript>().Split();
    }
}
