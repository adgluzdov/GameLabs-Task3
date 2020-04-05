public interface IShipPresenter {
    void SetEnemy(Enemy enemy);
}

public interface Enemy
{
    void OnTakeStrike(float damage);
}

public class ShipPresenter : IShipPresenter, Enemy, OnUpdateListener
{
    private IShipView view;
    private ShipModel model;
    private Enemy enemy;

    public ShipPresenter(IShipView view, ShipModel model)
    {
        this.view = view;
        this.model = model;
        view.AddOnUpdateListener(this);
        model.SetOnZeroHealthListener(OnZeroHealth);
        model.SetOnFullShield(OnFullShield);
        model.SetOnChangeHealth(onChangeHealth);
        model.SetOnChangeShield(onChangeShield);
        view.SetMaxHealth(model.MaxHealth);
        view.SetMaxShield(model.MaxShield);
    }

    private void onChangeShield()
    {
        view.SetCurrentShield(model.CurrentShield);
    }

    private void onChangeHealth()
    {
        view.SetCurrentHealth(model.CurrentHelth);
    }

    private void OnFullShield()
    {
        view.ShowMessage("Броня полностью восстановлена!");
    }

    private void OnZeroHealth()
    {
        view.ShowMessage("Жизни закончились!");
    }

    void Enemy.OnTakeStrike(float damage)
    {
        view.ShowMessage("Получил урон: " + damage);
        model.SetDamage(damage);
    }

    void IShipPresenter.SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
        view.ShowMessage("Враг установлен!");
    }

    public void Shoot(WeaponModel weapon) {
        view.ShowMessage("Наношу урон: " + weapon.damage);
        enemy.OnTakeStrike(weapon.damage);
        view.ShowMessage("Перезарядка: " + weapon.reloadTime * model.WeaponsReloadKoeff);
        weapon.reloadTimeLeft += weapon.reloadTime * model.WeaponsReloadKoeff;
    }

    void OnUpdateListener.OnUpdate(float deltaTime)
    {
        if (enemy != null)
        {
            foreach (var weapon in model.WeaponModels)
            {
                if (weapon.reloadTimeLeft > 0)
                {
                    weapon.reloadTimeLeft -= deltaTime;
                }
                else 
                {
                    Shoot(weapon);
                }
            }
        }

        if (model.CurrentShield < model.MaxShield) {
            model.SetShieldRecovery(model.ShieldRecoverySpeed * deltaTime);
        }
        
    }

}