using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Report
    {
       
        public string Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Orden")]
        public int Order { get; set; }

        [Display(Name = "Tamaño")]
        public BoxSize BoxSize { get; set; }

        [Display(Name = "Tipo de Gráfico")]
        public ChartType ChartType { get; set; }
    }

    public enum BoxSize
    {
        OneColumns,
        TwoColumns,
        ThreeColumns,
        HalfPage,
        FullPage
    }

    public enum ChartType
    {
        Column,
        Bar,
        Pie,
        Grid
    }
}
