using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageOnTouch : MonoBehaviour {

    public int damage = 1;
    public int damageCount = 0; // number of times this can hurt the same enemy. 0 means infinite
    public List<int> damageGroups; // 0: player, 1: enemies

    private Dictionary<Health, int> gameObjectHits = new Dictionary<Health,int>();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        hurt(otherHealth);
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        hurt(otherHealth);
    }

    void hurt(Health otherHealth)
    {
        if (otherHealth && damageGroups.Contains(otherHealth.damageGroup))
        {
            if(damageCount == 0) {
                otherHealth.hurt(damage);
            }
            else {
                int hits = 0;
                if (gameObjectHits.TryGetValue(otherHealth, out hits))
                {
                    if (hits < damageCount)
                    {
                        gameObjectHits[otherHealth] = hits + 1;
                        otherHealth.hurt(damage);
                    }
                }
                else
                {
                    gameObjectHits[otherHealth] = 1;
                    otherHealth.hurt(damage);
                }
            }
        }
    }
}
