using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEnemyBase : MonoBehaviour
{

    public double enemyHP;
    public double currentHP;
    public float initHspeed;
    public float initVspeed;
    public int scoreValue;
    public int killValue = 1;
    public int expValue = 1;
    public GameObject explosion;
    public Transform fadeEffect;
    public AudioClip hitSound;
    public bool ready = true;
    public bool moveManual = false;
    AudioSource audioData;

    void Awake()
    {
        currentHP = enemyHP;
    }

    // Start is called before the first frame update
    void Start()
    {  
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {
                if (moveManual==true) GetComponent<Rigidbody2D>().velocity = (Vector2.right * initHspeed) + (Vector2.up * initVspeed);
            ready = false;
        }
        //else ready = true;

        if (currentHP <= 0)
        {
            global.kills += killValue;
            global.score += scoreValue;
            if (global.remain!=0) global.remain -= 1;
            global.weaponexp[global.currentweapon] += expValue;
            explosion.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (global.remain < 1) {
            Transform remove = Instantiate(fadeEffect, transform.position, transform.rotation) as Transform;
            remove.transform.localScale = transform.localScale/2;
            remove.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
           Destroy(this.gameObject); }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            case "rapidshot(Clone)": { audioData.PlayOneShot(hitSound, 0.7f); currentHP -= 1; } break;
            case "spreadshot(Clone)": { audioData.PlayOneShot(hitSound, 0.7f); currentHP -= 1; } break;
            case "vulcan_S(Clone)": { audioData.PlayOneShot(hitSound, 0.7f); currentHP -= 4; } break;
            case "vulcan_M(Clone)": { audioData.PlayOneShot(hitSound, 0.7f); currentHP -= 6; } break;
            case "vulcan_H(Clone)": { audioData.PlayOneShot(hitSound, 0.7f); currentHP -= 8; } break;
                //case "playerhitripple(Clone)": currentHP = 0; break;
        }


    }
}
