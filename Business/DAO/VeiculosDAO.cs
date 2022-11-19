using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Business.DAO
{
    public class VeiculosDAO : Connection
    {
        internal List<Veiculos> List()
        {
            return db.Query<Veiculos>("SELECT * FROM Veiculos").ToList();
        }
        internal Veiculos Get(int id)
        {
            return db.Query<Veiculos>("SELECT * FROM Veiculos Where id=@id", new { id = id }).SingleOrDefault();
        }
        internal bool Delete(int id)
        {
            return db.Execute("Delete Veiculos where id=@id", new { id = id })==1;
        }
        internal bool Insert(Veiculos veiculo)
        {
            return db.Execute("Insert into Veiculos(Nome,Descricao) values (@Nome,@Descricao)",
                new {
                    Nome = veiculo.Nome,
                    Descricao = veiculo.Descricao
                })==1;
        }
        internal bool Update(Veiculos veiculo)
        {
            return db.Execute("Update  Veiculos SET Nome=@Nome,Descricao=@Descricao where ID=@ID",
                new
                {
                    ID=veiculo.ID,
                    Nome = veiculo.Nome,
                    Descricao = veiculo.Descricao
                }) == 1;
        }
    }
}
