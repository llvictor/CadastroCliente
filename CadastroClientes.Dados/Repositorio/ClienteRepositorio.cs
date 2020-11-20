using CadastroClientes.Dados.Contexto;
using CadastroClientes.Dominio.Entidades;
using CadastroClientes.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Dados.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(Context contexto)
            : base(contexto)
        {

        }
    }
}
