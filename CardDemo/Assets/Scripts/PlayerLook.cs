using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame updat}e
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Do something with the object that was hit by the raycast.
                if (hit.transform.CompareTag("Card"))
                {
                    Transform objectHit = hit.transform;
                    CardAdjuster c = objectHit.GameObject().GetComponent<CardAdjuster>();
                    c.DoFlip();
                }
            }
        }
    }
}
