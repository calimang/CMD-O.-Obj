using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_O.Obj
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque1
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adcionar entrada no Estoque do Produto{nome}");
            Console.WriteLine("Digite a Qtd. que voce quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque = estoque + entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adcionar saida no Estoque do Produto{nome}");
            Console.WriteLine("Digite a Qtd. que voce quer dar saida: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque = estoque - entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço:{preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine("=============================");
        }
    }
}
