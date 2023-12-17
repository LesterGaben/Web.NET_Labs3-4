using HospitalRegistrySystem.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistrySystem.DAL.Entities {
    public class Schedule : BaseEntity {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsAviable { get; set; }
        public Doctor Doctor { get; set; }

    }
}
