using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float curHealth;

    float maxHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }

    void TakeDamage(float damage)
    {

    }
}
