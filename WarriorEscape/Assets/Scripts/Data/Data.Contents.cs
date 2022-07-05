using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

	#region PlayerStats
	[Serializable]
	public class PlayerStats
	{
		public int Level;
		public int MaxHp;
		public int MaxExp;
		public int Attack;
		public int AttackSpeed;
		public int Lucky;
		public int Splash;
	}

	[Serializable]
	public class PlayerStatData : ILoader<int, PlayerStats>
	{
		public List<PlayerStats> playerStats = new List<PlayerStats>();

		public Dictionary<int, PlayerStats> MakeDict()
		{
			Dictionary<int, PlayerStats> dict = new Dictionary<int, PlayerStats>();
			foreach (PlayerStats stat in playerStats)
				dict.Add(stat.Level, stat);
			return dict;
		}
	}
	#endregion

	#region Skills
	[Serializable]
	public class Skills
	{
		public int SkillId;
		public string skillTitle;
		public Defines.SkillTypes skillType;
		public string skillInfo;
		public int SkillLevel;
		public int SkillTime;
		public int MaxHp;
		public int Attack;
		public int AttackSpeed;
		public int Lucky;
		public Defines.SpecialTypes specialType;
	}

	[Serializable]
	public class SkillData : ILoader<int, Skills>
	{
		public List<Skills> skills = new List<Skills>();

		public Dictionary<int, Skills> MakeDict()
		{
			Dictionary<int, Skills> dict = new Dictionary<int, Skills>();
			foreach (Skills skill in skills)
				dict.Add(skill.SkillId, skill);
			return dict;
		}
	}
	#endregion
}