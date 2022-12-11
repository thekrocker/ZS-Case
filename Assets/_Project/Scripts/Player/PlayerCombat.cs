using System;
using System.Collections;
using _Project.Scriptable_Objects.So_Scripts;
using Manager;
using Player.Input;
using Statics;
using UnityEngine;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Resource diamondResource;
        [SerializeField] private PlayerCombatStats stats;
        
        private PlayerInputHandler _inputHandler;
        private WaitForSeconds _waitTime;
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _waitTime = new WaitForSeconds(stats.CurrentAttackRate);

        }

        private void Start()
        {
            stats.LoadDamage();
            stats.LoadAttackRate();
        }

        private void OnEnable()
        {
            _inputHandler.OnTapAction += OnAttack;
        }

        private bool _attacking;
        private void OnAttack()
        {
            if (!HasEnoughResource()) return;
            if (_attacking) return;
            
            _attacking = true;
            
            StartCoroutine(IEAttack());
            
            IEnumerator IEAttack()
            {
                if (HasEnoughResource())
                {
                    StaticEvents.OnPlayerAttack?.Invoke();
                    BossManager.Instance.DamageableBoss.Damage(stats.CurrentDamage);
                    diamondResource.Decrease();
                }
                else
                {
                    // Not enough resource... end it..
                    yield break;
                } 
                
                yield return _waitTime;
                _attacking = false;
            }


        }

        private bool HasEnoughResource()
        {
            return diamondResource.CurrentAmount > 0;
        }

        private void OnDisable()
        {
            _inputHandler.OnTapAction -= OnAttack;
        }
    }
}