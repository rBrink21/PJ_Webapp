using PJ_Webapp.Models;

namespace PJ_Webapp.Data;

public class DBServices
{
    private DataContext dataContext;
    public DBServices(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public void SaveData(Soldier soldier)
    {
        soldier.soldierId = Guid.NewGuid();
        dataContext.soldiers.Add(soldier);
        foreach (Skill skill in soldier.skills)
        {
            skill.skillId = Guid.NewGuid();
            dataContext.skills.Add(skill);
        }
        dataContext.SaveChanges();
    }
}