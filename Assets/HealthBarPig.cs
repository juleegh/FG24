using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarPig : MonoBehaviour
{
    private float health = 500;
    [SerializeField] private Image healthBar;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= 100 * Time.deltaTime;
        healthBar.fillAmount = health / 500;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
