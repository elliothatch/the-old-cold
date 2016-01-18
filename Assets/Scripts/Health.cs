using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int damageGroup;
    public int health;
    public float noDamageDuration;
    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate OnDeath;
    public delegate void OnHurtDelegate();
    public static event OnHurtDelegate OnHurt;
    private float noDamageTimeRemaining = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (noDamageTimeRemaining > 0)
        {
            noDamageTimeRemaining -= Time.deltaTime;
        }
	}

    public void hurt(int damage)
    {
        if (noDamageTimeRemaining <= 0)
        {
            health -= damage;
            noDamageTimeRemaining = noDamageDuration;
            if(OnHurt != null) {
                OnHurt();
            }
            if (health <= 0)
            {
                if (OnDeath != null)
                {
                    OnDeath();
                }
            }
        }
    }
}
