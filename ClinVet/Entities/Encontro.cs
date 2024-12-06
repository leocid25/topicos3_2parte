using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClinVet.Entities
{
    public class Encontro
    {
        public Encontro()
        {
            Tratamentos = new List<Tratamento>();
            IsDeleted = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [Display(Name = "Nome do Encontro")]
        public string? Nome { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraTermino { get; set; }
        [Display(Name = "Tipo de Consulta")]
        public String TipoConsulta { get; set; }
        [Display(Name = "Valor da Consulta")]
        public double ValorPagoConsulta { get; set; }
        public string Descricao { get; set; }
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Tratamento>? Tratamentos { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string nome, DateTime horaInicio, String tipoConsulta, double valorPagoConsulta, string descricao)
        {
            Nome = nome;
            HoraInicio = horaInicio;
            TipoConsulta = tipoConsulta;
            ValorPagoConsulta = valorPagoConsulta;
            Descricao = descricao;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
