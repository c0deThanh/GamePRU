using Entity;
using System;
using UnityEngine;

namespace Behaviour
{
    public class Player : MonoBehaviour
    {
        protected PlayerState _state;
        protected void Initialize() { _state = gameObject.GetComponent<PlayerState>(); }

        protected void OnCollisionEnterAttacked(Collision2D collision, Action<Skill, int> attack)
        {
            var opponent = collision.gameObject;
            if (opponent.CompareTag("Weapon"))
            {
                var opponentWeaponSkill = opponent.GetComponent<Skill>();
                _state.Health -= opponentWeaponSkill.Damage;
                attack.Invoke(opponentWeaponSkill, _state.Health);
            }
        }

        public void Heal(int amount)
        {
            if (_state.Health < _state.MaxHealth)
            {
                _state.Health += amount;
                if (_state.Health > _state.MaxHealth)
                {
                    _state.Health = _state.MaxHealth;
                }
            }
        }
    }
}