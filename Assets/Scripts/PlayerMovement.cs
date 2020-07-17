using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float TurnSpeed;
    public float AccelRate;
    public float Maxspeed;
    public float ShootSpeed;
    private Rigidbody2D riggity;
    private Vector2 frwrds;
    public GameObject bulletPrefab;
    public bool Shielded;
    public MenuScript menuobj;
    public float ShieldTime;
    public float ShieldTimeCurrent;
    public SpriteRenderer playersprite;
    public bool Dashing;
    public float DashFactor;
    public CapsuleCollider2D smashy;

    
    // Start is called before the first frame update
    void Start()
    {
        smashy.enabled = false;
        riggity = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        frwrds = transform.up;
        transform.Rotate(0,0,-1*Input.GetAxis("Horizontal")*TurnSpeed*Time.deltaTime, Space.Self);
        if(riggity.velocity.sqrMagnitude < Maxspeed * Maxspeed){
            riggity.velocity += frwrds * AccelRate * Time.deltaTime * Input.GetAxis("Vertical");
        }else{
            riggity.velocity = frwrds * Maxspeed * Input.GetAxis("Vertical");
        }
        if(Input.GetButtonDown("Jump")){
            Shoot();
        }
        if(Shielded){
            if(ShieldTimeCurrent>0){
                ShieldTimeCurrent -= Time.deltaTime;
            }else{
                ShieldTimeCurrent = ShieldTime;
                Shielded = false;
                Dashing = false;
            }
            playersprite.enabled = true;

        }else{
            playersprite.enabled = false;
        }
        if(Dashing){
            playersprite.color = new Color(1,0,0,0.1f);
            smashy.enabled = true;

        }else{
            playersprite.color = new Color(0,1,0.95f,0.1f);
            smashy.enabled = false;
        }
    }
    void Shoot(){
        riggity.velocity = riggity.velocity * DashFactor;
        Dashing = true;
        Shielded = true;
    }
    void OnCollisionEnter2D(){
        if(Shielded){

        }else{
            menuobj.StopGame();
        }
    }
    
}
