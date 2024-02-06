namespace MicroQueue.Domain.Core.Models
{
    public class Constantes
    {
        public class Tipo
        {
            public static string Queue = "Q";
        }
        public class Evento
        {
            public static string CreateEmailQueue = "CreateEmailQueue";
            public static string CreateDocumentQueue = "CreateDocumentQueue";
            public static string ConsumerEmailQueue = "ConsumerEmailQueue";
            public static string ConsumerDocumentQueue = "ConsumerDocumentQueue";
        }
    }
}
