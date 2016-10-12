using System.Collections.Generic;

namespace VokabelMnemonikApi.Api
{
    public class VokabelnRepository : IVokabelnRepository
    {
        private List<Vokabel> _alle;

        public VokabelnRepository()
        {
            _alle = new List<Vokabel>();
            _alle.Add(new Vokabel() {Fremdwort = "Gregor", Übersetzung = "Gregory"});
            _alle.Add(new Vokabel() {Fremdwort = "Martin", Übersetzung = "Maratoni"});
        }

        public IEnumerable<Vokabel> Alle()
        {
            return _alle;
        }
    }
}