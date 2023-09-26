using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Encomenda
    {
        public int Id { get; set; }
        public string DadosEncomenda { get; set; }
    }

    public class EncomendaEspecial : Encomenda { 
        public bool EmbalarParaPresente { get; set; }
    }

    public class TabelaAleatoriaParaExemplos
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.Identity)]
        public Guid ChavePrimaria { get; set; }
        public string Dados { get; set; }
    }


    public class TabelaAleatoriaParaExemplosComChavePrimariaComposta
    {
        [Key]        
        public int ChavePrimariaPart01 { get; set; }
        public DateTime ChavePrimariaPart02 { get; set; }
        public string Dados { get; set; }
    }
}
