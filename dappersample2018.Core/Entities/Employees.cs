using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dappersample2018.Core.Entities
{
    [Serializable]
    [DataContract]
    public class Employees
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(20)]
        [DataMember]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TitleOfCourtesy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataMember]
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataMember]
        public DateTime? HireDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string HomePhone { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int? ReportsTo { get; set; }
        [DataMember]
        public string PhotoPath { get; set; }
    }
}
