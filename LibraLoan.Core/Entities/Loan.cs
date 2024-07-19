//using LibraLoan.Core.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LibraLoan.Core.Entities
//{
//    public class Loan : BaseEntity
//    {
//        public int UserId { get; set; }
//        public int BookId { get; set; }
//        public BooksStatusEnum Status { get; private set; }
//        public DateTime LoanDate { get; set; }

//        public User Client { get; set; }
//        public Book Book { get; set; }

//        //public void Loan(int idClient)
//        //{
//        //    if(Status == BooksStatusEnum.Avaliable)
//        //    {
//        //        Status = BooksStatusEnum.CheckedOut;
//        //        LoanDate = DateTime.Now;
//        //        UserId = idClient;
//        //    }
//        //}
//    }
//}
