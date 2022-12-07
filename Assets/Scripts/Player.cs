using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float curHealth;
    [SerializeField]
    float maxHealth = 100f;

    private void Start()
    {
        curHealth = maxHealth;
    }

    void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth < 0f) curHealth = 0f;
    }

    public float GetCurHealth()
    {
        return curHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
