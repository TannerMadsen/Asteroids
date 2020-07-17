using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScript : MonoBehaviour
{
    public float ShrinkFactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.y) > Camera.main.orthographicSize){
            transform.position = new Vector3(transform.position.x, -transform.position.y * ShrinkFactor, transform.position.z);
        }
        if(Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Screen.width / Screen.height){
            transform.position = new Vector3(-transform.position.x*ShrinkFactor, transform.position.y, transform.position.z);
        }
    }
}
