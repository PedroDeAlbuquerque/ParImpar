using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ParImpar
{
    public class Program
    {
        static void Main()
        {
            Program controlador = new();
            Boolean UsuarioFinalizouOperacao;

            do
            {
                Console.WriteLine("Digite um número para avaliar sua condição:");
                string inputDoUsuario = controlador.FiltrarInputDoUsuario(Console.ReadLine(), @"[^\d,]");
                double numeroParaAvaliar = controlador.ConverterInputParaNumero(inputDoUsuario);

                string outputDoResultado = controlador.AvaliarSeNumeroEParOuImpar(numeroParaAvaliar);
                Console.WriteLine(outputDoResultado);

                Console.WriteLine("Digite 'S' para prosseguir com outra avaliação:");
                UsuarioFinalizouOperacao = controlador.ChecarSeUsuarioFinalizouOperacao(Console.ReadLine());
            }
            while (!UsuarioFinalizouOperacao);

        }

        public string FiltrarInputDoUsuario(string inputDoUsuario, string padraoDoFiltroDeInput)
        {
            Regex filtroDeInput = new Regex(padraoDoFiltroDeInput);
            inputDoUsuario = filtroDeInput.Replace(inputDoUsuario, "");
            return inputDoUsuario;
        }

        public double ConverterInputParaNumero(string inputDoUsuario)
        {
            if (inputDoUsuario.Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(inputDoUsuario);
            }
        }

        public string AvaliarSeNumeroEParOuImpar(double numeroParaAvaliar)
        {
            StringBuilder outputDoResultado = new();

            double numeroRestante = numeroParaAvaliar % 2;

            if (numeroParaAvaliar == 0)
            {
                outputDoResultado.Append("O número digitado foi o número 0");
                return outputDoResultado.ToString();
            }

            outputDoResultado.Append($"O número {numeroParaAvaliar} é um número ");
            if (numeroRestante == 0)
            {
                outputDoResultado.Append("par");
            }
            else if (numeroRestante == 1)
            {
                outputDoResultado.Append("ímpar");
            }
            else
            {
                outputDoResultado.Append("de ponto flutuante");
            }

            return outputDoResultado.ToString();
        }

        public Boolean ChecarSeUsuarioFinalizouOperacao(string inputDoUsuario)
        {
            return (inputDoUsuario != "S");
        }
    }
}
