using ApiDesafioWebMotors.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDesafioWebMotors.Infra.Data.Context
{
    public class WebMotorsContext : DbContext
    {
        public WebMotorsContext(DbContextOptions opt) : base(opt)
        {

        }


        public DbSet<AnuncioWebmotors> Anuncios { get; set; }
    }
}
