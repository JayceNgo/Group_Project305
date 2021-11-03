using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scHolepuncher : MonoBehaviour
{
    bool moveTowardsPlayer = true;
    bool processed = false;
    public Transform attackPrefab;
    public Transform targetTransform;
    float speed = 0;
    int delay = -1;
    int delay2 = -1;
    public int shotCount = 1;
    int wave = 1;
    AudioSource audioData;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        Vector3 vectorToTarget = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 45f);
        if (moveTowardsPlayer == true && wave==1 && delay>200) GetComponent<Rigidbody2D>().velocity = transform.right * Random.Range(1, 2.5f);

        //Trigger
        if (GetComponent<scEnemyBase>().ready == false && processed == false)
        {
            processed = true;
            delay = 350;
        }
        if (delay == 0 && speed == 0) { speed = 0.75f; delay2 = 0; }
        else delay -= 1;
        if (speed > 0 && speed <= shotCount)
        {
            if (delay2 == 30)
            {
                audioData.PlayOneShot(shootSound, 1f);
                //Layer 1
                Transform bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * (2f + (0.75f * speed));
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y - 0.1f), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * (2f + (0.75f * speed));

                speed += 0.5f;
                delay2 = 0;
            }
            else delay2 += 1;
        }
        else if (wave == 1 && speed >= shotCount)
        {
            speed = 0;
            delay = 250;
            delay2 = -1;
            wave = 2;
        }

    }
}
