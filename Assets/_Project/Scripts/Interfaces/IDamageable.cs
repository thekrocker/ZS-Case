using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Enemy;
using UnityEngine;

public interface IDamageable<T>
{
    public Health Health { get; set; }
    public void Damage(T amount);
}
