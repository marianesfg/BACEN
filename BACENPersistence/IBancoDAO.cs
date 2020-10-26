using System.Data;

namespace BACENPersistence
{
    public interface IBancoDAO
    {
        bool PlanSave(DataTable table);
        //DataTable ObterBancos();
    }
}
