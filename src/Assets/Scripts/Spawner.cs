using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject coin, coinParent, enemyParent;
    public float spawnDelay = 5.0f, spawnRepeat = 3.0f;
    private Vector3[] positions;
    private Vector3 tempPos;
    private Quaternion tempRot;

    // Start is called before the first frame update
    void Start()
    {
        coin = GameObject.Find("Coin");
        coinParent = GameObject.Find("Coin Instances");
        enemyParent = GameObject.Find("Creature Instances");
        positions = new Vector3[0];
        positions.Append(coin.transform.position); // adds first coin position to positions array
        positions.Append(new Vector3(3.83f, 0.89f, 0)); // adds position of NPC to positions array
        // InvokeRepeating("Spawn", spawnDelay, spawnRepeat);
        for(int i = 0; i < 15; i++) {SpawnCoin();}
        for(int i = 0; i < 5; i++) {SpawnEnemy();}
    }

    // Spawns enemy at random positon
    void SpawnEnemy()
    {
        // change gizmo position
        while(true)
        {
            tempPos = transform.position;
            tempPos.x = Random.Range(-9.75f, 9.75f);
            tempPos.y = Random.Range(-4.80f, 4.80f);
            transform.position = tempPos;
            if (positions.Contains(tempPos)) { continue; }
            else { break; }
        }
        positions.Append(tempPos);

        // change gizmo rotation
        tempRot = transform.rotation;
        tempRot.SetEulerAngles(0, 0, Random.Range(0, 360));
        transform.rotation = tempRot;

        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation, enemyParent.transform);
    }

    // Spawns coin at random position
    void SpawnCoin()
    {
        // change gizmo position
        while (true)
        {
            tempPos = transform.position;
            tempPos.x = Random.Range(-9.75f, 9.75f);
            tempPos.y = Random.Range(-4.80f, 4.80f);
            transform.position = tempPos;
            if (positions.Contains(tempPos)) { continue; }
            else { break; }
        }
        positions.Append(tempPos);

        Instantiate(coin, transform.position, transform.rotation, coinParent.transform);

    }


}
