using System;

namespace APICalculoIMC.Models
{
    public class ClassificacaoPessoa
    {
        public double Peso { get; init; }
        public double Altura { get; init; }
        public double IMC { get; init; }
        public string Situacao { get; init; }

        public ClassificacaoPessoa(double peso, double altura)
        {
            Peso = peso;
            Altura = altura;
            IMC = Peso / (Altura * Altura); // Simulação de falha
            //IMC = Math.Round(Peso / (Altura * Altura), 1);
            Situacao = IMC switch
            {
                < 18.5 => "Magreza",
                < 25.0 => "Normal",
                < 29.9 => "Sobrepeso",
                < 40.0 => "Obesidade",
                _ => "Obesidade Grave"
            };
        }
    }
}