//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ged_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class directory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public directory()
        {
            this.directory1 = new HashSet<directory>();
            this.files = new HashSet<file>();
        }
    
        public int idDirectory { get; set; }
        public int idUser { get; set; }
        public Nullable<int> Dir_idDirectory { get; set; }
        public int idOwner { get; set; }
        public Nullable<int> Use_idUser { get; set; }
        public string DirectoryName { get; set; }
        public System.DateTime dateCreationD { get; set; }
        public short isLockedD { get; set; }
        public string urlD { get; set; }
        public short isDeletedD { get; set; }
        public string descriptionD { get; set; }
        public Nullable<short> IsArchiveD { get; set; }
        public string ArchiveNameD { get; set; }
        public Nullable<System.DateTime> ArchiveDateD { get; set; }
    
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<directory> directory1 { get; set; }
        public virtual directory directory2 { get; set; }
        public virtual ownerinformation ownerinformation { get; set; }
        public virtual user user1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> files { get; set; }
    }
}