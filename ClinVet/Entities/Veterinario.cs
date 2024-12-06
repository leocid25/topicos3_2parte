using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinVet.Entities
{
    public class Veterinario
    {
        public Veterinario()
        {
            Encontros = new List<Encontro>();
            Agendamentos = new List<Agendamento>();
            IsDeleted = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
       
        [Display(Name = "Nome do Veterinário")]
        public string Nome { get; set; }

        
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Cpf { get; set; }

      
        public string Endereco { get; set; }
        public string Especializacao { get; set; }
       
        public string CRMV { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Encontro>? Encontros { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Agendamento>? Agendamentos { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string nome, string email, string telefone, string cpf, string endereco, string especializacao, string crmv)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
            Especializacao = especializacao;
            CRMV = crmv;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
