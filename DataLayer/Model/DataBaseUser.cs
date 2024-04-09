using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer.Model
{
    public class DataBaseUser: User
    {
        private int m_ID;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int ID
        {
            get => m_ID;
            set => m_ID = value;
        }

    }
}
