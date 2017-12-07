//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Tingoon.Model
//{
//    [Table("Person")]
//    public class Person : AuditableEntity<long>
//    {       

  
//        [MaxLength(50)]
//        public string Name { get; set; }

   
//        [MaxLength(20)]
//        public string Phone { get; set; }


//        [MaxLength(100)]
//        public string Address { get; set; }

  
//        [MaxLength(50)]
//        public string State { get; set; }

//        [Display(Name="Country")]
//        public int CountryId { get; set;  }

//        [ForeignKey("CountryId")]
//        public virtual Country Country { get; set; }

//    }
//}
