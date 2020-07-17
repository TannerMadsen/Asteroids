using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float Count;
    
    public GameObject Asteroid;
    
    public float CurrentCount;
    public ScoreScript ScoreKeeper;
    public PlayerMovement player;
    
    // Start is called before the first frame update
    void Start()
    {
        //Populate();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentCount = transform.childCount;
        if(CurrentCount == 0){
            Count +=1;
            Populate();
        }
        foreach (AsteroidScript roid in GetComponentsInChildren<AsteroidScript>()){
            if(roid.enabled == false){
                roid.transform.parent = ScoreKeeper.transform;
            }
        }
    }
    public void Populate(){
        player.Shielded = true;
        while(transform.childCount < Count){
            GameObject clone = Instantiate(Asteroid, new Vector3(Random.Range(-(Camera.main.orthographicSize * Screen.width / Screen.height), (Camera.main.orthographicSize * Screen.width / Screen.height)), Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize), 0), Quaternion.Euler(0,0,Random.Range(0,360)), transform);
            clone.GetComponent<AsteroidScript>().Size = Random.Range(1,4);
            clone.GetComponent<AsteroidScript>().ScoreKeeper = ScoreKeeper;
        }
    }
}
