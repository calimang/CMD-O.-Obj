using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_O.Obj
{
    [System.Serializable]
     class Ebook : Produto, IEstoque1
    {
        public string autor;
        private int vendas;

        public Ebook (string nome, float preco, string autor)
        {
            this.autor = autor;
            this.preco = preco;
            this.nome = nome;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Nao é possivel dar entrada no Estoque do Ebook, pois é digital.");
            Console.ReadLine(); 
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adcionar Vendas no E-book  {nome}");
            Console.WriteLine("Digite a Qtd. de Vendas que voce quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas = vendas + entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço:{preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine("=============================");
        }
    }
}
