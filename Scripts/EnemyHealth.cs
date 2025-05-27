using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 30;
    private int _currentHealth;
    private Animator _animator;
    [SerializeField] private Collider[] weapon;

    void Awake()
    {
        _currentHealth = startingHealth;
        _animator = GetComponent<Animator>();
        DisableWeapons();
    }

    public bool isDead()
    {
        return _currentHealth <= 0;
    }

    public void EnableWeapons()
    {
        foreach (Collider weapon in weapon)
            weapon.enabled = true;
    }

    public void DisableWeapons()
    {
        foreach (Collider weapon in weapon)
            weapon.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth > 0)
        {
            _animator.SetTrigger("Hit");
        }
        else
        {
            _animator.SetTrigger("Dead");

            // Reward XP on death
            if (XPManager.Instance != null)
            {
                XPManager.Instance.AddKillXP();
            }

            // Destroy the zombie after a delay to allow death animation
            Destroy(gameObject, 2f);
        }
    }

    void Update()
    {
      
    }
}
