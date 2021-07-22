using UnityEngine;
using UnityEngine.Serialization;

namespace Myproject.Mob
{
	public class MobAnimator : MonoBehaviour, IMobComponent
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private string AttackTrigger = "Attack";

		public Animator Animator1
		{
			get => _animator;
			private set => _animator = value;
		}

		public void StartAttackAnimation()
		{
			Animator1.SetTrigger(AttackTrigger);
		}

		public void SetIsRun(bool isRun)
		{
			Animator1.SetBool("Run", isRun);
		}

		public void OnDeath()
		{
			Animator1.SetTrigger("Death");
		}
	}
}