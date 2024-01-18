using System.ComponentModel.DataAnnotations;
using PJ_Webapp.Models.Enums;

namespace PJ_Webapp.Models;

public class Soldier
{
    // DB Info
    [Key]
    public Guid soldierId { get; set; }
    public string name { get; set; }
    public int playerId { get; set; }
    public List<Skill> skills { get; set; }
    private SoldierClass soldierClass;
    private int level; //TODO add level up mechanics
    private int health;
    private int mental;
    public SoldierRace soldierRace { get; set; }
    public Loyalty loyalty { get; set; }
    private string characterSheetLink;
    
    // Defaults
    private const int DEFAULT_HP = 6;
    private const int DEFAULT_MENTAL = 2;
    private const int DEFAULT_LVL = 0;
    
    public Soldier()
    {
        
    }
    public Soldier(string name, int playerId)
    {
        this.name = name;
        this.playerId = playerId;
    }

    public Soldier(string name, SoldierRace race, Loyalty loyalty)
    {
        this.name = name;
        this.soldierRace = race;
        this.loyalty = loyalty;
        skills = new List<Skill>();
        
        level = DEFAULT_LVL;
        health = DEFAULT_HP;
        mental = DEFAULT_MENTAL;
    }

    public int UpgradeSkill(SoldierSkill skillToUpgrade)
    {
        int upgradeCost = 0;
        bool validUpgrade = true; //Add validation to make sure there is
                                  //enough mana stones or additional criteria are met here

        if (validUpgrade)
        {
            bool foundSkill = false;
            foreach (Skill skill in skills)
            {
                
                if (skill.name == skillToUpgrade)
                {
                    skill.level += 1;
                    upgradeCost = skill.level + 1;
                    foundSkill = true;
                }
            }

            if (foundSkill) { return upgradeCost;}

            Skill newSkill = new Skill(skillToUpgrade);
            skills.Add(newSkill);
            return 1; // Upgrade cost for -1 to 0
        }

        return upgradeCost;
    }
}