using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    protected MoveCharacter moveCharacter;
    protected static GameObject playerObject;
    protected ScoreController scoreController;
	// Use this for initialization
	void Start () {
        if (playerObject == null)
        {
            playerObject = GameObject.Find("Player");
        }
        moveCharacter = gameObject.GetComponent<MoveCharacter>();
        gameObject.GetComponent<Health>().OnDeath += onDeath;
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if (playerObject.GetComponent<PlayerController>() != null)
        {
            Vector3 relativePosition = (playerObject.transform.position - transform.position).normalized;
            moveCharacter.move(relativePosition.x, relativePosition.y, relativePosition.x, relativePosition.y);
        }
    }

    void onDeath()
    {
        scoreController.increaseScore(1);
        EnemySpawner.spawns -= 1;
        Destroy(gameObject);
    }
}
