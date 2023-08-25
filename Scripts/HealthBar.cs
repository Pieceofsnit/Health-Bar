using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _recoveryRate;

    private Coroutine _changeBar;
    private float _health;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    public void Start()
    {
        _slider.maxValue = _player.Health;
        _slider.value = _player.Health;
        _health = _player.Health;
    }

    private void OnHealthChanged(float health)
    {
        if (_player.CheckedLife())
            _changeBar = StartCoroutine(ChangeHealthBar(health));
    }

    private IEnumerator ChangeHealthBar(float health)
    {
        _health = health;
        while (_health != _slider.value)
        {
            Debug.Log("Корутина " + _health);
            _slider.value = Mathf.MoveTowards(_slider.value, _health, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
