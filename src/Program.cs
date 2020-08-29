using System;
using System.Collections.Generic;
using System.Linq;
using NetCoreLiteDB.Data;
using NetCoreLiteDB.Models;

namespace NetCoreLiteDB
{
    class Program
    {
        private static AppDbContext _appDbContext;

        static void Main()
        {
            _appDbContext = new AppDbContext();

            //Inserir um objeto
            var id = Inserir();

            //Selecionar objeto inserido
            var pessoa = Selecionar(id);

            //Atualizar o objeto
            Atualizar(id, pessoa);

            //Listar todos os objetos da coleção
            Listar();

            //Excluir um objeto
            Excluir(id);
        }

        public static Guid Inserir()
        {
            var pessoa = new Pessoa
            {
                Nome = "Pessoa teste",
                Salario = 100.50M,
                Endereco = new Endereco
                {
                    Cep = "17207000",
                    Logradouro = "Nome da rua da pessoa",
                    Numero = "123",
                    Bairro = "Bairro da pessoa",
                    Cidade = "Cidade da pessoa",
                    Uf = "SP"
                },
                Telefones = new List<Telefone>
                {
                    new Telefone{
                        Prefixo= "14",
                        Numero= "9123456789",
                        Tipo = TelefoneTipos.Celular
                    },
                    new Telefone{
                        Prefixo= "11",
                        Numero= "9987654321",
                        Tipo = TelefoneTipos.Comercial
                    },
                    new Telefone
                    {
                        Prefixo = "11",
                        Numero="36251487",
                        Tipo = TelefoneTipos.Fixo
                    }
                }
            };

            _appDbContext.Pessoas.Insert(pessoa);

            Console.WriteLine($"\nId da pessoa inserida:\n{pessoa.Id}\n");

            return pessoa.Id;
        }

        public static Pessoa Selecionar(Guid id)
        {
            var pessoa = _appDbContext.Pessoas.Find(x => x.Id == id).FirstOrDefault();

            Console.WriteLine($"\nPessoa selecionada:\n{pessoa.ToJson()}\n");

            return pessoa;
        }

        public static void Atualizar(Guid id, Pessoa obj)
        {
            obj.Nome = "Nome atualizado";

            _appDbContext.Pessoas.Update(obj);

            var pessoa = _appDbContext.Pessoas.Find(x => x.Id == id).FirstOrDefault();

            Console.WriteLine($"\nPessoa atualizada:\n{pessoa.ToJson()}\n");
        }

        public static void Listar()
        {
            var pessoas = _appDbContext.Pessoas.Find(x => true).ToList();

            Console.WriteLine($"\nLista de pessoas:\n{pessoas.ToJson()}\n");
        }

        public static void Excluir(Guid id)
        {
            _appDbContext.Pessoas.Delete(id);

            Console.WriteLine($"\nPessoa excluída com sucesso:\n{id}\n");
        }
    }
}