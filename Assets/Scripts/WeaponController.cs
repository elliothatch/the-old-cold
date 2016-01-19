using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour {

    [System.Serializable]
    public class Weapon {
        public GameObject prefab;
        public float baseAttackSpeed = 1.0f;
    }
    public List<Weapon> weapons;
    protected Weapon equippedWeapon;
    protected float attackCooldown = 0.0f;
	// Use this for initialization
	void Start () {
        equippedWeapon = weapons[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (attackCooldown > 0.0f)
        {
            attackCooldown -= Time.deltaTime;
        }
	}

    public void equipWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
    }

    public void attack()
    {
        if (attackCooldown <= 0.0f)
        {
            attackCooldown = equippedWeapon.baseAttackSpeed;
            GameObject attackObj = (GameObject)Instantiate(equippedWeapon.prefab, transform.position, transform.rotation);
            attackObj.GetComponent<TrackPosition>().target = gameObject;
        }
    }
}
