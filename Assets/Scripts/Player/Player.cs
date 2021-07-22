using System;
using UnityEngine;

namespace Myproject.Player
{
	public class Player : MonoBehaviour
	{
		public static Player _instance;
		[SerializeField] private float _damage = 1;
		[SerializeField] private float _moveSpeed = 3.5f;
		[SerializeField] private float _health = 3;
		[SerializeField] private float _maxHealth = 3;
		[SerializeField] private WeaponType _currentWeaponTypeType;
		
		public Action<WeaponType> OnWeaponChange = null;
		public event Action<float, float> OnHPChange = null;
		public event Action OnUpgrade = null;

		public float Damage
		{
			get => _damage;
			private set => _damage = value;
		}

		public float MaxHealth
		{
			get => _maxHealth;
			private set => _maxHealth = value;
		}

		public float MoveSpeed
		{
			get => _moveSpeed;
			private set => _moveSpeed = value;
		}

		public WeaponType CurrentWeaponType
		{
			get => _currentWeaponTypeType;
			private set => _currentWeaponTypeType = value;
		}

		public static Player Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = FindObjectOfType<Player>();
				}

				return _instance;
			}
			
			private set => _instance = value;
		}

		private void Start()
		{
			ChangeWeapon(CurrentWeaponType);
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public void TakeDamage(float amount)
		{
			if (_health <= 0)
				return;
			_health -= amount;
			if (_health <= 0)
			{
				EventBus.EventBus.Pub(EventBus.EventBus.PLAYER_DEATH);
			}

			OnHPChange?.Invoke(_health, -amount);
		}

		public void Heal(float amount)
		{
			if (_health <= 0)
				return;
			_health += amount;
			if (_health > MaxHealth)
			{
				_health = MaxHealth;
			}

			OnHPChange?.Invoke(_health, amount);
		}


		public void Upgrade(float hp, float dmg, float ms)
		{
			Damage += dmg;
			MaxHealth += hp;
			MoveSpeed += ms;
			Heal(hp);
			OnUpgrade?.Invoke();
		}

		public void ChangeWeapon(WeaponType type)
		{
			CurrentWeaponType = type;
			OnWeaponChange?.Invoke(type);
		}
	}
}