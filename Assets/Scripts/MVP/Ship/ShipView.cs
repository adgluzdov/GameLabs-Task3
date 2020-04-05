using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IShipView {
    void SetMaxHealth(float maxHealth);
    void SetCurrentHealth(float currentHealth);
    void SetMaxShield(float maxShield);
    void SetCurrentShield(float currentShield);
    void ShowMessage(string message);
    void AddOnUpdateListener(OnUpdateListener listener);
}

public interface OnUpdateListener {
    void OnUpdate(float deltaTime);
}
public class ShipView : MonoBehaviour, IShipView
{
    public Text MaxHealth;
    public Text CurrentHealth;
    public Text MaxShield;
    public Text CurrentShield;
    public Text Message;
    private OnUpdateListener onUpdateListener;

    void IShipView.AddOnUpdateListener(OnUpdateListener onUpdateListener)
    {
        this.onUpdateListener = onUpdateListener;
    }

    void IShipView.SetCurrentHealth(float currentHealth)
    {
        CurrentHealth.text = "Текущее здоровье: " + currentHealth.ToString();
    }

    void IShipView.SetCurrentShield(float currentShield)
    {
        CurrentShield.text = "Текущая броня: " + currentShield.ToString("0.0");
    }

    void IShipView.SetMaxHealth(float maxHealth)
    {
        MaxHealth.text = "Максимальное здоровье: " + maxHealth.ToString("0.0");
    }

    void IShipView.SetMaxShield(float maxShield)
    {
        MaxShield.text = "Максимальная броня: " +  maxShield.ToString("0.0");
    }

    void IShipView.ShowMessage(string message)
    {
        Message.text = Message.text + message + "\n";
    }

    void Update() {
        onUpdateListener.OnUpdate(Time.deltaTime);
    }
}
