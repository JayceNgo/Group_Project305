using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scSpawnEnemy : MonoBehaviour
{

    public Transform playerTarget;
    public Transform pawnPrefab;
    public Transform holepuncherPrefab;
    public Transform rakePrefab;
    public Transform motorPrefab;
    public Transform junctionPrefab;
    public float deltaPass;
    public int pawnDelay = 100;
    public int minibossDelay = -999;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        deltaPass += Time.deltaTime;
        //Spawn Timer
        if (minibossDelay < 0 && global.remain < 170 && global.field == 1) minibossDelay = Random.Range(2000, 4000);
        else if (global.field!=1 && minibossDelay < 0) minibossDelay = Random.Range(2000, 4000);

        //Pawn
        if (pawnDelay > 0) pawnDelay -= 1; else if (pawnDelay<1 && global.remain>0)
        {
            Vector2 pawnPosition= new Vector2(0,0);
            float screenSidePawn = Mathf.Round(Random.Range(1, 4)); //Clockwise. 1=Up, 2=Right, 3=Down, 4=Left.
            switch(screenSidePawn)
            {
                case 1: pawnPosition = new Vector2(Random.Range(-8f, 8f), 4f); break;
                case 2: pawnPosition = new Vector2(8f, Random.Range(-4f, 4f)); break;
                case 3: pawnPosition = new Vector2(Random.Range(-8f, 8f), -4f); break;
                case 4: pawnPosition = new Vector2(-8f, Random.Range(-4f, 4f)); break;
            }

            if (global.field != 4)
            {
                Transform pawnSpawn = Instantiate(pawnPrefab, pawnPosition, transform.rotation) as Transform;
                pawnSpawn.GetComponent<scPawnSpawn>().player = playerTarget;
                pawnDelay = 300;
            }
        }

        
        if (minibossDelay > 0 && global.remain>0 && global.field!=4) minibossDelay -= 1;
        else if (minibossDelay <= 0 && minibossDelay>-998)
        {
            double select=0;
            switch (global.field)
            {
                case 1: select = Mathf.Round(Random.Range(1, 1)); break;
                case 2:
                if (global.remain<200) select = Mathf.Round(Random.Range(1, 4));
                else if (global.remain < 350) select = Mathf.Round(Random.Range(1, 3));
                else select = Mathf.Round(Random.Range(1, 1)); break;
                case 3:
                if (global.remain < 300) select = Mathf.Round(Random.Range(1, 5));
                else select = Mathf.Round(Random.Range(1, 4)); break;
            }

            if (select == 1) //Holepuncher
            {
                Vector2 holePosition = new Vector2(0, 0);
                float screenSideHole = Mathf.Round(Random.Range(1, 4)); //Clockwise. 1=Up, 2=Right, 3=Down, 4=Left.
                switch (screenSideHole)
                {
                    case 1: holePosition = new Vector2(Random.Range(-8f, 8f), 4f); break;
                    case 2: holePosition = new Vector2(8f, Random.Range(-4f, 4f)); break;
                    case 3: holePosition = new Vector2(Random.Range(-8f, 8f), -4f); break;
                    case 4: holePosition = new Vector2(-8f, Random.Range(-4f, 4f)); break;
                }

                Transform holeSpawn = Instantiate(holepuncherPrefab, holePosition, transform.rotation) as Transform;
                holeSpawn.GetComponent<scHolepuncher>().targetTransform = playerTarget;
            }

            if (select == 2) //Rake
            {
                Vector2 rakePosition = new Vector2(0, 0);
                float screenSideRake = Mathf.Round(Random.Range(1, 4)); //Clockwise. 1=Up, 2=Right, 3=Down, 4=Left.
                switch (screenSideRake)
                {
                    case 1: rakePosition = new Vector2(Random.Range(-8f, 8f), 4f); break;
                    case 2: rakePosition = new Vector2(8f, Random.Range(-4f, 4f)); break;
                    case 3: rakePosition = new Vector2(Random.Range(-8f, 8f), -4f); break;
                    case 4: rakePosition = new Vector2(-8f, Random.Range(-4f, 4f)); break;
                }

                Transform rakeSpawn = Instantiate(rakePrefab, rakePosition, transform.rotation) as Transform;
                rakeSpawn.GetComponent<scRake>().targetTransform = playerTarget;
            }

            if (select == 3) //Motor
            {
                Vector2 motorPosition = new Vector2(0, 0);
                float screenSideMotor = Mathf.Round(Random.Range(1, 4)); //Clockwise. 1=Up, 2=Right, 3=Down, 4=Left.
                switch (screenSideMotor)
                {
                    case 1: motorPosition = new Vector2(Random.Range(-8f, 8f), 4f); break;
                    case 2: motorPosition = new Vector2(8f, Random.Range(-4f, 4f)); break;
                    case 3: motorPosition = new Vector2(Random.Range(-8f, 8f), -4f); break;
                    case 4: motorPosition = new Vector2(-8f, Random.Range(-4f, 4f)); break;
                }

                Transform motorSpawn = Instantiate(motorPrefab, motorPosition, transform.rotation) as Transform;
                motorSpawn.GetComponent<scMotor>().targetTransform = playerTarget;
            }

            if (select == 4) //Junction
            {
                Vector2 junctionPosition = new Vector2(0, 0);
                float screenSideJunction = Mathf.Round(Random.Range(1, 4)); //Clockwise. 1=Up, 2=Right, 3=Down, 4=Left.
                switch (screenSideJunction)
                {
                    case 1: junctionPosition = new Vector2(Random.Range(-8f, 8f), 4f); break;
                    case 2: junctionPosition = new Vector2(8f, Random.Range(-4f, 4f)); break;
                    case 3: junctionPosition = new Vector2(Random.Range(-8f, 8f), -4f); break;
                    case 4: junctionPosition = new Vector2(-8f, Random.Range(-4f, 4f)); break;
                }

                Transform junctionSpawn = Instantiate(junctionPrefab, junctionPosition, transform.rotation) as Transform;
                junctionSpawn.GetComponent<scJunction>().targetTransform = playerTarget;
            }


            minibossDelay = Random.Range(2500,5000);
        }
    }
}
