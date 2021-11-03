using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{

    public static int field;
    public static double score;
    public static int remain;
    public static int kills;
    public static int life;
    public static int[] weaponlevel = new int[3];
    public static double[] weaponexp = new double[3];
    public static int currentweapon;
    public float timeElapsed = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //Player
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 12, true);
        Physics2D.IgnoreLayerCollision(8, 13, true);

        //Enemies
        Physics2D.IgnoreLayerCollision(10, 10, true);
        Physics2D.IgnoreLayerCollision(10, 12, true);

        //Enemy Bullets
        Physics2D.IgnoreLayerCollision(11, 9, true);
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(11, 11, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 450;
        field = 1;
        score = 0;
        remain = 300;
        kills = 0;
        life = 3;
        for (int i = 0; i < 3; i++) weaponlevel[i] = 1;
        for (int i = 0; i < 3; i++) weaponexp[i] = 0;
        currentweapon = 0;
    }

    void Update()
    {
        //Music Stop if Player Dies
        if (GameObject.Find("playerdeathfx(Clone)"))
            GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
    }
}
