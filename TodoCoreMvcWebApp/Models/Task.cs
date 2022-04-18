using System.ComponentModel.DataAnnotations;

namespace TodoCoreMvcWebApp.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Title { get; set; }

        [EnumDataType(typeof(TStatus))]
        public TStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;} = DateTime.Now;
        public Task()
        {

        }
        public Task(string title)
        {
            Title = title ;
        }
        public Task DeepCopy()
        {
            Task deepcopyTask = new Task(this.Title);
            return deepcopyTask;
        }
        public enum TStatus
        {
            Open = 0,
            Inprogress = 1,
            Hold = 2,
            InDiscussion = 3,
            Prioterized = 4,
            Blocked= 5,
            Closed = 6,
        }
    }
}
