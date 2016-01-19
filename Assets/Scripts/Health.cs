using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Text healthText;
    public int damageGroup;
    public int health;
    public float noDamageDuration;
    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;
    public delegate void OnHurtDelegate();
    public event OnHurtDelegate OnHurt;
    private float noDamageTimeRemaining = 0.0f;
	// Use this for initialization
	void Start () {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
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
            if (healthText != null)
            {
                healthText.text = health.ToString();
            }
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
