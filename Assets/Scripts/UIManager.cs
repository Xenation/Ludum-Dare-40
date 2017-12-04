﻿using UnityEngine;
using UnityEngine.UI;

namespace LD40 {
	public class UIManager : Singleton<UIManager> {

		public Slider healthSlider;

		public SpellIcon iconFireball;
		public SpellIcon iconIceSpike;
		public SpellIcon iconElectricArv;
		public SpellIcon iconTornado;
		public SpellIcon iconBeam;

		public Color selectedTint;
		public Color unselectedTint;

		private Player player;

		private SpellIcon[] icons;

		public void Awake() {
			FillIconsArray();
		}

		public void Start() {
			player = EntitiesManager.I.player;
			player.OnSpellSelectedEvent += OnSpellSelected;
			healthSlider.maxValue = player.GetMaxHealth();
		}

		private void FillIconsArray() {
			icons = new SpellIcon[5];
			icons[0] = iconFireball;
			icons[1] = iconIceSpike;
			icons[2] = iconElectricArv;
			icons[3] = iconTornado;
			icons[4] = iconBeam;
		}

		public void Update() {
			healthSlider.value = player.health;
		}

		public void OnSpellSelected(SpellType t) {
			foreach (SpellIcon icon in icons) {
				if (icon.type == t) {
					icon.Select();
				} else {
					icon.Unselect();
				}
			}
		}

	}
}