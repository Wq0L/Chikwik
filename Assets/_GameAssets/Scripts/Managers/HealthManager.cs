using System;
using Unity.Mathematics;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action OnplayerDeath;
    public static HealthManager Instance { get; private set; }

    [SerializeField] private PlayerHealthUI _playerHealthUI;
    [SerializeField] private int _maxHealth = 3;
     private int _currentHealth;


    void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void Damage (int damageAmount)
        {
            
            if (_currentHealth > 0)
            {
                _currentHealth -= damageAmount;
                _playerHealthUI.AnimateDamage();

                 if (_currentHealth <= 0)
                {
                   OnplayerDeath?.Invoke();
                }
            }
    }

    public void Heal(int healAmount)
    {
       
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
        }
    }



}
