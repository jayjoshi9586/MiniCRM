using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;
using DataAccessCore.Models;

namespace BusinessLogic.Interface
{
    public interface IBeacon
    {
        IEnumerable<BeaconGetModel> BeaconGet();
        int BeaconInsert(Beacon emp);
        //int BeaconUpdate(EditAccountBindingModel model, Beacon user);
        // int AdminDelete(int id);
    }
}


