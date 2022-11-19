using Business.Business;
using Business.DAO;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiStars.Controllers
{
    public class PersonagensController : ApiController
    {
        // GET: api/Personagens
        public IEnumerable<Personagens> List()
        {
            return new PersonagensBusiness().List();
        }

        // GET: api/Personagens/5
        public Personagens Get(int id)
        {
            return Get(id);
        }

        // POST: api/Personagens
        public bool Insert(int id, string nome, string descricao)
        {

        }

        // PUT: api/Personagens/5
        public bool Update(int id, string nome, string descricao)
        {
            Personagens personagem = new Personagens();
            personagem.ID = Convert.ToInt32(id);
            personagem.Nome = nome.Trim();
            personagem.Descricao = descricao.Trim();
            if (personagem.ID == 0)
                return PersonagensDAO().Insert(personagem);
            else
                return Update(personagem);
        }

        // DELETE: api/Personagens/5
        public bool Delete(int id)
        {
            return Delete(id);
        }
    }
}
