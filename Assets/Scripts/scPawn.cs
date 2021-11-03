using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPawn : MonoBehaviour
{
    public Transform attackPrefab;
    public Transform targetTransform;
    public bool returnFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotAmount = 90f * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));



        if (transform.position.y > 6 || transform.position.y < -6 || transform.position.x < -8.5f || transform.position.x > 8.5f) Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (transform.position.y < 6 && transform.position.y > -6 && transform.position.x > -8.5f && transform.position.x < 8.5f && global.remain > 0 && returnFire==true)
        {
            Vector3 vectorToTarget = targetTransform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 720f);

            Transform bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = (transform.right * 3f);
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = (transform.right * 3f + transform.up / 2f);
                bullet = Instantiate(attackPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Transform;
                bullet.GetComponent<Rigidbody2D>().velocity = (transform.right * 3f + transform.up / -2f);
        }
    }
}
