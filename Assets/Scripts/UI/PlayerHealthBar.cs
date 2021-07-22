using System.Collections;
using TMPro;
using UnityEngine;

namespace Myproject.UI
{
	public class PlayerHealthBar : MonoBehaviour
	{
		[SerializeField] private GameObject Bar;
		[SerializeField] private SpriteRenderer BarImg;
		[SerializeField] private TMP_Text Text;
		[SerializeField] private TMP_Text DamageText;
		private float maxHP;
		private Player.Player player;
		private IEnumerator FadeDamageText;

		private void Awake()
		{
			player = GetComponent<Player.Player>();
			player.OnHPChange += OnHPChange;
			FadeDamageText = FadeText();
		}

		public void OnDeath()
		{
			Bar.SetActive(false);
			player.OnHPChange -= OnHPChange;
		}

		private void LateUpdate()
		{
			Bar.transform.rotation = Camera.main.transform.rotation;
		}

		private void OnHPChange(float health, float diff)
		{
			var frac = health / player.MaxHealth;
			Text.text = $"{health:####}/{player.MaxHealth:####}";
			BarImg.size = new Vector2(frac, BarImg.size.y);
			var pos = BarImg.transform.localPosition;
			pos.x = -(1 - frac) / 2;
			BarImg.transform.localPosition = pos;
			if (health <= 0)
			{
				Bar.SetActive(false);
			}
			
			UpdateDamageText(diff);
		}

		private void UpdateDamageText(float value)
		{
			if (value == 0) return;
			
			StopCoroutine(FadeDamageText);
			DamageText.color = value < 0 ? Color.red : Color.green;
			DamageText.text = $"{value}";

			StartCoroutine(FadeDamageText);
		}

		private IEnumerator FadeText()
		{
			while (DamageText.color.a > 0)
			{
				DamageText.color = Color.Lerp(DamageText.color, Color.clear, Time.deltaTime/1.5f);
				yield return null;
			}
		}

		private void OnUpgrade()
		{
			
		}
	}
}