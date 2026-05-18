using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    //public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 100;
        healthBar.value = 100;
        
    }

    public void SetHealth(int newHealth)
    {
        healthBar.value = Mathf.Max(0, newHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
