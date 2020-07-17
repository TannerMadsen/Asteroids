using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D riggity;
    private Vector2 move;
    public float Size;
    public GameObject SplitObj;
    public ScoreScript ScoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        ScoreKeeper = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreScript>();
        transform.localScale = new Vector3(Size, Size, 1);
        riggity = this.GetComponent<Rigidbody2D>();
        move = new Vector2(Random.Range(-100,100), Random.Range(-100,100));
        move.Normalize();
        riggity.velocity = move * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Split(){
        if(Size>1){
            GameObject clone = Instantiate(SplitObj,transform.position+ new Vector3(Random.Range(-Size/2,0),Random.Range(-Size/2,0),0), Quaternion.Euler(0,0,Random.Range(0,360)), transform.parent);
            clone.GetComponent<AsteroidScript>().Size = Size/2;
            
            clone = Instantiate(SplitObj,transform.position+ new Vector3(Random.Range(0,Size/2),Random.Range(0,Size/2),0), Quaternion.Euler(0,0,Random.Range(0,360)), transform.parent);
            clone.GetComponent<AsteroidScript>().Size = Size/2;
            
            Destroy(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
        ScoreKeeper.Score += 100;
        
        
    }
    
}
