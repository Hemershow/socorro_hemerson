using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string nome = string.Empty;
bool premiun = false;
int dia = -1;
int mes = -1;
int ano = -1;

List<Cliente> listaClientes = new List<Cliente>();
List<Produto> listaProduto = new List<Produto>();

//Vou completar esta bela obra semana que vem,
//se não for demitido né vai que kkkk
//caracteres úteis: ─│┌┐└┘├┤┬┴┼
Console.WriteLine("┌───┐ ┌───┐");
Console.WriteLine("│┌─┐│ │┌─┐│");
Console.WriteLine("│└─┘│ ││ ││");
Console.WriteLine("│ ┌─┘ ││ ││");
Console.WriteLine("│ └─┐ ││ ││");
Console.WriteLine("│┌─┐│ ││ ││");
Console.WriteLine("│└─┘│ │└─┘│");
Console.WriteLine("└───┘ └───┘");
Console.WriteLine("\t\tTecnologia para a vida");
Console.WriteLine("");
Console.WriteLine("Pressione qualquer tecla para começar...");
Console.ReadKey(true);

while (true)
{
    Console.Clear();
    Console.WriteLine("O que você quer fazer?");
    Console.WriteLine("1 - Cadastrar Novo cliente");
    Console.WriteLine("2 - Ler dados do cliente");
    Console.WriteLine("3 - Cadastrar Novo produto");
    Console.WriteLine("4 - Ler dados do produto");
    Console.WriteLine("5 - Sair");
    int id = int.Parse(Console.ReadLine());
    switch(id)
    {
        case 1:
            Console.Write("Digite o nome do Cliente:");
            nome = Console.ReadLine();

            Console.Write("Digite o dia do nascimento do Cliente:");
            dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mês do nascimento do Cliente:");
            mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano do nascimento do Cliente:");
            ano = int.Parse(Console.ReadLine());

            Console.Write("O seu cliente é premium? (S/N):");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "S")
            {
                premiun = true;
            }
            else
            {
                premiun = false;
            }

            Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
            listaClientes.Add(cliente);
            cliente.Save();
            break;
        
        case 2:
            Console.Write("Digite o nome do Cliente:");
            nome = Console.ReadLine();
            
            foreach (Cliente i in listaClientes)
            {
                if (!listaClientes.Contains(i))
                {
                    Console.WriteLine("Cliente não encontrado =(");
                    break;
                }

                if (i.Nome == nome)
                {
                    i.Save();
                }
            }
            break;
        
        case 3:

            Console.Write("Digite o nome do produto:");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Digite o preço do produto");
            float preco = float.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(nomeProduto,preco);

            listaProduto.Add(novoProduto);

            break;

        case 4:
            
            Console.Write("Digite o nome do produto:");
            string produtoProcurado = Console.ReadLine();

            foreach (Produto i in listaProduto)
            {
                if (!listaProduto.Contains(i))
                {
                    Console.WriteLine("Produto não encontrado =(");
                    break;
                }
                if (i.Nome == produtoProcurado)
                {
                    Console.WriteLine(i.Nome);
                    Console.WriteLine(i.Preco);
                    break;
                }
            }

            break;
    }   
}

public class Cliente
{
    public Cliente(string nome, bool premium, int dia, int mes, int ano)
    {
        this.Nome = nome;
        this.Premium = premium;
        this.DiaNascimento = dia;
        this.MesNascimento = mes;
        this.AnoNascimento = ano;
    }

    public string Nome { get; set; }
    public bool Premium { get; set; }
    public int DiaNascimento { get; set; }
    public int MesNascimento { get; set; }
    public int AnoNascimento { get; set; }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Premium);
        writer.WriteLine(this.DiaNascimento);
        writer.WriteLine(this.MesNascimento);
        writer.WriteLine(this.AnoNascimento);

        writer.Close();
    }

    public static Cliente Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();
        bool premiun = bool.Parse(reader.ReadLine());
        int dia = int.Parse(reader.ReadLine());
        int mes = int.Parse(reader.ReadLine());
        int ano = int.Parse(reader.ReadLine());
        
        Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
        return cliente;
    }
}

public class Produto
{
    public string Nome { get; set;}
    public float Preco { get; set;}
    public Produto(string nome, float preco)
    {
        this.Nome = nome;
        this.Preco = preco;
    }
}