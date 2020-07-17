using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Lifetime;
    private float ActualLife;
    // Start is called before the first frame update
    void Start()
    {
        ActualLife = Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if(ActualLife>0){
            ActualLife -= Time.deltaTime;
        }else{
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}
