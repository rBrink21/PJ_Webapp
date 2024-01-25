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
    public List<Skill> skills { get; set; } // TODO Spending skill points screen
    public SoldierClass soldierClass { get; set; } //TODO Class selection screen
    public int level { get; set; } 
    public int currentHealth { get; set; } //TODO update methods
    public int maxHealth { get; set; }
    public int mental { get; set; } //TODO update methods
    public SoldierRace soldierRace { get; set; }
    public Loyalty loyalty { get; set; }
    public string characterSheetLink { get; set; } //TODO add button for management of character sheet links
    
    // Defaults
    private const int DEFAULT_HP = 6;
    private const int DEFAULT_MENTAL = 2;
    private const int DEFAULT_LVL = 0;
    private static int[] levelUpCosts = [1, 2, 4, 8, 10]; //TODO T1 Mana stone level ups only right now
    
    // Instance Variables;
    private int availableSkillPoints = 0;
    private bool roleAvailableForAssignment = false;
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
        this.soldierClass = SoldierClass.GRUNT;
        
        level = DEFAULT_LVL;
        currentHealth = DEFAULT_HP;
        maxHealth = DEFAULT_HP;
        mental = DEFAULT_MENTAL;

        characterSheetLink = " ";
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

    public void LevelUp()
    {
        bool canLevelUp = true; //TODO add logic check w resourcemanager
        
        if (canLevelUp)
        {
            level += 1;
            availableSkillPoints += 3;
            if (soldierClass == SoldierClass.GRUNT)
            {
                roleAvailableForAssignment = true;
            }
        }
    }

    public int GetLevelUpCost()
    {
        return levelUpCosts[level];
    }
    public void AssignClass(SoldierClass role){
        this.soldierClass = role;
    }
}