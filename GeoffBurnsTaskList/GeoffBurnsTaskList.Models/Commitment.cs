using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GeoffBurnsTaskList.Models
{
    [DataContract]
    public class Commitment
    {
        public Commitment()
        {
            DueDate = DateTime.Now.Date;
            Priority = PriorityStatus.High;
            Task = string.Empty;
        }

        [Required]
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime DueDate { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "Enter a proper discription for the task")]
        [DataMember]
        public string Task { get; set; }

        [Required]
        [DataMember]
        public PriorityStatus Priority { get; set; }
    }
}