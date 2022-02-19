namespace StudyIOC.ServiceModels
{
    public class RabbitMessage
    {
        public string ClientGUID { get; set; }
        public int DataNumber { get; set; }
        public int Data { get; set; }

        public string timestamp { get; set; }
    }
}
