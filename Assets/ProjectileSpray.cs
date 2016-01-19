using UnityEngine;
using System.Collections;

public class ProjectileSpray : MonoBehaviour {

    public GameObject projectile;
    public int count = 5;
    public float spread = 20.0f;
    public float speed = 4.0f;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < count; i++)
        {
            GameObject attackObj = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody2D rb = attackObj.GetComponent<Rigidbody2D>();
            rb.velocity = transform.rotation * Quaternion.Euler(0.0f, 0.0f, spread/count * i - spread/2.0f) *
                Vector2.up * speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
