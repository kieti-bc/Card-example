using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAdjuster : MonoBehaviour
{
    Transform CardTransform;

    private Animator cardAnimator;
    private BoxCollider HitCollider;
    private float targetRotation = 0;

    private bool isDown = true;
    // Start is called before the first frame update
    void Start()
    {
        CardTransform = transform.GetChild(0);
        HitCollider = GetComponent<BoxCollider>();
        cardAnimator = GetComponentInChildren<Animator>();
    }
    
    public void DoFlip()
    {
        if (isDown)
        {
            cardAnimator.SetTrigger("FlipTrigger");
            isDown = false;
        }
        else
        {
            cardAnimator.SetTrigger("FlipTrigger");
            isDown = true;
        }
        /*
        if (targetRotation < 90.0f)
        {
            targetRotation = 180.0f;
        }
        else if (targetRotation > 90.0f)
        {
            targetRotation = 0.0f;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        // Place the card on top of the collider
        CardTransform.position = HitCollider.bounds.center + HitCollider.size.y/2 * transform.up;
        
        // Rotate when asked
        /* Done with animation now
        float angleNow = CardTransform.rotation.eulerAngles.z;
        float angleDiff = Mathf.Abs(angleNow - targetRotation);
        if (angleDiff < 0.50f)
        {
            targetRotation = angleNow;
        }
        else if (angleNow < targetRotation)
        {
            CardTransform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);
        }
        else if (angleNow > targetRotation)
        {
            CardTransform.Rotate(Vector3.forward, -90.0f * Time.deltaTime);
        }
        */
    }
}
