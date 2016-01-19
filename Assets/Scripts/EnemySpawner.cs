using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
    public GameObject target;
    public float spawnRate = 2.0f;
    public float spawnRateDelta = -0.1f;
    public float spawnRateMinimum = 0.3f;
    protected float spawnCooldown = 0.0f;
    public static int spawns = 0;
    protected int maxSpawns = 300;
    protected static GameObject playerObject;
	// Use this for initialization
	void Start () {
        if (playerObject == null)
        {
            playerObject = GameObject.Find("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0.0f && spawns < maxSpawns && playerObject.GetComponent<PlayerController>() != null)
        {
            Instantiate(target, transform.position, transform.rotation);
            spawns += 1;
            spawnRate += spawnRateDelta;

            if (spawnRate < spawnRateMinimum)
            {
                spawnRate = spawnRateMinimum;
            }
            spawnCooldown = spawnRate;
        }
	}
}
