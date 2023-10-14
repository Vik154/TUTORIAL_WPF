using System.Diagnostics;

namespace TaskManager.API.Models.Interfaces;


public abstract class AbstractionService {

    public bool DoAction(Action action) {
        try {
            action.Invoke();
            return true;
        }
        catch (Exception exp) {
            Debug.WriteLine(exp.Message);
            return false;
        }
    }
}
