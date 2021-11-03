using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scFieldBar : MonoBehaviour
{

    int killTarget;
    public Transform quotaPrefab;
    bool showQuotaMsg;

    // Start is called before the first frame update
    void Start()
    {
        setRemainTarget();
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale = new Vector3((float)(global.remain) / (float)(killTarget) * 1.823f, 0.04f, 1);
        if (global.remain < 0) global.remain = 0;

        if (global.remain<1 && showQuotaMsg==false)
        {
            Instantiate(quotaPrefab, new Vector2(0, -2.392591f), transform.rotation);
            showQuotaMsg = true;
        }
    }

    public void setRemainTarget()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Game_FieldA": killTarget = 300; break;
            case "Game_FieldB": killTarget = 400; break;
            case "Game_FieldC": killTarget = 500; break;
            case "Game_FieldBoss": killTarget = 1000; break;
        }
        global.remain = killTarget;
    }
}
