using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scScoreCounter : MonoBehaviour
{
    public Text displayScore;
    // Start is called before the first frame update
    void Start()
    {
        displayScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayScore.text = global.score.ToString();
    }
}
