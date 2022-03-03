using System;

namespace Models
{
    public class Animal
    {
        protected int Id { get; set; }
        protected string Nome { get; set; }

        public Animal(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
    }
}