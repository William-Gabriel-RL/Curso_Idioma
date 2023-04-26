﻿using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Aluno
{
    public class AlunoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}