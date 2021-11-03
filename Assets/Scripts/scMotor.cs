using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scMotor : MonoBehaviour
{
    bool moveTowardsPlayer = true;
    bool processed = false;
    public Transform attackPrefab;
    public Transform targetTransform;
    int delay = -1;
    int delay2 = -1;
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
        if (moveTowardsPlayer == true && wave == 1 && delay > 200)
        {
            Vector3 vectorToTarget = targetTransform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 45f);
            GetComponent<Rigidbody2D>().velocity = transform.right * Random.Range(1, 2.5f);
        }
        else
        {
            float rotAmount = 90f * Time.deltaTime;
            float curRot = transform.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }

        //Trigger
        if (GetComponent<scEnemyBase>().ready == false && processed == false)
        {
            processed = true;
            delay = 350;
        }
        if (delay == 0) { delay--; delay2 = 0; }
        else delay -= 1;
        if (wave < 12)
        {
            if (delay2 == 80)
            {
                audioData.PlayOneShot(shootSound, 1f);
                //Layer One
                Transform bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 2 + transform.up;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * -2 + transform.up;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * 2 + transform.right;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * -2 + transform.right;

                //Layer Two
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 2 + transform.up*-1;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * -2 + transform.up * -1;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * 2 + transform.right * -1;
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * -2 + transform.right * -1;

                delay2 = 0;
                wave++;
            }
            else delay2 += 1;
        }
    }
}
