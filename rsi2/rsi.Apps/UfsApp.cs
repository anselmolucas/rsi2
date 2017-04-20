using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class UfsApp
    {
        public IEnumerable<State> ListAll()
        {
            var _uf = new List<State>
            {
                new State() { UF = "sp", Name = "São Paulo"},
                new State() { UF = "ac", Name = "Acre"},
                new State() { UF = "al", Name = "Alagoas"},
                new State() { UF = "ap", Name = "Amapá"},
                new State() { UF = "am", Name = "Amazonas"},
                new State() { UF = "ba", Name = "Bahia"},
                new State() { UF = "ce", Name = "Ceará"},
                new State() { UF = "df", Name = "Distrito Federal"},
                new State() { UF = "es", Name = "Espírito Santo"},
                new State() { UF = "go", Name = "Goiás"},
                new State() { UF = "ma", Name = "Maranhão"},
                new State() { UF = "mt", Name = "Mato Grosso"},
                new State() { UF = "ms", Name = "Mato Grosso do Sul"},
                new State() { UF = "mg", Name = "Minas Gerais"},
                new State() { UF = "pa", Name = "Pará"},
                new State() { UF = "pb", Name = "Paraíba"},
                new State() { UF = "pr", Name = "Paraná"},
                new State() { UF = "pe", Name = "Pernambuco"},
                new State() { UF = "pi", Name = "Piauí"},
                new State() { UF = "rj", Name = "Rio de Janeiro"},
                new State() { UF = "rn", Name = "Rio Grande do Norte"},
                new State() { UF = "rs", Name = "Rio Grande do Sul"},
                new State() { UF = "ro", Name = "Rondônia"},
                new State() { UF = "rr", Name = "Roraima"},
                new State() { UF = "sc", Name = "Santa Catarina"},
                new State() { UF = "se", Name = "Sergipe"},
                new State() { UF = "to", Name = "Tocantins"},
            };

            return _uf;
        }

        public State SearchByUf(string __uf)
        {            
            var _retorno = ListAll();

            return _retorno.Where(x=>x.UF == __uf.ToLower().Trim()).FirstOrDefault();
        }        
    }
}
