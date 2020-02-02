using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public float timeUpdate;
    public float timeUntilHeal;
    private bool _isDamaged = false;

    private EquipmentManager _equipmentManager;

    private void Start()
    {
        _equipmentManager = GetComponent<EquipmentManager>();
    }

    private void Update()
    {
        if (!_isDamaged)
        {
            timeUpdate += Time.deltaTime;

            if (timeUpdate >= timeUntilHeal)
            {
                Heal();
            }
        }
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            health = maxHealth;
            //TODO:: Call drop random item    
        }
        
        _isDamaged = true;
    }

    private void Heal()
    {
        timeUpdate = 0;

        if (health < maxHealth)
        {
            health++;
        }
    }
}
