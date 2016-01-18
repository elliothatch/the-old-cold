using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageOnTouch : MonoBehaviour {

    public int damage = 1;
    public List<int> damageGroups; // 0: player, 1: enemies
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth && damageGroups.Contains(otherHealth.damageGroup))
        {
            otherHealth.hurt(damage);
        }
    }
}
