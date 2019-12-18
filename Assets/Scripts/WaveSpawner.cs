using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;
    public TextMesh m;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private PlayerMovement player;
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
    }
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(enemyIsAlive() == false)
            {
                waveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void waveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        nextWave++;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves");
        }
        else
        {
            nextWave++;
        }

    }

    bool enemyIsAlive() {

        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave w)
    {
        Debug.Log("Spawning wave " + w.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < w.count; i++)
        {
            SpawnEnemy(w.enemy);
            yield return new WaitForSeconds(1f / w.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform e)
    {
        float distance = Mathf.Infinity;
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject[] inimigo = GameObject.FindGameObjectsWithTag("Enemy");

        if (inimigo.Length == 0)
        {
            Instantiate(e, sp.position, sp.rotation);
        }
        else
        {
            GameObject closest = null;
            foreach (GameObject i in inimigo)
            {
                Vector3 dif = i.transform.position - sp.position;
                float curDist = dif.sqrMagnitude;
                if (curDist < distance)
                {
                    closest = i;
                    distance = curDist;
                }
            }
            Vector3 enePos = closest.transform.position;
            float leftExtend = enePos.x - 2;
            float rightExtend = enePos.x + 2;
            float lowerExtend = enePos.z - 2;
            float upperExtend = enePos.z + 2;

            //TODO: put an if statement here to decide whether to spawn this...
            if ((sp.position.x - leftExtend > 2.1 || rightExtend - sp.position.x > 2.1) && (sp.position.z - lowerExtend > 2.1 || upperExtend - sp.position.z > 2.1))
            {
                Instantiate(e, sp.position, sp.rotation);
                return;
            }
            else
            {
                int s = spawnPoints.Length;
                for (int i = 0; i < 10000; i++) 
                {
                    sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    if ((sp.position.x - leftExtend > 2.1 || rightExtend - sp.position.x > 2.1) && (sp.position.z - lowerExtend > 2.1 || upperExtend - sp.position.z > 2.1))
                    {
                        Instantiate(e, sp.position, sp.rotation);
                        return;
                    }
                }
            }
        }
        //Instantiate(e, sp.position, sp.rotation);
        //Debug.Log("Spawning enemy: " + e.name);
    }

    IEnumerator ShowMessage(string message)
    {
        m.text = message;
        yield break;
    }

    void playerDeath()
    {
        if(player.playerHealth < 0.0)
        {
            GameObject p = GameObject.FindGameObjectWithTag("player");
            player.moveSpeed = 0.0f;
            ShowMessage("Game over");
            Debug.Log("game over");
        }
    }

    //This function prevents an enemy object spawning when the collider of another enemy object is on top
    //of the spawn point
    /*void preventSpawnOverlap(Vector3 spawnPos)
    {
        return;
    }
    */
}
