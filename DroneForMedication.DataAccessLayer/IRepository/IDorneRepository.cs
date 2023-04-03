using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.IRepository
{
    public interface IDorneRepository
    {
        public List<Dorne> GetAllDorneDetails();
        public Task<int> RegisterNewDorne(Dorne newDorne);

        public List<Dorne> GetIdelDorneDetails();
    }
}
