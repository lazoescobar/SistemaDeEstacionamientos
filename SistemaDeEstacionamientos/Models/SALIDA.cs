//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaDeEstacionamientos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SALIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALIDA()
        {
            this.BOLETA = new HashSet<BOLETA>();
        }
    
        public int ID_SALIDA { get; set; }
        public System.DateTime FECHA_SALIDA { get; set; }
        public System.TimeSpan HORA_SALIDA { get; set; }
        public int ID_INGRESO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        public virtual INGRESO INGRESO { get; set; }
    }
}