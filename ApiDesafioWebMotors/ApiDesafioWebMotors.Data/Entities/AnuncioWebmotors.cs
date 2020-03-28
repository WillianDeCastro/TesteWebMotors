using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiDesafioWebMotors.Infra.Data.Entities
{
    [Table("tb_AnuncioWebmotors")]
    public class AnuncioWebmotors
    {

        [Column("ID")]
        public int Id { get; set; }
        [Column("marca")]
        public string Marca { get; set; }
        [Column("modelo")]
        public string Modelo { get; set; }
        [Column("versao")]
        public string Versao { get; set; }
        [Column("ano")]
        public int Ano { get; set; }
        [Column("quilometragem")]
        public int Quilometragem { get; set; }
        [Column("observacao")]
        public string Observacao { get; set; }
    }
}
