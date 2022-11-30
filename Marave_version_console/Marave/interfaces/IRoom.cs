using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marave.classes;

namespace Marave.interfaces
{
    public interface IRoom
    {
        public bool CheckEndGame(Hero hero, int roundNumber);
    }
}
