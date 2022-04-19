using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursovayafirsttry.Tools;

namespace cursovayafirsttry.DTO
{

    internal class Enrolle 
    {
        public int ID { get; set; }
        public string surname { get; set; }      
        public string FirstName { get; set; }
        public string patronymic { get; set; }
        public string FormOfeducation { get; set; }
        public string AvailabilityOfBenefits { get; set; }
        public int DisciplineId { get; set; }
        public int CertificateId { get; set; }
        public int passdetailsId { get; set; }
        public int OtherOtphanId { get; set; }//ид списка документов для абитуриентов без родителей :(
        public int StandartId { get; set; }
    }
}

