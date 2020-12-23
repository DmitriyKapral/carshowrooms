using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public interface Irepository
    {
        IEnumerable<Clients> GetClients();

        IEnumerable<Positions> GetPositions();

        bool AddPositions(Positions newPositions);

        bool AddClients(Clients newClient);

        bool DeletePositions(Positions newPositions);

        bool DeleteClients(Clients newClients);

        bool UpdatePositions(Positions newPositions);

        bool UpdateClients(Clients newClients);

        string PercentToName(Clients newClients);

        string AverageSalary(Positions newPositions);
    }

}
