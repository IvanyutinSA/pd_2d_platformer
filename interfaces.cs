interface IArmed
{
    public Health health {get;} 
    public IWeapon weapon {get;}
}

interface IWeapon
{
    public int Damage {get;};
    public int Cooldown {get;};

    public void Attack() {}
}

interface Enemy: IArmed
{
    public Health health;
    public IWeapon weapon;
    public Attack();
}

interface IDeadable
{
    public void Death();
}

class PassiveEnemy
{
    public Health health;
    public IWeapon weapon;

    public void Update()
    {
        if (EnemyNearby())
        {
            Attack();
        }

        else 
        {
            Move();
        }
    }

    public Death()
    {
    }

    private void 

    public void Attack()
    {
        AnimationsBeforeAttack();
        weapon.Attack();
        AnimationAfterAttack();
    }

    private void AnimationAfterAttack()
    {
        wait.Delay(delayAfterAttack);
    }
}


class DummyWeapon(): IWeapon
{
    public int Damage {get;}
    public int Cooldown {get;}

    public void Attack()
    {
        Debug.Log("Attacked!!!!");
    }
}
