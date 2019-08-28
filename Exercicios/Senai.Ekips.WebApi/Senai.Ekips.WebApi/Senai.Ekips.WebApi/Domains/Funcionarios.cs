﻿using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Funcionarios
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salário { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdCargo { get; set; }
        public int? IdUsuário { get; set; }

        public Cargos IdCargoNavigation { get; set; }
        public Departamentos IdDepartamentoNavigation { get; set; }
        public Usuarios IdUsuárioNavigation { get; set; }
    }
}
