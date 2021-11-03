using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scTransition : MonoBehaviour
{
    public int roomselect = 1;
    //0: Destroy object. 1: Field A. 2: Field B. 3: Field C. 4: Field D (Boss).
    float scaletimer = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (roomselect == 0) scaletimer = 32;
    }

    // Update is called once per frame
    void Update()
    {
        if (roomselect == 0) scaletimer -= 0.1f; else scaletimer += 0.1f;
        if (scaletimer < 0.001 && roomselect==0) Destroy(this.gameObject);
        transform.localScale = new Vector3(scaletimer,8,0);
        if (scaletimer>32 && roomselect!=0) switch(roomselect)
            {
                case 1:
                    { global.field = 1; SceneManager.LoadScene("Game_FieldA"); } break;
                case 2:
                    { global.field = 2; SceneManager.LoadScene("Game_FieldB"); }
                    break;
                case 3:
                    { global.field = 3; SceneManager.LoadScene("Game_FieldC"); }
                    break;
                case 4:
                    { global.field = 4; SceneManager.LoadScene("Game_FieldBoss"); }
                    break;

            }
    }
}
