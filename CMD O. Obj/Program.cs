using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CMD_O.Obj
{
    class Program
    {

        static List<IEstoque1> produtos = new List<IEstoque1>();

        enum Menu { Listar = 1, Adcionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)

            {
                Console.WriteLine(" Sistema de Estoque:");
                Console.WriteLine("1-Listar\n2-Adcionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair ");


                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adcionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }
        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            int i = 0;  
            foreach (IEstoque1 produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i ++;
            }
            Console.ReadLine();

        }


        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que voce quer remover:");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }


        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que voce quer dar Entrada:");
            int id = int.Parse(Console.ReadLine());
            if (id > 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }


        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que voce quer dar Saida:");
            int id = int.Parse(Console.ReadLine());
            if (id > 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }


        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }


        static void CadastrarPFisico()
        {
            Console.WriteLine(" Cadastrando Produto Fisico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }


        static void CadastrarEbook()
        {
            Console.WriteLine(" Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }


        static void CadastrarCurso()
        {
            Console.WriteLine(" Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }


        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, produtos);

            stream.Close();
        }


        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque1>)enconder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque1>();
                }

            }
            catch (Exception e)
            {
                produtos = new List<IEstoque1>();
            }

            stream.Close();

        }
    }
}
