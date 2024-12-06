using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClinVet.Entities
{
    public class Pet
    {
        public Pet()
        {
            Encontros = new List<Encontro>();
            IsDeleted = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

       
        [Display(Name = "Nome do Animal")]
        public string Nome { get; set; }

       
        public string Especie { get; set; }

        public string Raca { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public string Genero { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        public int ProprietarioId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Encontro>? Encontros { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string nome, string especie, string raca, DateTime dataNascimento, string genero)
        {
            Nome = nome;
            Especie = especie;
            Raca = raca;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
