using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlayerHitFX : MonoBehaviour
{
    SpriteRenderer sprite;
    float size = 0.15f;
    float opacity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        size += 0.0025f;
        transform.localScale = new Vector3(size, size, 1);
        opacity -= 0.0025f;
        sprite.color = new Color(1, 0, 0, opacity);
        if (opacity < 0.001) Destroy(gameObject);
    }
}
