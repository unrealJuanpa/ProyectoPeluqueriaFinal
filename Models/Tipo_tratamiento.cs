//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPeluqueriaFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipo_tratamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_tratamiento()
        {
            this.Promocions = new HashSet<Promocion>();
            this.registro_tratamiento_cliente = new HashSet<registro_tratamiento_cliente>();
        }
    
        public int Id_tipo_tratamiento { get; set; }
        public string Nombre_tratamiento { get; set; }
        public decimal Duracion_horas { get; set; }
        public string imágen_muestra { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promocion> Promocions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_tratamiento_cliente> registro_tratamiento_cliente { get; set; }
    }
}