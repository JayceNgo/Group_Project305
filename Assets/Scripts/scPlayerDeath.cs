using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlayerDeath : MonoBehaviour
{
    SpriteRenderer sprite;
    bool fadeEnable;
    public int delay = 800;
    float opacity = 1;
    public float growRate = 0.05f;
    public Transform gameOverPrefab;
    float timePassed;

    AudioSource audioData;
    public AudioClip expSound;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioData = GetComponent<AudioSource>();
        audioData.PlayOneShot(expSound, 1f);
        audioData.PlayOneShot(deathSound, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        transform.localScale += new Vector3(growRate, growRate, 0f);
        if (delay < 1) fadeEnable = true; else delay -= 1;
        if (fadeEnable == true) { opacity -= 0.0025f; }
        sprite.color = new Color(1, 0, 0, opacity);
        if (timePassed>3f)
        {
            Instantiate(gameOverPrefab, new Vector2(0, 0), Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }

    }
}
