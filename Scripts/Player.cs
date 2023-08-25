using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;
    public float Health => _health;

    public event UnityAction<float> HealthChanged;

    public void Start()
    {
        _maxHealth = _health;
    }

    public void HealthChanger(float healthButton)
    {
        if (CheckedLife())
        {
            _health += healthButton;
            HealthChanged?.Invoke(_health);
        }
    }

    public bool CheckedLife()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        return _health <= _maxHealth;
    }
}
