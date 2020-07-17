using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject AsteroidObj;
    public GameObject SuperAster;
    public GameObject TitleScreen;
    public ScoreScript scorekeepre;
    
    public void PlayGame(){
        player.transform.position = new Vector3(0,0,0);
        player.transform.rotation = Quaternion.Euler(0,0,0);
        player.GetComponent<PlayerMovement>().enabled = true;
        scorekeepre.Score = 0;
        AsteroidObj.GetComponent<AsteroidSpawner>().ScoreKeeper = scorekeepre;
        AsteroidObj.GetComponent<AsteroidSpawner>().player = player.GetComponent<PlayerMovement>();
        AsteroidObj.GetComponent<AsteroidSpawner>().Populate();
        TitleScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void StopGame(){
        player.transform.position = new Vector3(0,0,0);
        player.transform.rotation = Quaternion.Euler(0,0,0);
        player.GetComponent<PlayerMovement>().enabled = false;
        scorekeepre.Score = 0;
        foreach(Transform roid in AsteroidObj.GetComponentsInChildren<Transform>()){
            Destroy(roid.gameObject);
        }
        AsteroidObj = Instantiate(SuperAster, transform.position, transform.rotation);
        AsteroidObj.GetComponent<AsteroidSpawner>().player = player.GetComponent<PlayerMovement>();
        TitleScreen.SetActive(true);
        Time.timeScale = 0;


    }
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            StopGame();
        }
    }
    void Start(){
        
        StopGame();

    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
