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
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.registro_tratamiento_cliente = new HashSet<registro_tratamiento_cliente>();
        }
    
        public int Id_Cliente { get; set; }
        public string Primer_nombre_Cliente { get; set; }
        public string Segundo_nombre_cliente { get; set; }
        public string Primer_apellido_cliente { get; set; }
        public string Segundo_apellido_cliente { get; set; }
        public string NIT_cliente { get; set; }
        public Nullable<long> teléfono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_tratamiento_cliente> registro_tratamiento_cliente { get; set; }
    }
}
