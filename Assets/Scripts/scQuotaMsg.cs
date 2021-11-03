using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scQuotaMsg : MonoBehaviour
{
    public Transform screenWipe;
    float timePassed;
    float opacity = 0;
    bool ready=true;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        opacity += 0.02f;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opacity);
        if (timePassed>3f && ready==true)
        {
            ready = false;
            Transform trans = Instantiate(screenWipe, new Vector2(7.907888f, 0.09711881f), transform.rotation) as Transform;
            Scene currentScene = SceneManager.GetActiveScene();
            switch (currentScene.name)
            {
                case "Game_FieldA": trans.GetComponent<scTransition>().roomselect = 2; break;
                case "Game_FieldB": trans.GetComponent<scTransition>().roomselect = 3; break;
                case "Game_FieldC": trans.GetComponent<scTransition>().roomselect = 4; break;
            }
        }
    }
}
