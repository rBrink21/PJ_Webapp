using Microsoft.EntityFrameworkCore;
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
            skill.soldierId = soldier.soldierId;
            dataContext.skills.Add(skill);
        }
        dataContext.SaveChanges();
    }

    public void SaveData(Resource resource)
    {
        resource.resourceId = Guid.NewGuid();
        dataContext.resources.Add(resource);
        dataContext.SaveChanges();
    }

    public void SaveData(User user)
    {
        user.userID = Guid.NewGuid();
        dataContext.users.Add(user);
        dataContext.SaveChanges();
    }

    public List<Resource> GetResources()
    {
        return dataContext.resources.ToList();
    }
    public List<Soldier> GetSoldiers()
    {
        return dataContext.soldiers.Include(s => s.skills).ToList();
    }

    public List<User> GetUsers()
    {
        return dataContext.users.ToList();
    }

    public User? GetUserByUsername(string username)
    {
        User? user = dataContext.users.FirstOrDefault(u => u.username == username);
        return user;
    }
    public void DeleteSoldier(Soldier soldier)
    {
        dataContext.soldiers.Remove(soldier);
        dataContext.SaveChanges();
    }

    public void SaveChanges()
    {
        dataContext.SaveChanges();
    }
}