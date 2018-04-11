using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gold.Interfaces;

public class CharacterHealth : MonoBehaviour, IDamageable
{
	//Passes the percent health for the ui
    public Gold.Delegates.ValueChange<int> OnHealthChanged;
	//Passes the percent health for the ui
    public Gold.Delegates.ValueChange<int> OnMaxHealthChanged;
    //Called whenever the Damage function is called
    public Gold.Delegates.ValueChange<DamageData> OnHit;
    //Called whenever the CharacterHealth takes damage
    public Gold.Delegates.ValueChange<DamageData> OnDamage;
    public Gold.Delegates.Inform OnDeath;

    //onHealthChange(int health)
    //onMaxHealthChange(int maxHealth)
    //onDamage(DamageData hit)
    //onDeath()

    [SerializeField] private float editorHealth;
    [SerializeField] private float editorMaxHealth;
    public bool isMortal = true;
    public bool canTakeDamage = true;
    private float _health;
    private float _maxHealth;


    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            editorHealth = _health;
            if (OnHealthChanged != null)
            {
                OnHealthChanged((int)_health);
            }

        }
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value;
            if (OnMaxHealthChanged != null)
            {
                OnMaxHealthChanged((int)_maxHealth);
            }
        }
    }

	private void Start()
	{
		Health = editorMaxHealth;
	}

    public void Damage(DamageData hit)
    {
		if(OnHit != null)
		{
			OnHit(hit);
		}

        if (canTakeDamage)
        {
            if (OnDamage != null)
            {
                OnDamage(hit);
            }

            Health -= hit.damage;
            //characterSpriteManager.Flash(flashTimes, immunityLength / flashTimes);

            //onDamage
            // if (!hit.damageOverTime)
            // {
            //     //canTakeDamage = false;
            //     //Invoke("SetCanTakeDamage", immunityLength);
            // }

            if ((Health <= 0 || hit.killInstantly) && isMortal)
            {
                //onDeath
                if (OnDeath != null)
                {
                    OnDeath();
                }

            }
        }
    }

	bool isSettingCanTakeDamage = false;
	bool setCanTakeDamage = false;
	public void DelaySetCanTakeDamage(float time, bool value)
	{
		if(!isSettingCanTakeDamage)
		{
			setCanTakeDamage = value;
			isSettingCanTakeDamage = true;
			Invoke("SetCanTakeDamage", time);
		}
	}

	void SetCanTakeDamage()
	{
		canTakeDamage = setCanTakeDamage;
		isSettingCanTakeDamage = false;
	}

    private void OnValidate()
    {
        Health = editorHealth;
        MaxHealth = editorMaxHealth;
    }
}
