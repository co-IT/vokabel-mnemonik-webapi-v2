using System.Collections.Generic;

namespace VokabelMnemonikApi.Api
{
    public interface IVokabelnRepository
    {
        IEnumerable<Vokabel> Alle();
    }
}