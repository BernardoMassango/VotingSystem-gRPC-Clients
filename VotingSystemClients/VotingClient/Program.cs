using System;
using System.Net.Http;
using Grpc.Net.Client;
using VotingSystem.Voting;

namespace VotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Entidade de Votação (AV) ===");

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var channel = GrpcChannel.ForAddress(
                "https://ken01.utad.pt:9091",
                new GrpcChannelOptions
                {
                    HttpHandler = httpHandler
                });

            var client = new VotingService.VotingServiceClient(channel);

            try
            {
                // 1. Obter candidatos
                Console.WriteLine("\nLista de candidatos:");
                var candidatesResponse = client.GetCandidates(new GetCandidatesRequest());

                foreach (var c in candidatesResponse.Candidates)
                {
                    Console.WriteLine($"{c.Id} - {c.Name}");
                }

                // 2. Votar
                Console.Write("\nIntroduza a credencial de voto: ");
                var credential = Console.ReadLine();

                Console.Write("Introduza o ID do candidato: ");
                var candidateId = int.Parse(Console.ReadLine() ?? "0");

                var voteResponse = client.Vote(new VoteRequest
                {
                    VotingCredential = credential,
                    CandidateId = candidateId
                });

                Console.WriteLine($"\nResultado do voto: {voteResponse.Message}");

                // 3. Resultados
                Console.WriteLine("\nResultados atuais:");
                var resultsResponse = client.GetResults(new GetResultsRequest());

                foreach (var r in resultsResponse.Results)
                {
                    Console.WriteLine($"{r.Id} - {r.Name}: {r.Votes} votos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao comunicar com o serviço gRPC:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPrima qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
