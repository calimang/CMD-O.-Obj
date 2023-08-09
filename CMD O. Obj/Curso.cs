using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_O.Obj
{
    [System.Serializable]
    class Curso : Produto, IEstoque1
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.autor = autor;
            this.preco = preco;
            this.nome = nome;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adcionar a Qtd. de vagas no curso {nome}");
            Console.WriteLine("Digite a Qtd. de Vagas que voce quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas + entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {nome}");
            Console.WriteLine("Digite a Qtd. de Vagas que voce quer Consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas - entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço:{preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine("=============================");
        }
    }
}
