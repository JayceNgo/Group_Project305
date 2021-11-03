using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scEnemyBulletBase : MonoBehaviour
{
    SpriteRenderer render;
    public Sprite fieldASprite;
    public Sprite fieldBSprite;
    public Sprite fieldCSprite;
    public Sprite bossSprite;
    bool accelerate = false;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        Scene currentScene = SceneManager.GetActiveScene();
            switch (currentScene.name)
            {
                case "Game_FieldA": render.sprite = fieldASprite; break;
                case "Game_FieldB": render.sprite = fieldBSprite; break;
                case "Game_FieldC": render.sprite = fieldCSprite; break;

            }
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity.normalized;
        if (transform.position.y > 4 || transform.position.y < -4 || transform.position.x > 8 || transform.position.x < -8) Destroy(gameObject);
        if (global.remain < 1) Destroy(this.gameObject);
        if (accelerate == true) GetComponent<Rigidbody2D>().velocity *= 1.005f;
    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            case "playerhitfx(Clone)": Destroy(gameObject); break;
        }
    }
}
