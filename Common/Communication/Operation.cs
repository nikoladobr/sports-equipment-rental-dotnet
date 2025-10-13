using System;
using System.
    Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        Login,
        GetAllKategorijaOsobe,
        CreateOsoba,
        GetAllOsoba,
        RemoveOsoba,
        SearchOsoba,
        GetOsobaById,
        UpdateOsoba,
        GetAllOprema,
        CreateIznajmljivanje,
        GetAllZaposleni,
        SearchIznajmljivanje,
        GetIznajmljivanjeById,
        GetIznajmljivanjaByAmountRange,
        GetStavkeByIznajmljivanjeId
    }
}
