using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClinVet.Entities
{
    public class Tratamento
    {
        public Tratamento()
        {
            IsDeleted = false;
        }
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ser maior que zero.")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraTermino { get; set; }
        [Display(Name = "Valor do Tratamento")]
        public double ValorPagoTratamento { get; set; }
        public int EncontroId { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string descricao, DateTime horaInicio, DateTime horaTermino, double valorPagoTratamento)
        {
            Descricao = descricao;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            ValorPagoTratamento = valorPagoTratamento;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
