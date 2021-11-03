using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scWeaponGauge : MonoBehaviour
{
    public int weapon; //0=front. 1=spread. 2=vulcan.
    public Transform gauge;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = spriteArray[global.weaponlevel[weapon]-1];

        switch (global.weaponlevel[weapon])
        { case 1: gauge.transform.localScale = new Vector2(((float)global.weaponexp[weapon] /150), 1); break;
          case 2: gauge.transform.localScale = new Vector2(((float)global.weaponexp[weapon] /300), 1); break;
        }

        //Level Up
        if (global.weaponlevel[weapon] < 3  && global.weaponexp[weapon] >= 150*global.weaponlevel[weapon])
        { global.weaponlevel[weapon] += 1; global.weaponexp[weapon] = 0; }
    }
}
