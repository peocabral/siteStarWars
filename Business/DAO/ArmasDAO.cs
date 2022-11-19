using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Business.Mapping;
namespace Business.DAO
{
    public class ArmasDAO : Connection
    {
        internal List<Armas> List()
        {
            return db.Query<Armas>("SELECT * FROM Armas").ToList();
        }
        internal Armas Get(int id)
        {
            return db.Query<Armas>("SELECT * FROM Armas Where ID=@id", new { id = id }).SingleOrDefault();
        }
        internal bool Delete(int id)
        {
            return db.Execute("Delete Armas where id=@id", new { id = id }) == 1;
        }
        internal bool Insert(Armas arma)
        {
            return db.Execute("Insert into Armas(Nome,Descricao) values (@Nome,@Descricao)",
                new
                {
                    Nome = arma.Nome,
                    Descricao = arma.Descricao
                }) == 1;
        }
        internal bool Update(Armas arma)
        {
            return db.Execute(@"Update Armas SET Nome=@Nome,Descricao=@Descricao where ID=@ID",
                new
                {
                    ID = arma.ID,                    
                    Nome = arma.Nome,
                    Descricao = arma.Descricao
                }) == 1;
        }
    }
}
