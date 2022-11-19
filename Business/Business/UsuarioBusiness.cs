using Business.DAO;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Business.Business
{
    public class UsuarioBusiness : UsuarioDao
    {
        public Usuario Logar(string login, string senha)
        {
            senha = new Utilitario().Criptografar(senha);

            return base.Buscar(login, senha);
        }

        public bool Criar(string email, string nome)
        {
            var existe = base.Buscar(email);
            if (existe == null)
            {
                Usuario usuario = new Usuario();
                usuario.ID = Guid.NewGuid();
                usuario.Login = email;
                usuario.Nome = nome;

                var resp = base.Criar(usuario);

                if (resp)
                {
                    try
                    {
                        new Utilitario().SendMail(
                            "Projeto X - Ativação de usuário",
                            "<b>Olá " + nome + @", bem Vindo ao sistema projeto X</b><br><br><br>
                            Ative seu cadastro clicando no link abaixo:<br>
http://stars220171201122110.azurewebsites.net/admin/usuario/ativar?chave=" + new Utilitario().Criptografar(DateTime.Now.AddHours(1) + ";" + usuario.ID),
                            email
                            );
                    }
                    catch
                    {
                        throw new Exception("erro ao enviar email!");
                    }

                    return true;
                }
                else
                    return false;
            }
            else
                throw new Exception("usuário já cadastrado!");
        }


        public bool Ativar(Guid id)
        {
            try
            {
                var usuario = base.Buscar(id);
                if (usuario == null)
                    return false;
                else
                    return true;
            }
            catch { return false; }
        }

        public bool Recuperar(string email)
        {
            var existe = base.Buscar(email);
            if (existe == null)
            {
                throw new Exception("usuário não cadastrado!");
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.ID = existe.ID;
                usuario.Login = existe.Login;
                usuario.Senha = null;
                var resp = base.ZerarSenha(usuario);

                if (resp)
                {
                    try
                    {
                        new Utilitario().SendMail(
                            "Projeto X - Recuperação de Senha",
                            "<b>Olá " + existe.Nome + @", </b><br><br><br>
                            Clique para cadastrar sua nova senha:<br>
http://stars220171201122110.azurewebsites.net/admin/usuario/ativar?chave=" + new Utilitario().Criptografar(DateTime.Now.AddHours(1) + ";" + usuario.ID),
                            email
                            );
                    }
                    catch
                    {
                        throw new Exception("erro ao enviar email!");
                    }

                    return true;
                }
                else
                    return false;
            }
        }
    }
}
