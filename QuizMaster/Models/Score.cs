using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaster.Models
{
    public class Score : BaseModel
    {
        public int RegistrationNumber { get; set; }
        public DateTime TestDate { get { return DateTime.Now; } }
        public int StudentScore  { get; set; }
        public string StudentName { get; set; }
        public int ExaminationId { get; set; }
        [ForeignKey("ExaminationId")]
        public Examination Examination { get; set; }
    }
}
