using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHealthChanger : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnButtonClick(float healthButton)
    {
        _player.HealthChanger(healthButton);
    }
}
