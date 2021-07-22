using System.Collections;
using Myproject.Utils;
using UnityEngine;

namespace Myproject.Mob
{
    public abstract class MobAttack : MonoBehaviour
    {
        [SerializeField] protected GameObject AttackSignal;
        [SerializeField] protected float AttackDistance = 1f;
        [SerializeField] protected float AttackDelay = 1f;
        [SerializeField] private float AttackCooldown = 1f;

        protected MobMover mover;
        protected Mob mob;
        private MobAnimator mobAnimator;
        private bool attacking;
        private Coroutine _attackCoroutine = null;

        protected bool Attacking
        {
            get => attacking;
            set
            {
                attacking = value;
                AttackSignal?.SetActive(attacking);
            }
        }

        protected void Awake()
        {
            mob = GetComponent<Mob>();
            mover = GetComponent<MobMover>();
            mobAnimator = GetComponent<MobAnimator>();
            EventBus.EventBus.Sub(OnDeath, EventBus.EventBus.PLAYER_DEATH);
        }

        protected void OnDestroy()
        {
            EventBus.EventBus.Unsub(OnDeath, EventBus.EventBus.PLAYER_DEATH);
        }

        protected void Update()
        {
            if (Attacking)
            {
                return;
            }

            var playerDistance = (transform.position - Player.Player.Instance.transform.position).Flat().magnitude;
            if (playerDistance <= AttackDistance && _attackCoroutine == null)
            {
                Attacking = true;
                _attackCoroutine = StartCoroutine(Attack());
            }
        }

        protected virtual IEnumerator Attack()
        {
            mobAnimator.StartAttackAnimation();
            mover.Active = false;
            yield return new WaitForSeconds(AttackDelay);
			
            ExecuteAttack();

            Attacking = false;
            mover.Active = true;
            yield return new WaitForSeconds(AttackCooldown);
            _attackCoroutine = null;
        }

        protected abstract void ExecuteAttack();

        public virtual void OnDeath()
        {
            enabled = false;
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
            }
        }
    }
}