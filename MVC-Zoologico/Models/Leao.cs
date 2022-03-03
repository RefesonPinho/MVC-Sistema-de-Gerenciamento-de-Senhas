using System;
using System.Collections.Generic;

namespace Models
{
    public class Leao : Animal
    {
        private static List<Leao> Leoes = new List<Leao>();
        public int Alimentacao { get; set; }
        public int Visitantes { get; set; }

        public Leao(
            int Id, 
            string Nome, 
            int Alimentacao, 
            int Visitantes
        ) : base(Id, Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Alimentacao = Alimentacao;
            this.Visitantes = Visitantes;

            Leoes.Add(this);
        }

        public static List<Leao> ListarLeoes()
        {
            return Leoes;
        }

        public static Leao ExcluirLeao(int Id)
        {
            Leao leao = Leoes.Find(leao => leao.Id == Id);

            Leoes.Remove(leao);

            return leao;

        }

        public static Leao AlterarLeao(
            int Id, 
            string Nome, 
            int Alimentacao, 
            int Visitantes
        )
        {
            Leao leao = Leoes.Find(leao => leao.Id == Id);

            leao.Id = Id;
            leao.Nome = Nome;
            leao.Alimentacao = Alimentacao;
            leao.Visitantes = Visitantes;

            return leao;
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nNome: {this.Nome}"
                + $"\nAlimentação: {this.Alimentacao}"
                + $"\nVisitantes: {this.Visitantes}";
        }
    }
}