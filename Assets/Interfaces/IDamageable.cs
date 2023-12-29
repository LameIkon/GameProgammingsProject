public interface IDamageable
{

    public int HealthPoint { get; set; }
    public int MaxHealthPoints { get; set; }
    void TakeDamage(int amount);
    void Die();

}
