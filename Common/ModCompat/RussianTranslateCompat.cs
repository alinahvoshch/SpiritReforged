using SpiritReforged.Content.Desert.ScarabBoss.Items;
using SpiritReforged.Content.Desert.Silk;
using SpiritReforged.Content.Forest.Botanist.Items;
using SpiritReforged.Content.Granite.Armor;
using SpiritReforged.Content.Ocean.Items.DriftwoodSet.DriftwoodArmor;
using SpiritReforged.Content.Ocean.Items.Reefhunter.CascadeArmor;
using SpiritReforged.Content.Savanna.Items.DrywoodSet;
using SpiritReforged.Content.Underground.WayfarerSet;
using SpiritReforged.Content.Vanilla.Leather.MarksmanArmor;
using System.Reflection;

namespace SpiritReforged.Common.ModCompat;

internal class RussianTranslateCompat : ModSystem
{
	public static bool ColoredDamageTypes { get; private set; }
	public override void PostSetupContent()
	{
		var spiritR = Mod;

		if (!CrossMod.RussianLocalizable)
			return;

		var tru = CrossMod.RussianTranslate.Instance;

		Type configType = tru.Code.GetType("CalamityRuTranslate.Core.Config.TRuConfig");
		object configInstance = configType?.GetField("Instance", BindingFlags.Public | BindingFlags.Static)?.GetValue(null);

		if (configType?.GetField("ColoredDamageTypes", BindingFlags.Public | BindingFlags.Instance)?.GetValue(configInstance) is bool value)
			ColoredDamageTypes = value;

		tru.Call("AddFeminineItems", spiritR, new[]
		{
			//Weapons
			"Dragonsong",
			"WoodenClub",
			"BambooHalberd",
			"ToucaneItem",
			"ClawCannon",
			"BombCannon",
			"Bowlder",
			//Accessories
			"Ledger",
			"ScryingLens",
			"SleightOfHand"
		});

		tru.Call("AddNeuterItems", spiritR, new[]
		{
			//Weapons
			"HuntingRifle",
			//Accessories
			"ArcaneNecklaceGold",
			"ArcaneNecklacePlatinum",
			"CraneFeather",
			"SafekeeperRing",
			"PearlString",
			"OceanPendant"
		});

		tru.Call("AddPluralItems", spiritR, new[]
		{
			//Weapons
			"SerratedClaws",
			"LandscapingShears",
			//Accessories
			"ExplorerTreadsItem"
		});

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<BedouinCowl>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Bedouin"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<SunEarrings>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Sundancer"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<BotanistHat>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Botanist"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<GraniteHead>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Granite", Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN")));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<DriftwoodHelmet>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Driftwood"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<LeatherHood>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Marksman"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<AncientMarksmanHood>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Marksman"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<WayfarerHead>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Wayfarer"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<DrywoodHelmet>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Drywood"));

		tru.Call("AddArmorSetBonusPreview", ModContent.ItemType<CascadeHelmet>(), () =>
				Language.GetTextValue("Mods.SpiritReforged.SetBonuses.Cascade"));
	}
}

public static class DamageClassHelper
{
	public static Color GetDamageClassColor(DamageClass damageClass)
	{
		if (CrossMod.RussianLocalizable && RussianTranslateCompat.ColoredDamageTypes == true)
		{
			if (damageClass == DamageClass.Melee || damageClass == DamageClass.MeleeNoSpeed)
				return new Color(255, 85, 85);

			if (damageClass == DamageClass.Ranged)
				return new Color(80, 250, 123);

			if (damageClass == DamageClass.Magic)
				return new Color(189, 147, 249);

			if (damageClass == DamageClass.Summon)
				return new Color(241, 250, 140);

			return Color.White;
		}

		return Color.White;
	}
}