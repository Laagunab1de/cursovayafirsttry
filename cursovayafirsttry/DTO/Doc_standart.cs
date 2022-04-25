using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursovayafirsttry.DTO
{
    public class Doc_standart//доки для обычных студентов(не сирот)
    {
        public bool EducationDoc { get; set; } //аттестат
        public bool Photo { get; set; } //фото
        public bool FlurograohicExam { get; set; }//флюшка
        public int CopyOfSnils { get; set; }//снилс
        public bool VaccinationDoc { get; set; }//книжка с прививками
        public bool MedicalPolicy { get; set; }//полис
        public bool Passport { get; set; }//пасспорт
    }
}
