using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float curHealth;
    [SerializeField]
    float maxHealth = 100f;
    [SerializeField]
    CapsuleCollider hurtBox;

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

    private void OnTriggerEnter(Collider other)
    {
        // make sure the player was hit by a baguette
        if (!other.CompareTag("Baguette")) return;

        Debug.Log("Player hit by baguette" + this);

        TakeDamage(10);
    }
}
