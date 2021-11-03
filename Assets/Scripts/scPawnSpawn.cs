using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPawnSpawn : MonoBehaviour
{

    public Transform pawnPrefab;
    public Transform pawnPlusPrefab;
    public Transform player;
    float density;
    int delay=0;
    float randomspeed;
    Transform pawnSelect;
    float pluschance = 0;

    void Awake()
    {
        density = Mathf.Round(Random.Range(1f, 4f));
        randomspeed = Random.Range(1, 3);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        if (global.field > 2 && global.remain<450) pluschance = Mathf.Round(Random.Range(1, 5));
        pawnSelect = pawnPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        Vector3 vectorToTarget = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 180f);

        if (delay < 100) delay++;
        else if (delay > 9)
        {
            if (pluschance==3) pawnSelect = pawnPlusPrefab; else pawnSelect = pawnPrefab;
            //Enemy Spawning
            float offset = -0.25f;
            Transform pawn = Instantiate(pawnSelect, transform.position, transform.rotation) as Transform;
            Physics2D.IgnoreCollision(pawn.GetComponent<Collider2D>(), pawn.GetComponent<Collider2D>());
            pawn.GetComponent<Rigidbody2D>().velocity = transform.right * randomspeed;
            pawn.GetComponent<scPawn>().targetTransform = player;
            for (float i = density * -1; i <= density; i++)
            {
                if (i == -4 || i == 4) offset = -1f; else if(i == -3 || i == 3) offset = -0.75f; else if (i == -2 | i == 2) offset = -0.5f; else offset = -0.25f; //there's probably a way to optimize this
                pawn = Instantiate(pawnSelect, transform.position + (transform.right * (1f * offset)) + (transform.up * (0.25f * i)), Quaternion.identity) as Transform;
                Physics2D.IgnoreCollision(pawn.GetComponent<Collider2D>(), pawn.GetComponent<Collider2D>());
                pawn.GetComponent<Rigidbody2D>().velocity = transform.right * randomspeed;
                pawn.GetComponent<scPawn>().targetTransform = player;
                if (i == -1) i++;  
            }
            Destroy(this.gameObject);
        }
    }
}
