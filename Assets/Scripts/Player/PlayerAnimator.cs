using Myproject.EventBus;
using Myproject.EventBus.Messages;
using Myproject.Utils;
using UnityEngine;

namespace Myproject.Player
{
	public class PlayerAnimator : MonoBehaviour
	{
		[SerializeField] private Animator Animator;
		[SerializeField] private RuntimeAnimatorController RangeAnimator;
		[SerializeField] private RuntimeAnimatorController MeleeAnimator;
		private static readonly int SpeedMultiply = Animator.StringToHash("SpeedMultiply");

		private void Awake()
		{
			EventBus<PlayerInputMessage>.Sub(AnimateRun);
			EventBus.EventBus.Sub(AnimateDeath, EventBus.EventBus.PLAYER_DEATH);
		}

		private void OnDestroy()
		{
			EventBus<PlayerInputMessage>.Unsub(AnimateRun);
			EventBus.EventBus.Unsub(AnimateDeath, EventBus.EventBus.PLAYER_DEATH);
		}

		private void AnimateRun(PlayerInputMessage message)
		{
			Animator.SetBool("Run", message.MovementDirection.sqrMagnitude > 0);
		}

		private void AnimateDeath()
		{
			Animator.SetTrigger("Death");
		}

		public void TriggerShoot()
		{
			Animator.SetTrigger("Attack");
		}

		public void SetAnimatorController(GameObject model)
		{
			if (model.TryGetComponent<Melee>(out var melee))
			{
				Animator.runtimeAnimatorController = MeleeAnimator;
				Animator.SetFloat(SpeedMultiply, melee.Speed);
				Animator.GetComponent<WeaponAnimationMock>().MeleeWeapon = melee;
			}
			else
			{
				Animator.runtimeAnimatorController = RangeAnimator;
				Animator.SetFloat(SpeedMultiply, 1);
				Animator.GetComponent<WeaponAnimationMock>().MeleeWeapon = null;
			}
		}
	}
}