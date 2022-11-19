using Business.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAO
{
    public class UsuarioDao : Connection
    {
        public Usuario Buscar(Guid id)
        {
            return db.Query<Usuario>(@"
                            SELECT 
                            ID, Nome, Login 
                            FROM Usuarios
                            WHERE 
                            ID = @ID", new { id = id }).SingleOrDefault();
        }

        public Usuario Buscar(string email)
        {
            return db.Query<Usuario>(@"
                            SELECT 
                                ID, Nome, Login 
                            FROM Usuarios
                                WHERE 
                            Login = @login", new { login = email }).SingleOrDefault();
        }

        public Usuario Buscar(string email, string senha)
        {
            return db.Query<Usuario>(@"
                            SELECT 
                            ID, Nome, Login 
                            FROM Usuarios
                            WHERE 
                            Login = @login and Senha = @senha ",
                            new
                            {
                                login = email,
                                senha = senha
                            }).SingleOrDefault();
        }

        public bool Criar(Usuario usuario)
        {
            return db.Execute(@"INSERT INTO Usuarios 
                            (ID, Nome, Login) VALUES 
                            (@ID, @Nome, @Login)",
                            new
                            {
                                id = usuario.ID,
                                nome = usuario.Nome,
                                login = usuario.Login
                            }) == 1;
        }

        public bool TrocarSenha(Usuario usuario)
        {
            return db.Execute(@"UPDATE Usuarios SET  
                                   Senha = @senha
                                   where ID = @ID",
                            new
                            {
                                id = usuario.ID,
                                senha = new Utilitario().Criptografar(usuario.Senha)
                            }) == 1;
        }

        public bool ZerarSenha(Usuario usuario)
        {
            return db.Execute(@"UPDATE Usuarios SET  
                                   Senha = @senha
                                   where Login = @Login",
                            new
                            {
                                login = usuario.Login,
                                senha = usuario.Senha
                            }) == 1;
        }
    }
}
