using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Transform target;
    public int CardValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        CardValue = 10;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }


// Update is called once per frame
    void Update()
    {
        if (this.target != null)
        {
            float distance = Vector3.Distance(this.transform.position, this.target.position);
            if (distance < 0.01f)
            {
                // Reparent to place so that animations work
                transform.SetParent(this.target);
            }
            else
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, this.target.position, Time.deltaTime * 10f);
            }
        }


    }
}
