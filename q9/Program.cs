using System.Linq;
using System.Collections.Generic;
using System;

App.Run();

public class Pesquisador
{
    public IEnumerable<Colaborador> Search(
        IEnumerable<Colaborador> collab,
        string parametro)
    {
        List<Colaborador> colaboradores = new List<Colaborador>();
        List<string> not = new List<string>();

        foreach (string i in parametro.Split(" "))
        {
            if (i[0] == '-')
            {
                not.Add(i);
            }
        }

        foreach(Colaborador i in collab)
        {
            
            if ((i.Nome.Contains(parametro) || i.Cargo.Contains(parametro) || i.Setor.Contains(parametro) || i.Edv.Contains(parametro)))
            {
                foreach(string j in not)
                {
                    if (!i.Nome.Contains(j) && !i.Cargo.Contains(j) && !i.Setor.Contains(j) && !i.Edv.Contains(j))
                    {
                        colaboradores.Add(i);
                    }
                }
            }
        }   
            return colaboradores;
    }

}
public class Colaborador
{
    public Colaborador(string nome, string cargo, string setor, string edv)
    {
        this.Nome = nome;
        this.Cargo = cargo;
        this.Setor = setor;
        this.Edv = edv;
    }

    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Setor { get; set; }
    public string Edv { get; set; }
}