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
    public SoldierClass soldierClass { get; set; } 
    public int level { get; set; } 
    public int currentHealth { get; set; } 
    public int maxHealth { get; set; }
    public int mental { get; set; } 
    public SoldierRace soldierRace { get; set; }
    public Loyalty loyalty { get; set; }
    public string characterSheetLink { get; set; } //TODO add button for management of character sheet links

    public SoldierHealthStatus healthStatus { get; set; } = SoldierHealthStatus.HEALTHY;
    
    // Defaults
    private const int DEFAULT_HP = 6;
    private const int DEFAULT_MENTAL = 2;
    private const int DEFAULT_LVL = 0;
    private static int[] levelUpCosts = [1, 2, 4, 8, 10]; //TODO T1 Mana stone level ups only right now
    
    // Instance Variables;
    public int availableSkillPoints { get; set; } = 0;
    public bool roleAvailableForAssignment { get; set; } = false;
    public Soldier()
    {
        
    }
    
    public Soldier(string name, SoldierRace race, Loyalty loyalty)
    {
        this.name = name;
        this.soldierRace = race;
        this.loyalty = loyalty;
        skills = new List<Skill>();
        soldierClass = SoldierClass.GRUNT;
        level = DEFAULT_LVL;
        currentHealth = DEFAULT_HP;
        maxHealth = DEFAULT_HP;
        mental = DEFAULT_MENTAL;

        characterSheetLink = " ";
    }

    public void UpgradeSkill(Skill skillToUpgrade)
    {
        if (skillToUpgrade.GetUpgradeCost() > availableSkillPoints) { return; }
        
        foreach (Skill skill in skills) 
        {
            if (skill.name == skillToUpgrade.name)
            {
                availableSkillPoints -= skillToUpgrade.GetUpgradeCost();
                skill.level += 1;
                return;
            }
        }
        InitializeSkill(skillToUpgrade);
    }
    public void InitializeSkill(Skill newSkill)
    {
        foreach (Skill skill in skills)
        {
            if (skill.name == newSkill.name)
            {
                skill.level += 1;
                return;
            }
        }
        skills.Add(newSkill);
    }
    public bool LevelUp()
    {
        bool canLevelUp = true; //TODO add logic check w resourcemanager
        
        if (canLevelUp)
        {
            level += 1;
            switch (level)
            {
                case 1:
                {
                    roleAvailableForAssignment = true;
                    break;
                }
                case 2:
                {
                    availableSkillPoints += 3;
                    break;
                }
                //TODO Expand case structure
            }
        }

        return canLevelUp;
    }
    public int GetLevelUpCost()
    {
        return levelUpCosts[level];
    }
    public void AssignClass(SoldierClass role){
        this.soldierClass = role;
        roleAvailableForAssignment = false;
    }
}