using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClinVet.Entities
{
    public class Proprietario
    {

        public Proprietario() {
            Pets = new List<Pet>();
            IsDelete = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        
        [Display(Name = "Nome do Proprietário")]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        
        public string Email { get; set; }

       
        public string Telefone { get; set; }

      
        public string Endereco { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Pet>? Pets { get; set; }

        public bool IsDelete { get; set; }

        public void Update(string nome, string cpf, string email, string telefone, string endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void Delete()
        { 
            IsDelete = true;
        }
    }
}
