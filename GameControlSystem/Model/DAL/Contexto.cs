using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL {
    public class Contexto : DbContext {

        public Contexto() : base("PRD_GAME") {
        }

        public DbSet<Campeonato> Campeonatos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Estadio> Estadios { get; set; }

        public DbSet<Gol> Gols { get; set; }

        public DbSet<Jogador> Jogador { get; set; }

        public DbSet<Partida> Partidas { get; set; }

        public DbSet<Time> Times { get; set; }

    }
}
