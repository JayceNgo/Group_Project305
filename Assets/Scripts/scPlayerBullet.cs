using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlayerBullet : MonoBehaviour
{

    int bulletlife = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
        if (gameObject.name == "vulcan_S(Clone)") bulletlife = 3;
        else if (gameObject.name == "vulcan_M(Clone)") bulletlife = 4;
        else if (gameObject.name == "vulcan_H(Clone)") bulletlife = 5;
        Physics2D.IgnoreLayerCollision(9, 8, true);
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity.normalized;
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject);
        if (bulletlife <= 0) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            //case "pawn": Destroy(gameObject); break;
            //case "pawn(Clone)": Destroy(gameObject); break;
            case "pawn": bulletlife -= 1; break;
            case "pawn(Clone)": bulletlife -= 1; break;
            case "holepuncher": Destroy(gameObject); break;
            case "holepuncher(Clone)": Destroy(gameObject); break;
            case "rake": Destroy(gameObject); break;
            case "rake(Clone)": Destroy(gameObject); break;
            case "motor": Destroy(gameObject); break;
            case "motor(Clone)": Destroy(gameObject); break;
            case "pawnPlus": bulletlife -= 2; break;
            case "pawnPlus(Clone)": bulletlife -= 2; break;
            case "junction": Destroy(gameObject); break;
            case "junction(Clone)": Destroy(gameObject); break;
            case "hunker": Destroy(gameObject); break;
            case "playercraft": break;
        }
    }
}
