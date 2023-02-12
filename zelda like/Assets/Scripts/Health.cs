using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : GenHealth
{
    [SerializeField] private SignalSender healthSignal;
    // Start is called before the first frame update

    public override void GetDamage(float amountToDamage)
    {
        base.GetDamage(amountToDamage);
        maxHealth.RuntimeValue = currentHealth;
        healthSignal.Raise();
    }
}
