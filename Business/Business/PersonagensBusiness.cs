using Business.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Mapping;

namespace Business.Business
{
     public class PersonagensBusiness: PersonagensDAO
    {
        public new List<Personagens> List()
        {
            var list = base.List();
            list = list.OrderBy(o => o.Nome).ToList();
            return list;
        }
        public new Personagens Get(int id)
        {
            return base.Get(id);
        }
        public new bool Delete(int id)
        {
            return base.Delete(id);
        }
        public bool Save(string id, string nome, string descricao)
        {
            Personagens personagem = new Personagens();
            personagem.ID = Convert.ToInt32(id);
            personagem.Nome = nome.Trim();
            personagem.Descricao = descricao.Trim();
            if (personagem.ID == 0)
                return base.Insert(personagem);
            else
                return base.Update(personagem);
        }
    }
}
