using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject weapon;

    protected float lastFire1Axis = 0.0f;
    protected bool mouseEnabled = true;
    protected Rigidbody2D rb;
    protected MoveCharacter moveCharacter;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveCharacter = gameObject.GetComponent<MoveCharacter>();
        Health.OnDeath += onDeath;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") || (Input.GetAxis("Fire1") == 1.0f && lastFire1Axis != 1.0f))
        {
            attack();
        }
        lastFire1Axis = Input.GetAxis("Fire1");
	}

    void FixedUpdate()
    {
        float lh = Input.GetAxisRaw("MoveHorizontal");
        float lv = Input.GetAxisRaw("MoveVertical");
        float rh = Input.GetAxisRaw("AimHorizontal");
        float rv = Input.GetAxisRaw("AimVertical");
        if (rh != 0.0f || rv != 0.0f)
        {
            mouseEnabled = false;
        }
        else if (mouseEnabled || (Input.GetAxisRaw("Mouse X") != 0.0f || Input.GetAxisRaw("Mouse Y") != 0.0f))
        {
            mouseEnabled = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDirection = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Vector3.up;
            rh = lookDirection.x;
            rv = -lookDirection.y;
        }
        moveCharacter.move(lh, lv, rh, rv);
    }
    
    void attack()
    {
        GameObject attackObj = (GameObject) Instantiate(weapon, transform.position, transform.rotation);
        //attackObj.transform.parent = transform;
        attackObj.GetComponent<TrackPosition>().target = gameObject;
    }

    void onDeath()
    {
        Debug.Log("Player dead");
    }
}
