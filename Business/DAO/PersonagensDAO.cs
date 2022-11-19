using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Business.Mapping;


namespace Business.DAO
{
    public class PersonagensDAO : Connection
    {
        internal List<Personagens> List()
        {
            return db.Query<Personagens>("SELECT * FROM Personagens").ToList();
        }
        internal Personagens Get(int id)
        {
            return db.Query<Personagens>("SELECT * FROM Personagens Where id=@id", new { id = id }).SingleOrDefault();
        }
        internal bool Delete(int id)
        {
            return db.Execute("Delete Personagens where id=@id", new { id = id }) == 1;
        }
        internal bool Insert(Personagens personagem)
        {
            return db.Execute("Insert into Personagens(Nome,Descricao) values (@Nome,@Descricao)",
                new
                {
                    Nome = personagem.Nome,
                    Descricao = personagem.Descricao
                }) == 1;
        }
        internal bool Update(Personagens personagem)
        {
            return db.Execute("Update  Personagens SET Nome=@Nome,Descricao=@Descricao where ID=@ID",
                new
                {
                    ID = personagem.ID,
                    Nome = personagem.Nome,
                    Descricao = personagem.Descricao
                }) == 1;
        }
    }
}
