
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using DataAccessCore.Entities;
using DataAccessCore.Implementation;

namespace BusinessLogicCore.Implementation
{
    public class BeaconLog : IBeacon
    {
        private Binding binding = new Binding();
        private List<Beacon> lstEmp = new List<Beacon>();
        private Beacon objEmp = new Beacon();

        public IEnumerable<Beacon> BeaconGet()
        {
            lstEmp = binding.GetBeaconRepository.Get().ToList();

            return lstEmp;
        }

        public Beacon BeaconGet(int id)
        {
            objEmp = binding.GetBeaconRepository.GetByID(id);
            return objEmp;
        }
        public Beacon GetByBeaconname(string Beaconname)
        {
            objEmp = binding.GetBeaconRepository.GetByBeaconname(Beaconname);
            return objEmp;
        }

        public int DeActivateBeacon(String beaconname)
        {
            Beacon beacon = GetByBeaconname(beaconname);
            beacon.IsDeleted = true;
            int result = this.binding.Save();

            if (result > 0)
            {
                result = 1;
                return result;
            }
            else
            {
                result = 0;
                return result;
            }
        }

        public int ActivateBeacon(String beaconname)
        {
            Beacon beacon = GetByBeaconname(beaconname);
            beacon.IsDeleted = false;
            int result = this.binding.Save();

            if (result > 0)
            {
                result = 1;
                return result;
            }
            else
            {
                result = 0;
                return result;
            }

        }

        public int BeaconNameUpdate(EditBeaconBindingModel model)
        {
            Beacon beacon = BeaconGet(model.Beacon_id);
            if(beacon!=null)
            {
                beacon.Beacon_title = model.Beacon_title;
            }
            this.binding.GetBeaconRepository.Attach(beacon);
            int result = this.binding.Save();

            if (result > 0)
            {
                result = 1;
                return result;
            }
            else
            {
                result = 0;
                return result;
            }
        }

        public int BeaconInsert(Beacon emp)
        {
            this.binding.GetBeaconRepository.Insert(emp);
            int inserData = this.binding.Save();

            if (inserData > 0)
            {
                inserData = 1;
                return inserData;
            }
            else
            {
                inserData = 0;
                return inserData;
            }
        }
    }
}
