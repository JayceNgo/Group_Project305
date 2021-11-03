using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scExplosion : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip expSound;
    public bool disableAudio;
    // Start is called before the first frame update
    void Start()
    {
        disableAudio=false;
        Quaternion randomangle = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-360f, 360f));
        transform.rotation = randomangle;
        audioData = GetComponent<AudioSource>();
        //double choose = Math.Round(UnityEngine.Random.Range(1f, 2f));
        //if (choose == 1) audioData.PlayOneShot(expSound2, 1f);
        if (disableAudio==false)
        AudioSource.PlayClipAtPoint(expSound,new Vector3(transform.position.x,transform.position.y,transform.position.z));
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
