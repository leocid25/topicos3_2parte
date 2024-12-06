using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClinVet.Entities
{
    public class Agendamento
    {
        public Agendamento()
        {
            IsDeleted = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
       
        public DateTime DataInicio { get; set; }
       
        public DateTime DataFim { get; set; }
        
        
        public string? Titulo { get; set; }
        
        public string? Descricao { get; set; }
        
        public string? NomeCliente { get; set; }
       
        public string? TelefoneCliente { get; set; }
        public int VeterinarioId { get; set; }
        public bool IsDeleted { get; set; }


        public void Update(DateTime dataInicio, DateTime dataFim, string titulo, string descricao, string nomeCliente, string telefoneCliente)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            Titulo = titulo;
            Descricao = descricao;
            NomeCliente = nomeCliente;
            TelefoneCliente = telefoneCliente;

        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
