using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gold
{
    namespace Delegates
    {
        public delegate void ValueChange<T>(T value);
        public delegate void Inform();
    }

    namespace Interfaces
    {
        [System.Serializable]
        public struct DamageData
        {
            public float damage;
            public bool knockback;
            public bool killInstantly;
            public bool damageOverTime;

            public DamageData(float damage, bool knockback = false)
            {
                this.damage = damage;
                this.knockback = knockback;
                killInstantly = false;
                damageOverTime = false;
            }

            public DamageData(DamageData other)
            {
                damage = other.damage;
                knockback = other.knockback;
                killInstantly = other.killInstantly;
                damageOverTime = other.damageOverTime;
            }
        }

        public interface IDamageable
        {
            void Damage(DamageData hit);
        }
    }
}
