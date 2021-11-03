using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scBackground : MonoBehaviour
{
    public Transform targetTransform;
    public int mode = 0;
    float rotation = 0;
    SpriteRenderer render;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (mode!=-1)
        switch (currentScene.name)
        {
            case "Game_FieldA": render.color = new Color(0.4470029f, 0, 1); break;
            case "Game_FieldB": render.color = new Color(0.7364602f, 0, 1); break;
            case "Game_FieldC": render.color = new Color(1, 0, 0.8426657f); break;
            case "Game_FieldBoss": render.color = new Color(1, 0, 0); break;
                
        }

        rotation += 0.01f;
        if (mode == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
            transform.position = targetTransform.transform.position / 10;
            //GetComponent<Rigidbody2D>().velocity = targetTransform.GetComponent<Rigidbody2D>().velocity / 9;
        }
        else if (mode == 1)
            transform.position = targetTransform.transform.position / 7;
            //GetComponent<Rigidbody2D>().velocity = targetTransform.GetComponent<Rigidbody2D>().velocity / 7;

       // if (targetTransform.position.x < -7.2 || targetTransform.position.x > 7.2)
       //     GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
       // if (targetTransform.position.y < -3.4 || targetTransform.position.y > 3.4)
       //     GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

    }
}
