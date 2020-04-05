public class Weapon
{
    private float damage;
    private float reloadTime;

    public float Damage => damage;
    public float ReloadTime => reloadTime;

    public Weapon(float damage, float reloadTime)
    {
        this.damage = damage;
        this.reloadTime = reloadTime;
    }
}