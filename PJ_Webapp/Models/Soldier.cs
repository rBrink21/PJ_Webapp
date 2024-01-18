using System.ComponentModel.DataAnnotations;
using PJ_Webapp.Models.Enums;

namespace PJ_Webapp.Models;

public class Soldier
{
    [Key]
    public Guid soldierId { get; set; }
    public string name { get; set; }
    public int playerId { get; set; }
    private SoldierClass soldierClass;
    private int level;
    private int health;
    private int mental;
    private SoldierRace soldierRace;
    private Loyalty loyalty;
    private string characterSheetLink;

    public Soldier()
    {
        
    }
    public Soldier(string name, int playerId)
    {
        this.name = name;
        this.playerId = playerId;
    }
}