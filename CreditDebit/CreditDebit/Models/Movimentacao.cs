using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace CreditDebit.Models
{
    public class Movimentacao
    {
        [PrimaryKey, AutoIncrement]
        public String Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public decimal Valor { get; set; }
    }
}
