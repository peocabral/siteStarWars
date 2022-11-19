using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DAO;
using Business.Mapping;

namespace Business.Business
{
    public class VeiculosBusiness : VeiculosDAO
    {
        public new List<Veiculos> List()
        {
            var list = base.List();
            list = list.OrderBy(o => o.Nome).ToList();
            return list;
        }
        public new Veiculos Get(int id)
        {
            return base.Get(id);
        }
        public new bool Delete(int id)
        {
            return base.Delete(id);
        }
        public bool Save(string id, string nome, string descricao)
        {
            Veiculos veiculo = new Veiculos();
            veiculo.ID = Convert.ToInt32(id);
            veiculo.Nome = nome.Trim();
            veiculo.Descricao = descricao.Trim();
            if (veiculo.ID == 0)
                return base.Insert(veiculo);
            else
                return base.Update(veiculo);
        }
    }
}
