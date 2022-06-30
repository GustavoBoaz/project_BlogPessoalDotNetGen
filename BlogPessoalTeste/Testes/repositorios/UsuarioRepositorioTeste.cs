using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.contextos;
using BlogPessoal.src.modelos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.repositorios.implementacoes;
using BlogPessoal.src.utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoalTest.Testes.repositorios
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {
        private BlogPessoalContexto _contexto;
        private IUsuario _repositorio;

        [TestMethod]
        public async Task CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios()
        {
            // Definindo o contexto
            var opt= new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal1")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro 4 usuarios no banco
            await _repositorio.NovoUsuarioAsync(new Usuario
            {
                Nome = "Gustavo Boaz",
                Email = "gustavo@email.com",
                Senha = "134652",
                Foto = "URLFOTO",
                Tipo = TipoUsuario.NORMAL
            });
            
            await _repositorio.NovoUsuarioAsync(new Usuario
            {
                Nome = "Mallu Boaz",
                Email = "mallu@email.com",
                Senha = "134652",
                Foto = "URLFOTO",
                Tipo = TipoUsuario.NORMAL
            });
            
            await _repositorio.NovoUsuarioAsync(new Usuario
            {
                Nome = "Catarina Boaz",
                Email = "catarina@email.com",
                Senha = "134652",
                Foto = "URLFOTO",
                Tipo = TipoUsuario.NORMAL
            });
 
            await _repositorio.NovoUsuarioAsync(new Usuario
            {
                Nome = "Pamela Boaz",
                Email = "pamela@email.com",
                Senha = "134652",
                Foto = "URLFOTO",
                Tipo = TipoUsuario.NORMAL
            });
            
			//WHEN - Quando pesquiso lista total            
            //THEN - Então recebo 4 usuarios
            Assert.AreEqual(4, _contexto.Usuarios.Count());
        }
        
        [TestMethod]
        public async Task PegarUsuarioPeloEmailRetornaNaoNulo()
        {
            // Definindo o contexto
            var opt= new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal2")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(new Usuario
            {
                Nome = "Zenildo Boaz",
                Email = "zenildo@email.com",
                Senha = "134652",
                Foto = "URLFOTO",
                Tipo = TipoUsuario.NORMAL
            });
            
            //WHEN - Quando pesquiso pelo email deste usuario
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync("zenildo@email.com");
			
            //THEN - Então obtenho um usuario
            Assert.IsNotNull(usuario);
        }
    }
}