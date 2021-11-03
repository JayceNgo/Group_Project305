using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scGameOver : MonoBehaviour
{
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // list of object names that you want to destroy


        if (render.color.a > 0.9 && Input.GetMouseButton(0))
        {
            string[] destroyTargets = new string[] { "playercraft", "GlobalDefine", "Background", "enemySpawner" };
            foreach (string name in destroyTargets)
            {
                GameObject go = GameObject.Find(name);
                //if the tree exist then destroy it
                if (go)
                    Destroy(go.gameObject);
            }
            SceneManager.LoadScene("Game_FieldA");
        }
        else render.color += new Color(0, 0, 0, 0.02f);
    }
}
