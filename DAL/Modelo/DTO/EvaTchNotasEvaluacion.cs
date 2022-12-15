using System;
using System.Collections.Generic;

namespace DAL.Modelo.DTO;

//Clases para definir los campos de la base de datos
public partial class EvaTchNotasEvaluacion
{
    public string MdUuid { get; set; } = null!;

    public DateTime? MdFch { get; set; }

    public long IdNotaEvaluacion { get; set; }

    public string CodAlumno { get; set; } = null!;

    public long NotaEvaluacion { get; set; }

    public string CodEvaluacion { get; set; } = null!;

    public virtual EvaCatEvaluacion CodEvaluacionNavigation { get; set; } = null!;
}
