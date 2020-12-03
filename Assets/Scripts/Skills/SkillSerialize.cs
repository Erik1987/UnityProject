using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SkillStats
{
    public List<Skill> player;
    public List<Skill> rangedNinja;
    public List<Skill> boss;

    public static SkillStats CreateFromJson(string json)
    {
        return JsonUtility.FromJson<SkillStats>(json);
    }
}

[System.Serializable]
public class Skill
{
    public int id;
    public string name;
    public float projectileSpeed;
    public int projectileCount;
    public float projectileSpread;
    public int projectileWaves;
    public float projectileFrequence;
    public float projectileScale;
    public int distance;
    public int duration;
    public bool cooldown;
    public float cooldownTime;
    public bool activated;
}
