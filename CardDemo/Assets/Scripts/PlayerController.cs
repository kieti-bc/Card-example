using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 1.0f;
    public int health = 100;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = GetComponent<Transform>();
        if (Input.GetKeyDown(KeyCode.W))
        {
            myTransform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myTransform.Translate(-Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            myTransform.Translate(-Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            myTransform.Translate(Vector3.right);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            Debug.Log("OnTriggerEnter with Interact");
            health--;
            healthBar.SetHealth(health);
        }
        else
        {
            Debug.Log("OnTriggerEnter with " + LayerMask.LayerToName(other.gameObject.layer));
        }

    }
}
