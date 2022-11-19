using Business.DAO;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class ArmasBusiness: ArmasDAO
    {
        public new List<Armas> List()
        {
            var list = base.List();
            list = list.OrderBy(o => o.Nome).ToList();
            return list;
        }
        public new Armas Get(int id)
        {
            return base.Get(id);
        }
        public new bool Delete(int id)
        {
            return base.Delete(id);
        }
        public bool Save(string id,string nome,string descricao)
        {
            Armas arma = new Armas();
            arma.ID = Convert.ToInt32(id);
            arma.Nome = nome.Trim();
            arma.Descricao = descricao.Trim();
            if (arma.ID == 0)
                return base.Insert(arma);
            else
                return base.Update(arma);
        }
    }
}
