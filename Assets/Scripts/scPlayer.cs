using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlayer : MonoBehaviour
{
    public float rotspeed = 8f; //Rotation Speed
    //Transform target; 
    SpriteRenderer sprite;
    float timeSinceLastAttack = 0;
    public float attackDelay;
    public float frontAttackLvlOneDelay;
    public float frontAttackLvlThreeAndTwoDelay;
    public float spreadAttackLvlOneDelay;
    public float spreadAttackLvlThreeAndTwoDelay;
    public float vulcanAttackDelay;

    double immunetimer = 0;
    public double immuneInitialTime;
    float speed;
    public float playerCraftSpeed;

    public bool immune = false;
    public global global;


    //Prefabs
    #region 
    public Transform rapidPrefab;
    public Transform spreadPrefab;
    public Transform vulcanSPrefab;
    public Transform vulcanMPrefab;
    public Transform vulcanHPrefab;
    public Transform hitEffectPrefab;
    public Transform deathEffectPrefab;
    public Transform deathEffect2Prefab;
    #endregion

    //Sounds
    #region
    AudioSource audioData;
    public AudioClip rapidSound;
    public AudioClip spreadSound;
    public AudioClip vulcanSound;
    public AudioClip hitSound;
    #endregion

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
        Attack();
        CheckImmunity();
    }
    void Movement()
    {
        //Border Control
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.3f, 7.3f),
            Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
        //Rotation
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotspeed * Time.deltaTime);

        speed = (Input.GetKey("left shift") || Input.GetKey("right shift")) ? 1 : playerCraftSpeed;
        //Input
        float horispeed = Input.GetAxisRaw("Horizontal");
        float vertispeed = Input.GetAxisRaw("Vertical");

        //Movement
        GetComponent<Rigidbody2D>().velocity = (Vector2.right * horispeed * speed) + (Vector2.up * vertispeed * speed);
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(1)) global.currentweapon = global.currentweapon == 2 ? 0 : global.currentweapon + 1; // Weapon Changing
        switch (global.currentweapon)
        {
            case 0: sprite.color = new Color(0.3915094f, 0.8281909f, 1, 1); break;
            case 1: sprite.color = new Color(0, 1, 0.1873093f, 1); break;
            case 2: sprite.color = new Color(1, 0.458081f, 0, 1); break;
        }

        // Check if player is asking to attack and time between attacks is great enough. if not adds time to timeSinceLastAttack
        if (timeSinceLastAttack >= attackDelay && Input.GetMouseButton(0))
        {
            Transform bullet;
            switch (global.currentweapon)
            {
                case 0: //Front
                    attackDelay = global.weaponlevel[0] == 1 ? frontAttackLvlOneDelay : frontAttackLvlThreeAndTwoDelay;
                    bullet = Instantiate(rapidPrefab, transform.position, transform.rotation) as Transform;
                    bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + (transform.up / 32)) * 18;
                    bullet = Instantiate(rapidPrefab, transform.position, transform.rotation) as Transform;
                    bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + (transform.up / -32)) * 18;

                    //Level 3
                    if (global.weaponlevel[0] > 2)
                    {
                        bullet = Instantiate(rapidPrefab, transform.position, transform.rotation) as Transform;
                        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 18;
                    }
                    audioData.PlayOneShot(rapidSound, 1f);
                    break;
                case 1: // Spread
                    attackDelay = global.weaponlevel[1] == 1 ? spreadAttackLvlOneDelay : spreadAttackLvlThreeAndTwoDelay;
                    bullet = Instantiate(spreadPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                    bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 14;
                    bullet = Instantiate(spreadPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                    bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + transform.up / 8) * 14;
                    bullet = Instantiate(spreadPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                    bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + transform.up / -8) * 14;

                    //Level 3
                    if (global.weaponlevel[1] > 2)
                    {
                        bullet = Instantiate(spreadPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                        bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + transform.up / 4) * 14;
                        bullet = Instantiate(spreadPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                        bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + transform.up / -4) * 14;
                    }
                    audioData.PlayOneShot(spreadSound, 1f);
                    break;
                case 2: // Vulcan 
                    attackDelay = vulcanAttackDelay;
                    bullet = vulcanSPrefab;
                    switch (global.weaponlevel[2])
                    {
                        default: bullet = Instantiate(vulcanSPrefab, transform.position, transform.rotation) as Transform; break;
                        case 2: bullet = Instantiate(vulcanMPrefab, transform.position, transform.rotation) as Transform; break;
                        case 3: bullet = Instantiate(vulcanHPrefab, transform.position, transform.rotation) as Transform; break;
                    }
                    bullet.GetComponent<Rigidbody2D>().velocity = transform.right * (12 + (4 * global.weaponlevel[2] - 1));
                    audioData.PlayOneShot(vulcanSound, 1f);
                    break;
                default:
                    break;
            }
            timeSinceLastAttack = 0;
        }
        else timeSinceLastAttack += Time.deltaTime;
    }
    void CheckImmunity()
    {
        if (immune == true)
        {
            if (immunetimer > 0)
            {
                immunetimer -= Time.deltaTime;
                sprite.color = Color.red;
            }
            else
            {
                immune = false;
                immunetimer = immuneInitialTime;
            }
        }
        Physics2D.IgnoreLayerCollision(8, 10, immune);
        Physics2D.IgnoreLayerCollision(8, 11, immune);
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (immune == false && (col.gameObject.name == "pawn(Clone)" || col.gameObject.name == "enemybulletlong(Clone)"))
        {
            if (global.life > 1)
            {
                audioData.PlayOneShot(hitSound, 1f);
                global.life -= 1;
                immune = true;
                immunetimer = immuneInitialTime;
                Instantiate(hitEffectPrefab, transform.position, transform.rotation);
                if (global.weaponlevel[global.currentweapon] != 2) global.weaponexp[global.currentweapon] = 0;
                if (global.weaponlevel[global.currentweapon] != 1) global.weaponlevel[global.currentweapon] -= 1;
            }
            else
            {
                global.life -= 1;
                Transform deathFX = Instantiate(deathEffectPrefab, transform.position, transform.rotation) as Transform;
                deathFX.GetComponent<SpriteRenderer>().color = Color.red;
                deathFX.transform.localScale = new Vector3(2, 2, 1);
                deathFX.GetComponent<scExplosion>().disableAudio = true;
                Instantiate(deathEffect2Prefab, transform.position, transform.rotation);
                //Instantiate(gameOverPrefab, new Vector2(global.camerapos + 2, -2.75f), transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
