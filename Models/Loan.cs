using System.ComponentModel.DataAnnotations;

namespace Lab3_LeChiCuong_2131200001.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "LoanDate is required.")]
        public DateTime LoanDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "DueDate is required.")]
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int Status { get; set; } = 0; // 0: Not returned, 1: Returned, 2: Overdue

        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

    }
}
