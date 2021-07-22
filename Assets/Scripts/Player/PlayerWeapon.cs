using System;
using Myproject.EventBus;
using Myproject.EventBus.Messages;
using UnityEngine;

namespace Myproject.Player
{
	public abstract class PlayerWeapon : MonoBehaviour
	{
		[SerializeField] protected WeaponType Type;
		[SerializeField] protected GameObject Model;

		protected virtual void Awake()
		{
			GetComponent<Player>().OnWeaponChange += Change;
		}

		protected virtual void OnDisable()
		{
			GetComponent<Player>().OnWeaponChange -= Change;
			EventBus<PlayerInputMessage>.Unsub(Fire);
		}

		protected void Change(WeaponType type)
		{
			EventBus<PlayerInputMessage>.Unsub(Fire);
			if (type == Type)
			{
				EventBus<PlayerInputMessage>.Sub(Fire);
				GetComponent<PlayerAnimator>().SetAnimatorController(Model);
			}

			Model.SetActive(type == Type);
		}

		protected abstract void Fire(PlayerInputMessage message);
	}

	[Serializable]
	public enum WeaponType
	{
		Rifle,
		Shotgun,
		AutomaticRifle,
		RocketLauncher,
		Sword,
		Bat,
		Grenade
	}
}