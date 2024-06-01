using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDamagable<T>
{
    void takeDamage(T damageTaken);
}

//For breaking obstacles
public interface iCanHit
{
    void takeHit();
}