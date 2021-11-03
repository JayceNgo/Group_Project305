using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scFadeout : MonoBehaviour
{
    SpriteRenderer render;
    public float opacity;
    public float fadespeed=0.01f;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        opacity -= fadespeed;
        render.color = new Color(render.color.r, render.color.g, render.color.b, opacity);
        if (opacity < 0.0001f) Destroy(this.gameObject);
    }
}
