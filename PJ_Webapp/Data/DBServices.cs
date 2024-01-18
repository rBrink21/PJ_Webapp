using PJ_Webapp.Models;

namespace PJ_Webapp.Data;

public class DBServices
{
    private DataContext dataContext;
    public DBServices(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }

    public List<Soldier> SaveData(Soldier soldier)
    {
        soldier.soldierId = Guid.NewGuid();
        dataContext.Add(soldier);
        dataContext.SaveChanges();
        return dataContext.soldiers.ToList();
    }
}