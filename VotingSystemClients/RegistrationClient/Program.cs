using System;
using System.Net.Http;
using Grpc.Net.Client;
using VotingSystem;


namespace RegistrationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Entidade de Registo (AR) ===");
            Console.Write("Introduza o número do Cartão de Cidadão: ");
            var citizenCardNumber = Console.ReadLine();

            // Criar canal gRPC
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




            var client = new VoterRegistrationService.VoterRegistrationServiceClient(channel);

            // Criar pedido
            var request = new VoterRequest
            {
                CitizenCardNumber = citizenCardNumber
            };

            try
            {
                var response = client.IssueVotingCredential(request);

                Console.WriteLine("\n--- Resposta do Serviço ---");
                Console.WriteLine($"Elegível: {response.IsEligible}");
                Console.WriteLine($"Credencial atribuída: {response.VotingCredential}");
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
