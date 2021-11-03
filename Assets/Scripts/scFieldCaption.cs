using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scFieldCaption : MonoBehaviour
{

    public Text displayField;
    public Transform bossTarget;
    public int textMode = 1; //1= countdown. 2-4: Field A/B/C
    // Start is called before the first frame update
    void Start()
    {
        displayField = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(textMode)
        {
            case 1: displayField.text = global.remain.ToString() + " remain"; break;
            case 2: displayField.text = "Field A"; break;
            case 3: displayField.text = "Field B"; break;
            case 4: displayField.text = "Field C"; break;
            case 5: displayField.text = bossTarget.GetComponent<scEnemyBase>().currentHP.ToString()+"/1000"; break;
        }
    }
}
