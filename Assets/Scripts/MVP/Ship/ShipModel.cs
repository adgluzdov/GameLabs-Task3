using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel
{
    private float maxHealth;
    private float currentHelth;
    private float maxShield;
    private float currentShield;
    private float shieldRecoverySpeed;
    private float weaponsReloadKoeff;
    private List<WeaponModel> weaponModels = new List<WeaponModel>();
    private Action onZeroHealth;
    private Action onFullShield;
    private Action onChangeHealth;
    private Action onChangeShield;

    public float MaxHealth => maxHealth;
    public float CurrentHelth => currentHelth;
    public float MaxShield => maxShield;
    public float CurrentShield => currentShield;
    public float ShieldRecoverySpeed => shieldRecoverySpeed;
    public float WeaponsReloadKoeff => weaponsReloadKoeff;
    public List<WeaponModel> WeaponModels => weaponModels;

    public ShipModel(Ship ship)
    {
        this.maxHealth = ship.MaxHealth;
        this.currentHelth = ship.MaxHealth;
        this.maxShield = ship.MaxShield;
        this.currentShield = ship.MaxShield;
        this.shieldRecoverySpeed = ship.ShieldRecoverySpeed;
        this.weaponsReloadKoeff = ship.WeaponsReloadKoeff;
        foreach (var weapon in ship.Weapons)
        {
            weaponModels.Add(new WeaponModel(weapon));
        }
    }

    public void SetOnZeroHealthListener(Action onZeroHealth)
    {
        this.onZeroHealth = onZeroHealth;
    }

    public void SetOnFullShield(Action onFullShield)
    {
        this.onFullShield = onFullShield;
    }

    public void SetShieldRecovery(float shieldRecovery)
    {
        currentShield = MathE.Clamp(currentShield + shieldRecovery, 0, maxShield);
        if(onChangeShield != null) {
            onChangeShield.Invoke();
        }
        if (CurrentShield == MaxShield)
        {
            onFullShield.Invoke();
        }
    }

    public void SetOnChangeHealth(Action onChangeHealth) {
        this.onChangeHealth = onChangeHealth;
    }

    public void SetOnChangeShield(Action onChangeShield) {
        this.onChangeShield = onChangeShield;
    }

    public void SetDamage(float damage)
    {
        var diff = Math.Abs(currentShield - damage);
        if(currentShield >= damage)
        {
            currentShield -= damage;
            onChangeShield.Invoke();
        } 
        else 
        {
            if (currentShield != 0) {
                currentShield -= currentShield;
                onChangeShield.Invoke();
            }
                
            if (currentHelth >= diff)
            {
                currentHelth -= diff;
                onChangeHealth.Invoke();
                if (currentHelth == diff) 
                {
                    onZeroHealth.Invoke();
                }
            }
            else
            {
                if (currentHelth != 0)
                {
                    currentHelth -= currentHelth;
                    onChangeHealth.Invoke();
                    onZeroHealth.Invoke();
                }
            }
        }
    }

}

public class WeaponModel
{
    public float damage;
    public float reloadTime;
    public float reloadTimeLeft;

    public WeaponModel(Weapon weapon)
    {
        this.damage = weapon.Damage;
        this.reloadTime = weapon.ReloadTime;
        this.reloadTimeLeft = 0;
    }
}