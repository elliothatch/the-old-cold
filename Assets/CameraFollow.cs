using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    public Vector3 offset;
    public Vector2 aimOffset;
    public int damping = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {
        if (!target)
            return;
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        float desiredX = target.transform.position.x - aimOffset.x * Mathf.Cos((Mathf.PI * (-target.transform.rotation.eulerAngles.z + 90.0f)) / 180);
        float desiredY = target.transform.position.y + aimOffset.y * Mathf.Sin((Mathf.PI * (-target.transform.rotation.eulerAngles.z + 90.0f)) / 180);
        currentX = Mathf.Lerp(currentX, desiredX, damping * Time.deltaTime);
        currentY = Mathf.Lerp(currentY, desiredY, damping * Time.deltaTime);
        transform.position = new Vector3(currentX, currentY, 0.0f) + offset;
    }
}
